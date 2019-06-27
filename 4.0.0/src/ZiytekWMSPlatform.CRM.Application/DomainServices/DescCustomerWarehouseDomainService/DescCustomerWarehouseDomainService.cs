using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;
using ZiytekWMSPlatform.CRM.AppServices;
using ZiytekWMSPlatform.CRM.IRepositories;

namespace ZiytekWMSPlatform.CRM.DomainServices
{
    /// <summary>
    /// 客户-仓库领域服务
    /// </summary>
    public class DescCustomerWarehouseManager : DomainService, IDescCustomerWarehouseManager
    {
        #region 初始化
        /// <summary>
        /// 客户-仓库仓储接口
        /// </summary>
        private readonly IDescCustomerWarehouseRepository _repository;

        /// <summary>
        /// 初始化
        /// </summary>
        public DescCustomerWarehouseManager(IDescCustomerWarehouseRepository repository)
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
        public async Task<string> CreateValidateAsync(Desc_Customer_Warehouse_AppCreateInputDto input)
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
        public async Task<string> UpdateValidateAsync(Desc_Customer_Warehouse_AppUpdateInputDto input)
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

        #region 数据验证
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <param name="errMsgList">错误信息集合</param>
        /// <returns></returns>
        private async Task<string> CreateValidateAsync(Desc_Customer_Warehouse_AppCreateInputDto input, List<string> errMsgList)
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
        private async Task<string> UpdateValidateAsync(Desc_Customer_Warehouse_AppUpdateInputDto input, List<string> errMsgList)
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
