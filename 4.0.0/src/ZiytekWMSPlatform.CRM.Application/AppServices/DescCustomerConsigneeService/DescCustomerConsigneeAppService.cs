using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using Nezada.Common.Abp.Entity;
using Nezada.Common.Model;
using Nezada.Common.Utils;
using ZiytekWMSPlatform.CRM.DomainServices;
using ZiytekWMSPlatform.CRM.Entities;
using ZiytekWMSPlatform.CRM.IRepositories;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    /// <summary>
    /// 客户-收货人应用服务
    /// </summary>
    public class DescCustomerConsigneeAppService : AsyncCrudAppService<Desc_Customer_Consignee, Desc_Customer_Consignee_AppOutputDto, string, Desc_Customer_Consignee_AppGetAllInputDto, Desc_Customer_Consignee_AppCreateInputDto, Desc_Customer_Consignee_AppUpdateInputDto, Desc_Customer_Consignee_AppGetInputDto, Desc_Customer_Consignee_AppDeleteInputDto>, IDescCustomerConsigneeAppService
    {
        #region 初始化
        /// <summary>
        /// 客户-收货人仓储接口
        /// </summary>
        private readonly IDescCustomerConsigneeRepository _dataRepository;

        /// <summary>
        /// 客户-收货人域服务接口
        /// </summary>
        private readonly IDescCustomerConsigneeManager _manager;

        /// <summary>
        /// 收货人服务接口
        /// </summary>
        private readonly IPptConsigneeAppService _consigneeAppService;

        /// <summary>
        /// 初始化
        /// </summary>
        public DescCustomerConsigneeAppService(IRepository<Desc_Customer_Consignee, string> repository,
            IDescCustomerConsigneeRepository dataRepository,
            IDescCustomerConsigneeManager manager,
            IPptConsigneeAppService consigneeAppService) : base(repository)
        {
            _dataRepository = dataRepository;
            _manager = manager;
            _consigneeAppService = consigneeAppService;
        }
        #endregion

        #region 新增客户-收货人
        /// <summary>
        /// 新增客户-收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<bool> CreateDescCustomerConsigneeAsync(Desc_Customer_Consignee_AppCreateInputDto input)
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

        /// <summary>
        /// 新增客户-收货人
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <param name="customerConsigneeList">客户-收货人关系列表</param>
        /// <returns></returns>
        public async Task<bool> CreateDescCustomerConsigneeAsync(string customerid, List<Desc_Customer_Consignee_AppCreateInputDto> customerConsigneeList)
        {
            try
            {
                await _dataRepository.DeleteAsync(d => d.Customerid == customerid);
                var dataEntityList = Mapper.Map<List<Desc_Customer_Consignee>>(customerConsigneeList);
                await _dataRepository.InsertAsync(dataEntityList);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除客户-收货人
        /// <summary>
        /// 删除客户-收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task Delete(Desc_Customer_Consignee_AppDeleteInputDto input)
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

        /// <summary>
        /// 删除客户关联的所有收货人
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <returns></returns>
        public async Task DeleteAsync(string customerid)
        {
            try
            {
                await _dataRepository.DeleteAsync(d => d.Customerid == customerid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 修改客户-收货人
        /// <summary>
        /// 修改客户-收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Desc_Customer_Consignee_AppOutputDto> Update(Desc_Customer_Consignee_AppUpdateInputDto input)
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

        #region 获取客户-收货人
        /// <summary>
        /// 获取客户-收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Desc_Customer_Consignee_AppOutputDto> Get(Desc_Customer_Consignee_AppGetInputDto input)
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

        #region 查询客户-收货人
        /// <summary>
        /// 查询客户-收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<PaginatedList<Desc_Customer_Consignee_AppOutputDto>> GetAllListAsync(Desc_Customer_Consignee_AppGetAllInputDto input)
        {
            try
            {
                string dto = JsonUtils.SerializeObject(input);
                var result = await _dataRepository.GetDescCustomerConsigneeOutputListAsync(dto);
                var dataOutputList = Mapper.Map<List<Desc_Customer_Consignee_AppOutputDto>>(result.DataSource);
                return new PaginatedList<Desc_Customer_Consignee_AppOutputDto>(input.PageNo, input.PageSize, result.TotalCount, dataOutputList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 查询客户关联的所有收货人
        /// <summary>
        /// 查询客户关联的所有收货人
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <param name="warehouseid">仓库Id</param>
        /// <returns></returns>
        public async Task<List<SelectedItem>> GetCustomerConsigneeAsync(string customerid, string warehouseid)
        {
            try
            {
                var dataOutputList = new List<SelectedItem>();

                var result = await _dataRepository.GetAllListAsync(d => d.Customerid == customerid);
                foreach (var item in result)
                {
                    var filterList = await _consigneeAppService.GetConsigneeSelectedItemListAsync(new Ppt_Consignee_AppGetTreeInputDto
                    {
                        TenantId = item.TenantId,
                        Id = item.Consigneeid,
                        Warehouseid = warehouseid,
                        PageNo = 0,
                        PageSize = 0
                    });
                    dataOutputList.AddRange(filterList);
                }

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
