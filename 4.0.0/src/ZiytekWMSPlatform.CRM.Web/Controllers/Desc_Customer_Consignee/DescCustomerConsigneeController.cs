using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nezada.Common.Utils;
using ZiytekWMSPlatform.CRM.AppServices;

namespace ZiytekWMSPlatform.CRM.Web.Controllers
{
    /// <summary>
    /// 客户-收货人接口
    /// </summary>
    public class DescCustomerConsigneeController : CRMControllerBase
    {
        #region 初始化
        private readonly IDescCustomerConsigneeAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        public DescCustomerConsigneeController(IDescCustomerConsigneeAppService appService)
        {
            _appService = appService;
        }
        #endregion

        #region 删除客户-收货人
        /// <summary>
        /// 删除客户-收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteDescCustomerConsignee(Desc_Customer_Consignee_AppDeleteInputDto input)
        {
            try
            {
                await _appService.Delete(input);
                return Ok(JsonUtils.SerializeObject(true, "success"));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 查询客户-收货人
        /// <summary>
        /// 查询客户-收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="Desc_Customer_Consignee_AppOutputDto" langword="true">客户-收货人AppOutputDto</see>
        /// </returns>
        public async Task<ActionResult> GetDescCustomerConsignee(Desc_Customer_Consignee_AppGetInputDto input)
        {
            try
            {
                var result = await _appService.Get(input);
                return Ok(JsonUtils.SerializeObject(result, "success"));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 查询客户-收货人列表
        /// <summary>
        /// 查询客户-收货人列表
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="Desc_Customer_Consignee_AppOutputDto" langword="true">客户-收货人列表</see>
        /// </returns>
        public async Task<ActionResult> GetAllDescCustomerConsignee(Desc_Customer_Consignee_AppGetAllInputDto input)
        {
            try
            {
                var result = await _appService.GetAllListAsync(input);
                return Ok(JsonUtils.SerializeObject(result, "success", result.TotalCount));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion
    }
}
