using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using BeetleX.FastHttpApi.Clients;
using Microsoft.Extensions.Options;
using Nezada.Common.Abp.Entity;
using Nezada.Common.Extensions;
using Nezada.Common.Model;
using Nezada.Common.ServiceUri;
using Nezada.Common.Utils;
using ZiytekWMSPlatform.CRM.DomainServices;
using ZiytekWMSPlatform.CRM.Entities;
using ZiytekWMSPlatform.CRM.IRepositories;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    /// <summary>
    /// 客户-物资应用服务
    /// </summary>
    public class DescCustomerMaterialAppService : AsyncCrudAppService<Desc_Customer_Material, Desc_Customer_Material_AppOutputDto, string, Desc_Customer_Material_AppGetAllInputDto, Desc_Customer_Material_AppCreateInputDto, Desc_Customer_Material_AppUpdateInputDto, Desc_Customer_Material_AppGetInputDto, Desc_Customer_Material_AppDeleteInputDto>, IDescCustomerMaterialAppService
    {
        #region 初始化
        /// <summary>
        /// 客户-物资仓储接口
        /// </summary>
        private readonly IDescCustomerMaterialRepository _dataRepository;

        /// <summary>
        /// 客户-物资域服务接口
        /// </summary>
        private readonly IDescCustomerMaterialManager _manager;

        /// <summary>
        /// 微服务Uri
        /// </summary>
        private readonly IOptions<ServiceUri> _options;

        /// <summary>
        /// 初始化
        /// </summary>
        public DescCustomerMaterialAppService(IRepository<Desc_Customer_Material, string> repository,
            IDescCustomerMaterialRepository dataRepository,
            IDescCustomerMaterialManager manager,
            IOptions<ServiceUri> options) : base(repository)
        {
            _dataRepository = dataRepository;
            _manager = manager;
            _options = options;
        }
        #endregion

        #region 新增客户-物资
        /// <summary>
        /// 新增客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<bool> CreateDescCustomerMaterialAsync(Desc_Customer_Material_AppCreateInputDto input)
        {
            try
            {
                string errMsg = await _manager.CreateValidateAsync(input);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    throw new Exception(errMsg);
                }
                var result = await base.Create(input);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除客户-物资
        /// <summary>
        /// 删除客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task Delete(Desc_Customer_Material_AppDeleteInputDto input)
        {
            try
            {
                await base.Delete(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 修改客户-物资
        /// <summary>
        /// 修改客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Desc_Customer_Material_AppOutputDto> Update(Desc_Customer_Material_AppUpdateInputDto input)
        {
            try
            {
                string errMsg = await _manager.UpdateValidateAsync(input);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    throw new Exception(errMsg);
                }
                var result = await base.Update(input);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 获取客户-物资
        /// <summary>
        /// 获取客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Desc_Customer_Material_AppOutputDto> Get(Desc_Customer_Material_AppGetInputDto input)
        {
            try
            {
                var result = await base.Get(input);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 查询客户-物资
        /// <summary>
        /// 查询客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<PaginatedList<Desc_Customer_Material_AppOutputDto>> GetAllListAsync(Desc_Customer_Material_AppGetAllInputDto input)
        {
            try
            {
                //查询客户拥有的物资
                string dto = JsonUtils.SerializeObject(input);
                var result = await _dataRepository.GetDescCustomerMaterialOutputListAsync(dto);
                var dataOutputList = Mapper.Map<List<Desc_Customer_Material_AppOutputDto>>(result.DataSource);

                if (dataOutputList != null && dataOutputList.Count > 0)
                {
                    //调用ims服务
                    //物资信息服务
                    var client = new HttpApiClient(_options.Value?.IMSUri);
                    var materialService = client.Create<IMaterialInterface>();
                    var response = await materialService.GetAllPptMaterial(input.TenantId, input.Warehouseid);
                    var materialList = JsonUtils.DeserializeNezadaJsonDto<List<MaterialInfo>>(response);

                    foreach (var item in dataOutputList)
                    {
                        item.Materialname = materialList.Find(d => d.Id == item.Materialid)?.Name;
                        item.Skuid = materialList.Find(d => d.Id == item.Materialid)?.Skuid;
                    }
                }
                return new PaginatedList<Desc_Customer_Material_AppOutputDto>(input.PageNo, input.PageSize, result.TotalCount, dataOutputList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 导入客户物资关系
        /// <summary>
        /// 导入客户物资关系
        /// </summary>
        /// <param name="stream">Excel文件路径</param>
        /// <param name="fileName">Excel文件名</param>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<OutData_AppOutputDto> ImportCustomerMaterial(Stream stream, string fileName, Desc_Customer_Material_AppCreateInputDto input)
        {
            try
            {
                //等待确认导入的excel模板内容数据
                //获取Excel表数据
                var dataTable = ExcelUtils.ImportExcel(stream, fileName);
                //验证Excel数据
                await _manager.TemplateValidateAsync(dataTable);
                dataTable.Columns["物资名称"].ColumnName = "materialname";
                dataTable.Columns["物资skuid"].ColumnName = "skuid";
                //新增错误信息列
                dataTable.Columns.Add("ErrorMse", typeof(string));
                //添加物资ID列
                dataTable.Columns.Add("Materialid", typeof(string));
                dataTable.Columns.Add("Customerid", typeof(string));//添加客户ID列
                dataTable.Columns.Add("OperaterUserId", typeof(string));//添加操作人ID列
                dataTable.Columns.Add("TenantId", typeof(string));//添加租户ID列
                dataTable.Columns.Add("Warehouseid", typeof(string));//添加仓库ID列
                var errorTable = dataTable.Clone();
                var successData = dataTable.Clone();

                //调用ims服务
                //物资信息服务
                var client = new HttpApiClient(_options.Value?.IMSUri);
                var materialService = client.Create<IMaterialInterface>();
                var response = await materialService.GetAllPptMaterial(input.TenantId, input.Warehouseid);
                var materialList = JsonUtils.DeserializeNezadaJsonDto<List<MaterialInfo>>(response);

                //数据验证
                //验证该仓库是否存在对应的物资skuid，物资名称
                await _manager.ImportValidateAsync(input, dataTable, errorTable, successData, materialList);
                var outData = new OutData_AppOutputDto
                {
                    ErrorTable = errorTable,
                    SuccessData = successData,
                    AllCount = dataTable.Rows.Count,
                    SuccessCount = successData.Rows.Count,
                    FailCount = errorTable.Rows.Count
                };
                return outData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 导出失败的数据
        /// <summary>
        /// 导出失败的数据
        /// </summary>
        /// <param name="data">失败数据</param>
        /// <returns></returns>
        public async Task<Stream> ExportFailDataList(List<ExprotMaterialInfo> data)
        {
            try
            {
                await Task.Yield();
                var list = Mapper.Map<List<ExprotMaterialInfo>>(data);

                if (list == null || list.Count == 0)
                {
                    list.Add(new ExprotMaterialInfo());
                }
                return list.ExportToExcel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 插入客户物资
        /// <summary>
        /// 插入客户物资
        /// </summary>
        /// <param name="data">成功数据</param>
        /// <returns></returns>
        public async Task<bool> InputCustomerMaterialAsync(List<SaveExcel_AppInputDto> data)
        {
            try
            {
                if (data.Count > 0)
                {
                    var desc_Customer_MaterialList = Mapper.Map<List<Desc_Customer_Material>>(data);

                    await _dataRepository.InsertAsync(desc_Customer_MaterialList);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 查询客户-物资选项列表（后端使用）
        /// <summary>
        /// 查询客户-物资选项列表（后端使用）
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="SelectedItem" langword="true">客户-物资列表</see>
        /// </returns>
        public async Task<List<SelectedItem>> GetAllCustomerMaterialAsync(Desc_Customer_Material_AppGetAllInputDto input)
        {
            try
            {
                string dto = JsonUtils.SerializeObject(input);
                var result = await _dataRepository.GetDescCustomerMaterialOutputListAsync(dto);
                var dataOutputList = Mapper.Map<List<SelectedItem>>(result.DataSource);

                return dataOutputList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
