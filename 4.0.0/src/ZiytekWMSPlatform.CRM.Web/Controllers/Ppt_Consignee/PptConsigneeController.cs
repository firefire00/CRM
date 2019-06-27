using Microsoft.AspNetCore.Mvc;
using Nezada.Common.Utils;
using Nezada.Common.Model;
using System;
using System.Threading.Tasks;
using ZiytekWMSPlatform.CRM.AppServices;

namespace ZiytekWMSPlatform.CRM.Web.Controllers
{
    /// <summary>
    /// 收货人接口
    /// </summary>
    public class PptConsigneeController : CRMControllerBase
    {
        #region 初始化
        /// <summary>
        /// 收货人域服务接口
        /// </summary>
        private readonly IPptConsigneeAppService _appService;

        public PptConsigneeController(IPptConsigneeAppService appService)
        {
            _appService = appService;
        }
        #endregion

        #region 新增收货人
        /// <summary>
        /// 新增收货人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddPptConsignee(Ppt_Consignee_AppCreateInputDto input)
        {
            try
            {
                var result = await _appService.CreatePptConsigneeAsync(input);
                return Ok(JsonUtils.SerializeObject(true, "success"));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 修改收获人
        /// <summary>
        /// 修改收货人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdatePptConsignee(Ppt_Consignee_AppUpdateInputDto input)
        {
            try
            {
                var result = await _appService.Update(input);
                return Ok(JsonUtils.SerializeObject(true, "success"));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 删除收货人
        /// <summary>
        /// 删除收货人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeletePptConsignee(Ppt_Consignee_AppDeleteInputDto input)
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

        #region 获取收货人
        /// <summary>
        /// 获取收货人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetPptConsignee(Ppt_Consignee_AppGetInputDto input)
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

        #region 查询所有收货人
        /// <summary>
        /// 查询所有收货人
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ActionResult> GetAllPptConsignee(Ppt_Consignee_AppGetAllInputDto input)
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

        #region 查询收货人（用于下拉）
        /// <summary>
        /// 查询收货人（用于下拉）
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// <see cref="SelectedItem" langword="true">客户列表</see>
        /// </returns>
        public async Task<ActionResult> GetAllConsigneeList(Ppt_Consignee_AppGetTreeInputDto input)
        {
            try
            {
                input.PageNo = input.PageSize = 0;
                var result = await _appService.GetConsigneeSelectedItemListAsync(input);
                return Ok(JsonUtils.SerializeObject(result, "success", result.Count));
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
