using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Abp.Domain.Services;
using Nezada.Common.Utils;
using ZiytekWMSPlatform.CRM.AppServices;
using ZiytekWMSPlatform.CRM.IRepositories;

namespace ZiytekWMSPlatform.CRM.DomainServices
{
    /// <summary>
    /// 客户-物资领域服务
    /// </summary>
    public class DescCustomerMaterialManager : DomainService, IDescCustomerMaterialManager
    {
        #region 初始化
        /// <summary>
        /// 客户-物资仓储接口
        /// </summary>
        private readonly IDescCustomerMaterialRepository _repository;

        /// <summary>
        /// 初始化
        /// </summary>
        public DescCustomerMaterialManager(IDescCustomerMaterialRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region 新增验证
        /// <summary>
        /// 新增验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<string> CreateValidateAsync(Desc_Customer_Material_AppCreateInputDto input)
        {
            try
            {
                string errMsg = string.Empty;
                var errMsgList = new List<string>();
                errMsg = await CreateValidateAsync(input, errMsgList);
                return errMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 修改验证
        /// <summary>
        /// 修改验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<string> UpdateValidateAsync(Desc_Customer_Material_AppUpdateInputDto input)
        {
            try
            {
                string errMsg = string.Empty;
                var errMsgList = new List<string>();
                errMsg = await UpdateValidateAsync(input, errMsgList);
                return errMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 客户物资导入验证
        /// <summary>
        /// 客户物资导入验证
        /// </summary>
        /// <param name="input"></param>
        /// <param name="dataTable"></param>
        /// <param name="errorTable"></param>
        /// <param name="successData"></param>
        /// <param name="materialInfoList"></param>
        /// <returns></returns>
        public async Task<string> ImportValidateAsync(Desc_Customer_Material_AppCreateInputDto input, DataTable dataTable, DataTable errorTable, DataTable successData, List<MaterialInfo> materialInfoList)
        {
            try
            {
                string errMsg = string.Empty;
                var errMsgList = new List<string>();
                errMsg = await ImportValidateAsync(input, dataTable, errorTable, successData, materialInfoList, errMsgList);
                return errMsg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <param name="input"></param>
        /// <param name="dataTable"></param>
        /// <param name="errorTable"></param>
        /// <param name="successData"></param>
        /// <param name="materialInfoList"></param>
        /// <param name="errMsgList"></param>
        /// <returns></returns>
        private async Task<string> ImportValidateAsync(Desc_Customer_Material_AppCreateInputDto input, DataTable dataTable, DataTable errorTable, DataTable successData, List<MaterialInfo> materialInfoList, List<string> errMsgList)
        {
            try
            {
                if (dataTable.Rows.Count > 0)
                {
                    DataTable filterSuccess = dataTable.Clone();
                    //校验excel数据是否重复
                    await ImportExcelValidateAsync(dataTable, errorTable, filterSuccess);

                    if (errorTable.Rows.Count > 0)
                    {
                        return null;
                    }

                    //校验物资信息是否存在
                    foreach (DataRow row in filterSuccess.Rows)
                    {
                        string materialname = ConvertUtils.ToStrDef(row["materialname"]).Trim();
                        string skuid = ConvertUtils.ToStrDef(row["skuid"]).Trim();

                        MaterialInfo material = materialInfoList.Find(d => d.Name == materialname && d.Skuid == skuid);
                        if (material == null)
                        {
                            row["ErrorMse"] = string.Format(@"客户没有维护物资：【{0}】，SKUID:【{1}】信息，请维护", materialname, skuid);
                            errorTable.ImportRow(row);
                        }
                        else
                        {
                            //判断客户物资关系是否存在
                            var count = await _repository.CountAsync(d => d.Warehouseid == input.Warehouseid && d.TenantId == input.TenantId && d.Customerid == input.Customerid && d.Materialid == material.Id);
                            if (count > 0)
                            {
                                //存在
                                row["ErrorMse"] = string.Format(@"已存在客户物资关系：【{0}】，SKUID:【{1}】，无法重复维护", materialname, skuid);
                                errorTable.ImportRow(row);
                            }
                            else
                            {
                                row["Materialid"] = material.Id;
                                row["Customerid"] = input.Customerid;
                                row["Warehouseid"] = input.Warehouseid;
                                row["TenantId"] = input.TenantId;
                                row["OperaterUserId"] = input.OperaterUserId;
                                successData.ImportRow(row);
                            }
                        }
                    }
                }
                else
                {
                    return null;
                }

                return string.Join(',', errMsgList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断excel文件内容是否重复
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="errorTable"></param>
        /// <param name="filterSuccess"></param>
        /// <returns></returns>
        private async Task ImportExcelValidateAsync(DataTable dataTable, DataTable errorTable, DataTable filterSuccess)
        {
            try
            {
                await Task.Yield();

                foreach (DataRow row in dataTable.Rows)
                {
                    string materialname = ConvertUtils.ToStrDef(row["materialname"]).Trim();
                    string skuid = ConvertUtils.ToStrDef(row["skuid"]).Trim();

                    string filterExpression = string.Format("materialname = '{0}' AND skuid = '{1}' ", materialname, skuid);

                    DataRow[] drs = dataTable.Select(filterExpression);
                    if (drs.Length > 1)
                    {
                        string errMessage = string.Format("物资名称[{0}]和SKU编码[{1}]在文件中重复", materialname, skuid);
                        row["ErrorMse"] = errMessage;
                        errorTable.ImportRow(row);
                    }
                    else
                    {
                        filterSuccess.ImportRow(row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Excel数据列名验证
        /// <summary>
        /// Excel数据列名验证
        /// </summary>
        /// <param name="dt">Excel数据</param>
        /// <returns></returns>
        public async Task TemplateValidateAsync(DataTable dt)
        {
            try
            {
                await Task.Yield();
                if (!dt.Columns.Contains("物资名称") ||
                    !dt.Columns.Contains("物资skuid"))
                {
                    throw new Exception("选择导入的Excel文件有误！");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 数据验证
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <param name="errMsgList">错误信息集合</param>
        /// <returns></returns>
        private async Task<string> CreateValidateAsync(Desc_Customer_Material_AppCreateInputDto input, List<string> errMsgList)
        {
            try
            {
                await Task.Yield();
                return string.Join(',', errMsgList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <param name="errMsgList">错误信息集合</param>
        /// <returns></returns>
        private async Task<string> UpdateValidateAsync(Desc_Customer_Material_AppUpdateInputDto input, List<string> errMsgList)
        {
            try
            {
                await Task.Yield();
                return string.Join(',', errMsgList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
