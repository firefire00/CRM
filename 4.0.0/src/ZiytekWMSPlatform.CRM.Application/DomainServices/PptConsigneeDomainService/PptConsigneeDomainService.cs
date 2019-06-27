using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Services;
using ZiytekWMSPlatform.CRM.AppServices;
using ZiytekWMSPlatform.CRM.IRepositories;

namespace ZiytekWMSPlatform.CRM.DomainServices
{
    /// <summary>
    /// 收货人领域服务
    /// </summary>
    public class PptConsigneeManager : DomainService, IPptConsigneeManager
    {
        #region 初始化
        /// <summary>
        /// 收货人仓储接口
        /// </summary>
        private readonly IPptConsigneeRepository _repository;

        /// <summary>
        /// 初始化
        /// </summary>
        public PptConsigneeManager(IPptConsigneeRepository repository)
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
        public async Task<string> CreateValidateAsync(Ppt_Consignee_AppCreateInputDto input)
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
        public async Task<string> UpdateValidateAsync(Ppt_Consignee_AppUpdateInputDto input)
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
        private async Task<string> CreateValidateAsync(Ppt_Consignee_AppCreateInputDto input, List<string> errMsgList)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input.Consigneename))
                {
                    errMsgList.Add(string.Format($"[收货人姓名不能为空！]"));
                }
                if (input.Province <= 0)
                {
                    errMsgList.Add(string.Format($"[省份不能为空！]"));
                }

                if (string.IsNullOrWhiteSpace(input.Detailaddress))
                {
                    errMsgList.Add(string.Format($"[详细地址不能为空！]"));
                }
                var dataList = await _repository.CountAsync(d => d.Warehouseid == input.Warehouseid && d.Consigneename == input.Consigneename);
                if (dataList > 0)
                {
                    errMsgList.Add(string.Format($"[收货人名字: {input.Consigneename}] 已存在"));
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
        private async Task<string> UpdateValidateAsync(Ppt_Consignee_AppUpdateInputDto input, List<string> errMsgList)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(input.Consigneename))
                {
                    errMsgList.Add(string.Format($"[收货人姓名不能为空！]"));
                }
                if (input.Province <= 0)
                {
                    errMsgList.Add(string.Format($"[省份不能为空！]"));
                }

                var dataCount = await _repository.CountAsync(d => d.TenantId == input.TenantId && d.Consigneename == input.Consigneename && d.Id != input.Id);

                if (dataCount > 0)
                {
                    errMsgList.Add(string.Format($"[收货人： {input.Consigneename} 已存在]"));
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
