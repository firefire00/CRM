using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;
using ZiytekWMSPlatform.CRM.AppServices;
using ZiytekWMSPlatform.CRM.IRepositories;

namespace ZiytekWMSPlatform.CRM.DomainServices
{
    /// <summary>
    /// 客户领域服务
    /// </summary>
    public class PptCustomerManager : DomainService, IPptCustomerManager
    {
        #region 初始化
        /// <summary>
        /// 客户仓储接口
        /// </summary>
        private readonly IPptCustomerRepository _repository;

        /// <summary>
        /// 初始化
        /// </summary>
        public PptCustomerManager(IPptCustomerRepository repository)
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
        public async Task<string> CreateValidateAsync(Ppt_Customer_AppCreateInputDto input)
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
        public async Task<string> UpdateValidateAsync(Ppt_Customer_AppUpdateInputDto input)
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
        private async Task<string> CreateValidateAsync(Ppt_Customer_AppCreateInputDto input, List<string> errMsgList)
        {
            try
            {
                var count = await _repository.CountAsync(d => d.TenantId == input.TenantId && d.Name == input.Name && d.Customertype == input.Customertype);
                if (count > 0)
                {
                    errMsgList.Add(string.Format($"[客户 {input.Name} 已存在]"));
                }
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
        private async Task<string> UpdateValidateAsync(Ppt_Customer_AppUpdateInputDto input, List<string> errMsgList)
        {
            try
            {
                var count = await _repository.CountAsync(d => d.TenantId == input.TenantId && d.Name == input.Name && d.Customertype == input.Customertype && d.Id != input.Id);
                if (count > 0)
                {
                    errMsgList.Add(string.Format($"[客户 {input.Name} 已存在]"));
                }
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
