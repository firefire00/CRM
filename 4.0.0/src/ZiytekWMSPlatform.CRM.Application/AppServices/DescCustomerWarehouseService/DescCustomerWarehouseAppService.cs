using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using BeetleX.FastHttpApi.Clients;
using Microsoft.Extensions.Options;
using Nezada.Common.Abp.Entity;
using Nezada.Common.Model;
using Nezada.Common.ServiceUri;
using Nezada.Common.Utils;
using ZiytekWMSPlatform.CRM.DomainServices;
using ZiytekWMSPlatform.CRM.Entities;
using ZiytekWMSPlatform.CRM.IRepositories;

namespace ZiytekWMSPlatform.CRM.AppServices
{
    /// <summary>
    /// 客户-仓库应用服务
    /// </summary>
    public class DescCustomerWarehouseAppService : AsyncCrudAppService<Desc_Customer_Warehouse, Desc_Customer_Warehouse_AppOutputDto, string, Desc_Customer_Warehouse_AppGetAllInputDto, Desc_Customer_Warehouse_AppCreateInputDto, Desc_Customer_Warehouse_AppUpdateInputDto, Desc_Customer_Warehouse_AppGetInputDto, Desc_Customer_Warehouse_AppDeleteInputDto>, IDescCustomerWarehouseAppService
    {
        #region 初始化
        /// <summary>
        /// 客户-仓库仓储接口
        /// </summary>
        private readonly IDescCustomerWarehouseRepository _dataRepository;

        /// <summary>
        /// 客户-仓库域服务接口
        /// </summary>
        private readonly IDescCustomerWarehouseManager _manager;

        /// <summary>
        /// 微服务Uri
        /// </summary>
        private readonly IOptions<ServiceUri> _options;

        /// <summary>
        /// 初始化
        /// </summary>
        public DescCustomerWarehouseAppService(IRepository<Desc_Customer_Warehouse, string> repository,
            IDescCustomerWarehouseRepository dataRepository,
            IDescCustomerWarehouseManager manager,
            IOptions<ServiceUri> options) : base(repository)
        {
            _dataRepository = dataRepository;
            _manager = manager;
            _options = options;
        }
        #endregion

        #region 新增客户-仓库
        /// <summary>
        /// 新增客户-仓库
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<bool> CreateDescCustomerWarehouseAsync(Desc_Customer_Warehouse_AppCreateInputDto input)
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
        /// 新增客户-仓库
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <param name="customerWarehouseList">客户-仓库关系列表</param>
        /// <returns></returns>
        public async Task<bool> CreateDescCustomerWarehouseAsync(string customerid, List<Desc_Customer_Warehouse_AppCreateInputDto> customerWarehouseList)
        {
            try
            {
                await _dataRepository.DeleteAsync(d => d.Customerid == customerid);
                var dataEntityList = Mapper.Map<List<Desc_Customer_Warehouse>>(customerWarehouseList);
                await _dataRepository.InsertAsync(dataEntityList);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除客户-仓库
        /// <summary>
        /// 删除客户-仓库
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task Delete(Desc_Customer_Warehouse_AppDeleteInputDto input)
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
        /// 删除客户关联的所有仓库
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

        #region 修改客户-仓库
        /// <summary>
        /// 修改客户-仓库
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Desc_Customer_Warehouse_AppOutputDto> Update(Desc_Customer_Warehouse_AppUpdateInputDto input)
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

        #region 获取客户-仓库
        /// <summary>
        /// 获取客户-仓库
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Desc_Customer_Warehouse_AppOutputDto> Get(Desc_Customer_Warehouse_AppGetInputDto input)
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

        #region 查询客户-仓库
        /// <summary>
        /// 查询客户-仓库
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<PaginatedList<Desc_Customer_Warehouse_AppOutputDto>> GetAllListAsync(Desc_Customer_Warehouse_AppGetAllInputDto input)
        {
            try
            {
                string dto = JsonUtils.SerializeObject(input);
                var result = await _dataRepository.GetDescCustomerWarehouseOutputListAsync(dto);
                var dataOutputList = Mapper.Map<List<Desc_Customer_Warehouse_AppOutputDto>>(result.DataSource);
                return new PaginatedList<Desc_Customer_Warehouse_AppOutputDto>(input.PageNo, input.PageSize, result.TotalCount, dataOutputList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 查询客户关联的所有仓库
        /// <summary>
        /// 查询客户关联的所有仓库
        /// </summary>
        /// <param name="customerid">客户Id</param>
        /// <param name="tenantId">租户Id</param>
        /// <returns></returns>
        public async Task<Customer_Warehouse_AppOutputDto> GetCustomerWarehouseAsync(string customerid, string tenantId)
        {
            try
            {
                var dataOutputDto = new Customer_Warehouse_AppOutputDto();
                var result = await _dataRepository.GetAllListAsync(d => d.Customerid == customerid);
                var dataOutputList = Mapper.Map<List<Desc_Customer_Warehouse_AppOutputDto>>(result);

                var dataOutputDtoList = new List<Desc_Customer_Warehouse_AppOutputDto>();

                var client = new HttpApiClient(_options.Value?.FacilitiesUri);
                var warehouseService = client.Create<IFacilitiesInterface>();
                var response = await warehouseService.GetWarehouseSelectedItemList(tenantId, true);
                var warehosueList = JsonUtils.DeserializeNezadaJsonDto<List<SelectedItem>>(response);

                warehosueList = warehosueList.FindAll(d => d.Enabled == true);
                foreach (var warehosue in warehosueList)
                {
                    var dataOutput = dataOutputList.Find(d => d.Warehouseid == warehosue.Id);
                    if (dataOutput != null)
                    {
                        warehosue.Selected = true;
                        dataOutput.WarehouseName = warehosue.Text;
                        dataOutputDtoList.Add(dataOutput);
                    }
                }
                dataOutputDto.CustomerWarehouseList = dataOutputDtoList;
                dataOutputDto.WarehouseList = warehosueList;

                return dataOutputDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
