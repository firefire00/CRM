using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nezada.Common.Model;
using Nezada.Common.Utils;
using ZiytekWMSPlatform.CRM.AppServices;

namespace ZiytekWMSPlatform.CRM.Web.Controllers
{
    /// <summary>
    /// 客户-物资接口
    /// </summary>
    public class DescCustomerMaterialController : CRMControllerBase
    {
        #region 初始化
        private readonly IDescCustomerMaterialAppService _appService;

        /// <summary>
        /// 初始化
        /// </summary>
        public DescCustomerMaterialController(IDescCustomerMaterialAppService appService)
        {
            _appService = appService;
        }
        #endregion

        #region 新增客户-物资
        /// <summary>
        /// 新增客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<ActionResult> AddDescCustomerMaterial(Desc_Customer_Material_AppCreateInputDto input)
        {
            try
            {
                var result = await _appService.CreateDescCustomerMaterialAsync(input);
                return Ok(JsonUtils.SerializeObject(true, "success"));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 修改客户-物资
        /// <summary>
        /// 修改客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateDescCustomerMaterial(Desc_Customer_Material_AppUpdateInputDto input)
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

        #region 删除客户-物资
        /// <summary>
        /// 删除客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteDescCustomerMaterial(Desc_Customer_Material_AppDeleteInputDto input)
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

        #region 查询客户-物资
        /// <summary>
        /// 查询客户-物资
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="Desc_Customer_Material_AppOutputDto" langword="true">客户-物资AppOutputDto</see>
        /// </returns>
        public async Task<ActionResult> GetDescCustomerMaterial(Desc_Customer_Material_AppGetInputDto input)
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

        #region 查询客户-物资列表
        /// <summary>
        /// 查询客户-物资列表
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="Desc_Customer_Material_AppOutputDto" langword="true">客户-物资列表</see>
        /// </returns>
        [AllowAnonymous]
        public async Task<ActionResult> GetAllDescCustomerMaterial(Desc_Customer_Material_AppGetAllInputDto input)
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

        #region 查询客户-物资选项列表（后端使用）
        /// <summary>
        /// 查询客户-物资选项列表（后端使用）
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns>
        /// <see cref="SelectedItem" langword="true">客户-物资列表</see>
        /// </returns>
        [AllowAnonymous]
        public async Task<ActionResult> GetAllCustomerMaterial(Desc_Customer_Material_AppGetAllInputDto input)
        {
            try
            {
                var result = await _appService.GetAllCustomerMaterialAsync(input);
                return Ok(JsonUtils.SerializeObject(result, "success"));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 导入客户物资关系
        /// <summary>
        /// 导入客户物资关系
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<ActionResult> ImportCustomerMaterial(Desc_Customer_Material_AppCreateInputDto input)
        {
            try
            {
                var fileList = Request.Form.Files;
                if (fileList == null || fileList.Count == 0)
                {
                    return null;
                }
                var file = fileList[0];
                var fileName = file.FileName;
                var stream = file.OpenReadStream();

                var result = await _appService.ImportCustomerMaterial(stream, fileName, input);
                return Ok(JsonUtils.SerializeObject(result, "failed"));

            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }

        #endregion

        #region 导出错误的客户物资
        /// <summary>
        /// 导出错误的客户物资
        /// </summary>
        /// <param name="data">错误数据</param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<ActionResult> ExportFailCustomerMaterial([FromBody]List<ExprotMaterialInfo> data)
        {
            try
            {
                if (data != null && data.Count > 0)
                {
                    var streamFile = await _appService.ExportFailDataList(data);
                    if (streamFile.Length > 0)
                    {
                        byte[] buffer = ConvertUtils.StreamToByte(streamFile);
                        return File(buffer, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "维护客户物资失败数据.xls");
                    }
                }
                return Ok(JsonUtils.SerializeObject(false, "failed"));
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("异常消息:{0} {1}", ex.Message, ex.InnerException?.Message);
                return BadRequest(JsonUtils.SerializeObject(false, "failed", ex.Message));
            }
        }
        #endregion

        #region 导入保存客户-物资
        /// <summary>
        /// 导入保存客户-物资
        /// </summary>
        /// <param name="data">成功数据</param>
        /// <returns></returns>
        public async Task<ActionResult> SaveCustomerMaterial([FromBody]List<SaveExcel_AppInputDto> data)
        {
            try
            {
                var result = await _appService.InputCustomerMaterialAsync(data);
                return Ok(JsonUtils.SerializeObject(true, "success"));
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
