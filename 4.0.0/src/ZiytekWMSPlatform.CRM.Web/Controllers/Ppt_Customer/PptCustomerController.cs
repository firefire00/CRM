using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nezada.Common.Model;
using Nezada.Common.Utils;
using ZiytekWMSPlatform.CRM.AppServices;

namespace ZiytekWMSPlatform.CRM.Web.Controllers
{
    /// <summary>
    /// 客户接口
    /// </summary>
    public class PptCustomerController : CRMControllerBase
    {
        #region 初始化
        private readonly IPptCustomerAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        public PptCustomerController(IPptCustomerAppService appService)
        {
            _appService = appService;
        }
        #endregion

        #region 新增客户
        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<ActionResult> AddPptCustomer([FromBody]Ppt_Customer_AppCreateInputDto input)
        {
            try
            {
                var result = await _appService.CreatePptCustomerAsync(input);
                return Ok(JsonUtils.SerializeObject(true, "success"));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 修改客户
        /// <summary>
        /// 修改客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<ActionResult> UpdatePptCustomer(Ppt_Customer_AppUpdateInputDto input)
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

        #region 删除客户
        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<ActionResult> DeletePptCustomer(Ppt_Customer_AppDeleteInputDto input)
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

        #region 查询客户
        /// <summary>
        /// 查询客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="Ppt_Customer_AppOutputDto" langword="true">客户AppOutputDto</see>
        /// </returns>
        public async Task<ActionResult> GetPptCustomer(Ppt_Customer_AppGetInputDto input)
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

        #region 查询客户列表
        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="Ppt_Customer_AppOutputDto" langword="true">客户列表</see>
        /// </returns>
        public async Task<ActionResult> GetAllPptCustomer(Ppt_Customer_AppGetAllInputDto input)
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

        #region 查询客户下拉列表（1供应商 2货主 3代销商 4经销商 5分包商）
        /// <summary>
        /// 查询客户下拉列表 （1供应商 2货主 3代销商 4经销商 5分包商）
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="SelectedItem" langword="true">客户列表</see>
        /// </returns>
        public async Task<ActionResult> GetCustomerSelectedItemList(Ppt_Customer_AppGetTreeInputDto input)
        {
            try
            {
                input.PageNo = input.PageSize = 0;
                var result = await _appService.GetCustomerSelectedItemListAsync(input);
                return Ok(JsonUtils.SerializeObject(result, "success", result.Count));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 性别下拉
        /// <summary>
        /// 性别下拉
        /// </summary>
        /// <param name="sex">性别</param>
        /// <returns></returns>
        public async Task<ActionResult> GetSexList(string sex)
        {
            try
            {
                await Task.Yield();
                var result = EnumUtils.GetEnumList<Sex>(sex);
                return Ok(JsonUtils.SerializeObject(result, "success"));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 查询客户合作仓库所属物资列表
        /// <summary>
        /// 查询客户合作仓库所属物资列表
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="Ppt_Customer_AppOutputDto" langword="true">客户合作仓库所属物资列表</see>
        /// </returns>
        [AllowAnonymous]
        public async Task<ActionResult> GetAllDescCustomerWarehouse(Ppt_Customer_AppGetAllInputDto input)
        {
            try
            {
                var result = await _appService.GetCustomerWarehouseListAsync(input);
                return Ok(JsonUtils.SerializeObject(result, "success", result.TotalCount));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 客户类型下拉
        /// <summary>
        /// 客户类型下拉
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <returns></returns>
        public async Task<ActionResult> GetCustomerTypeList(string customerType)
        {
            try
            {
                await Task.Yield();
                var result = EnumUtils.GetEnumList<CustomerType>(customerType);
                return Ok(JsonUtils.SerializeObject(result, "success"));
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
