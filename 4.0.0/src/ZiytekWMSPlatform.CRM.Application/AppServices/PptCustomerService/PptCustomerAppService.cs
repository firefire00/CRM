using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using BeetleX.FastHttpApi.Clients;
using DotNetCore.CAP;
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
    /// 客户应用服务
    /// </summary>
    public class PptCustomerAppService : AsyncCrudAppService<Ppt_Customer, Ppt_Customer_AppOutputDto, string, Ppt_Customer_AppGetAllInputDto, Ppt_Customer_AppCreateInputDto, Ppt_Customer_AppUpdateInputDto, Ppt_Customer_AppGetInputDto, Ppt_Customer_AppDeleteInputDto>, IPptCustomerAppService
    {
        #region 初始化
        /// <summary>
        /// 客户仓储接口
        /// </summary>
        private readonly IPptCustomerRepository _dataRepository;

        /// <summary>
        /// 客户域服务接口
        /// </summary>
        private readonly IPptCustomerManager _manager;

        /// <summary>
        /// 消息队列
        /// </summary>
        private readonly ICapPublisher _capPublisher;

        /// <summary>
        /// 微服务Uri
        /// </summary>
        private readonly IOptions<ServiceUri> _options;

        /// <summary>
        /// 客户-收货人关系
        /// </summary>
        private readonly IDescCustomerConsigneeAppService _customerConsigneeAppService;

        /// <summary>
        /// 客户-仓库关系
        /// </summary>
        private readonly IDescCustomerWarehouseAppService _customerWarehouseAppService;

        /// <summary>
        /// 初始化
        /// </summary>
        public PptCustomerAppService(IRepository<Ppt_Customer, string> repository,
            IPptCustomerRepository dataRepository,
            IPptCustomerManager manager,
            ICapPublisher capPublisher,
            IOptions<ServiceUri> options,
            IDescCustomerConsigneeAppService customerConsigneeAppService,
            IDescCustomerWarehouseAppService customerWarehouseAppService) : base(repository)
        {
            _dataRepository = dataRepository;
            _manager = manager;
            _capPublisher = capPublisher;
            _options = options;
            _customerConsigneeAppService = customerConsigneeAppService;
            _customerWarehouseAppService = customerWarehouseAppService;
        }
        #endregion

        #region 新增客户
        /// <summary>
        /// 新增客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<bool> CreatePptCustomerAsync(Ppt_Customer_AppCreateInputDto input)
        {
            try
            {
                string errMsg = await _manager.CreateValidateAsync(input);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    throw new Exception(errMsg);
                }
                var result = await base.Create(input);

                input.CustomerConsigneeList.ForEach(d => d.Customerid = result.Id);
                input.CustomerWarehouseList.ForEach(d => d.Customerid = result.Id);

                await _customerConsigneeAppService.CreateDescCustomerConsigneeAsync(result.Id, input.CustomerConsigneeList);
                await _customerWarehouseAppService.CreateDescCustomerWarehouseAsync(result.Id, input.CustomerWarehouseList);

                //日志
                var queueLog = QueueUtils.BuildQueueLog(LogType.OPERATION, string.Format($"客户 {input.Name}"), input.OperaterUserId, input.OperaterUserName, input.TenantId, result.Id, input.Warehouseid, OperationType.CREATE, TitleType.CREATE, input.Systemtype);
                await _capPublisher.PublishAsync(CapQueueName.Log_Basis, queueLog);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除客户
        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task Delete(Ppt_Customer_AppDeleteInputDto input)
        {
            try
            {
                //删除
                var dataEntity = await _dataRepository.SingleAsync(d => d.Id == input.Id);
                await base.Delete(input);

                await _customerConsigneeAppService.DeleteAsync(input.Id);

                await _customerWarehouseAppService.DeleteAsync(input.Id);

                //日志
                var queueLog = QueueUtils.BuildQueueLog(LogType.OPERATION, string.Format($"客户 {dataEntity.Name}"), input.OperaterUserId, input.OperaterUserName, input.TenantId, dataEntity.Id, input.Warehouseid, OperationType.DELETE, TitleType.DELETE, input.Systemtype);
                await _capPublisher.PublishAsync(CapQueueName.Log_Basis, queueLog);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 修改客户
        /// <summary>
        /// 修改客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Ppt_Customer_AppOutputDto> Update(Ppt_Customer_AppUpdateInputDto input)
        {
            try
            {
                string errMsg = await _manager.UpdateValidateAsync(input);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    throw new Exception(errMsg);
                }
                var result = await base.Update(input);

                input.CustomerConsigneeList.ForEach(d => d.Customerid = result.Id);
                input.CustomerWarehouseList.ForEach(d => d.Customerid = result.Id);

                await _customerConsigneeAppService.CreateDescCustomerConsigneeAsync(result.Id, input.CustomerConsigneeList);
                await _customerWarehouseAppService.CreateDescCustomerWarehouseAsync(result.Id, input.CustomerWarehouseList);

                //日志
                var queueLog = QueueUtils.BuildQueueLog(LogType.OPERATION, string.Format($"客户 {input.Name}"), input.OperaterUserId, input.OperaterUserName, input.TenantId, input.Id, input.Warehouseid, OperationType.UPDATE, TitleType.MODIFY, input.Systemtype);
                await _capPublisher.PublishAsync(CapQueueName.Log_Basis, queueLog);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 获取客户
        /// <summary>
        /// 获取客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Ppt_Customer_AppOutputDto> Get(Ppt_Customer_AppGetInputDto input)
        {
            try
            {
                var result = await base.Get(input);

                result.SexList = EnumUtils.GetEnumList<Sex>(ConvertUtils.ToStrDef(result.Sex));
                result.ConsigneeList = await _customerConsigneeAppService.GetCustomerConsigneeAsync(result.Id, result.Warehouseid);
                result.CustomerWarehouse = await _customerWarehouseAppService.GetCustomerWarehouseAsync(result.Id, result.TenantId);

                var client = new HttpApiClient(_options.Value.AddressUri);
                var addressService = client.Create<IAddressInterface>();
                var result1 = await addressService.GetAllAddressList(result.Province, result.City, result.District);
                result.AllAddress = JsonUtils.DeserializeNezadaJsonDto<NezadaAddress>(result1);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 查询客户
        /// <summary>
        /// 查询客户
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<PaginatedList<Ppt_Customer_AppOutputDto>> GetAllListAsync(Ppt_Customer_AppGetAllInputDto input)
        {
            try
            {
                string dto = JsonUtils.SerializeObject(input);
                var result = await _dataRepository.GetPptCustomerOutputListAsync(dto);
                var dataOutputList = Mapper.Map<List<Ppt_Customer_AppOutputDto>>(result.DataSource);

                var client = new HttpApiClient(_options.Value.WConfigurationUri);
                var userService = client.Create<IUserInterface>();
                var response = await userService.GetAllUserList(input.TenantId);
                var userList = JsonUtils.DeserializeNezadaJsonDto<List<SelectedItem>>(response);

                foreach (var dataOutput in dataOutputList)
                {
                    dataOutput.CreatorUserId = userList.Find(d => d.Id == dataOutput.CreatorUserId)?.Text;
                }

                return new PaginatedList<Ppt_Customer_AppOutputDto>(input.PageNo, input.PageSize, result.TotalCount, dataOutputList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 查询客户可选项列表
        /// <summary>
        /// 查询客户可选项列表
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<List<SelectedItem>> GetCustomerSelectedItemListAsync(Ppt_Customer_AppGetTreeInputDto input)
        {
            try
            {
                string dto = JsonUtils.SerializeObject(input);
                var result = await _dataRepository.GetPptCustomerOutputListAsync(dto);
                var dataOutputList = new List<SelectedItem>();
                if (result.DataSource.Count > 0)
                {
                    dataOutputList = Mapper.Map<List<SelectedItem>>(result.DataSource);
                    dataOutputList.FindAll(d => d.Id == input.Id).ForEach(d => d.Selected = true);
                }

                return dataOutputList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 查询客户合作仓库所属物资列表
        /// <summary>
        /// 查询客户合作仓库所属物资列表
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<PaginatedList<Ppt_Customer_AppOutputDto>> GetCustomerWarehouseListAsync(Ppt_Customer_AppGetAllInputDto input)
        {
            try
            {
                //查询客户信息
                var customerList = await GetAllListAsync(input);
                List<string> nameList = new List<string>();
                //循环遍历仓库信息至customerList里
                foreach (var item in customerList.DataSource)
                {
                    var warehouseInfoLists = await _customerWarehouseAppService.GetCustomerWarehouseAsync(item.Id, input.TenantId);
                    foreach (var itemList in warehouseInfoLists.CustomerWarehouseList)
                    {
                        nameList.Add(itemList.WarehouseName);
                    }
                    item.WarehouseName = string.Join('、', nameList);
                    nameList.Clear();
                }
                return new PaginatedList<Ppt_Customer_AppOutputDto>(input.PageNo, input.PageSize, customerList.TotalCount, customerList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
