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
    /// 收货人应用服务
    /// </summary>
    public class PptConsigneeAppService : AsyncCrudAppService<Ppt_Consignee, Ppt_Consignee_AppOutputDto, string, Ppt_Consignee_AppGetAllInputDto, Ppt_Consignee_AppCreateInputDto, Ppt_Consignee_AppUpdateInputDto, Ppt_Consignee_AppGetInputDto, Ppt_Consignee_AppDeleteInputDto>, IPptConsigneeAppService
    {
        #region 初始化
        /// <summary>
        /// 收货人仓储接口
        /// </summary>
        private readonly IPptConsigneeRepository _dataRepository;
        /// <summary>
        /// 收货人域服务接口
        /// </summary>
        private readonly IPptConsigneeManager _manager;
        /// <summary>
        /// 微服务Uri接口
        /// </summary>
        private readonly IOptions<ServiceUri> _options;
        /// <summary>
        /// 消息队列
        /// </summary>
        private readonly ICapPublisher _capPublisher;

        /// <summary>
        /// 初始化
        /// </summary>
        public PptConsigneeAppService(IRepository<Ppt_Consignee, string> repository, 
            IPptConsigneeRepository dataRepository,
            IOptions<ServiceUri> options,
            ICapPublisher capPublisher,
            IPptConsigneeManager manager) : base(repository)
        {
            _dataRepository = dataRepository;
            _options = options;
            _capPublisher = capPublisher;
            _manager = manager;
        }
        #endregion

        #region 新增收货人
        /// <summary>
        /// 新增收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<bool> CreatePptConsigneeAsync(Ppt_Consignee_AppCreateInputDto input)
        {
            try
            {
                string errMsg = await _manager.CreateValidateAsync(input);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    throw new Exception(errMsg);
                }
                var result = await base.Create(input);

                //日志
                var queueLog = QueueUtils.BuildQueueLog(LogType.OPERATION, string.Format($"收货人 {input.Consigneename}"), input.OperaterUserId, input.OperaterUserName, input.TenantId, result.Id, input.Warehouseid, OperationType.CREATE, TitleType.CREATE, input.Systemtype);
                await _capPublisher.PublishAsync(CapQueueName.Log_Basis, queueLog);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 删除收货人
        /// <summary>
        /// 删除收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task Delete(Ppt_Consignee_AppDeleteInputDto input)
        {
            try
            {
                var dataEntity = await _dataRepository.SingleAsync(d => d.Id == input.Id);
                await base.Delete(input);

                //日志
                var queueLog = QueueUtils.BuildQueueLog(LogType.OPERATION, string.Format($"客户 {dataEntity.Consigneename}"), input.OperaterUserId, input.OperaterUserName, input.TenantId, dataEntity.Id, input.WarehouseId, OperationType.DELETE, TitleType.DELETE, input.Systemtype);
                await _capPublisher.PublishAsync(CapQueueName.Log_Basis, queueLog);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 修改收货人
        /// <summary>
        /// 修改收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Ppt_Consignee_AppOutputDto> Update(Ppt_Consignee_AppUpdateInputDto input)
        {
            try
            {
                string errMsg = await _manager.UpdateValidateAsync(input);
                if (!string.IsNullOrWhiteSpace(errMsg))
                {
                    throw new Exception(errMsg);
                }
                var result = await base.Update(input);

                //日志
                var queueLog = QueueUtils.BuildQueueLog(LogType.OPERATION, string.Format($"客户 {input.Consigneename}"), input.OperaterUserId, input.OperaterUserName, input.TenantId, input.Id, input.Warehouseid, OperationType.UPDATE, TitleType.MODIFY, input.Systemtype);
                await _capPublisher.PublishAsync(CapQueueName.Log_Basis, queueLog);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 获取收货人
        /// <summary>
        /// 获取收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public override async Task<Ppt_Consignee_AppOutputDto> Get(Ppt_Consignee_AppGetInputDto input)
        {
            try
            {
                var result = await base.Get(input);

                var client = new HttpApiClient(_options.Value.AddressUri);
                var addressService = client.Create<IAddressInterface>();
                var client1 =await addressService.GetAllAddressList(result.Province, result.City, result.Area);
                result.AllAddress = JsonUtils.DeserializeNezadaJsonDto<NezadaAddress>(client1);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 查询收货人
        /// <summary>
        /// 查询收货人
        /// </summary>
        /// <param name="input">条件参数</param>
        /// <returns></returns>
        public async Task<PaginatedList<Ppt_Consignee_AppOutputDto>> GetAllListAsync(Ppt_Consignee_AppGetAllInputDto input)
        {
            try
            {
                string dto = JsonUtils.SerializeObject(input);
                var result = await _dataRepository.GetPptConsigneeOutputListAsync(dto);
                var dataOutputList = Mapper.Map<List<Ppt_Consignee_AppOutputDto>>(result.DataSource);

                return new PaginatedList<Ppt_Consignee_AppOutputDto>(input.PageNo, input.PageSize, result.TotalCount, dataOutputList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 查询收货人（用于下拉）
        /// <summary>
        /// 查询收货人（用于下拉）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<List<SelectedItem>> GetConsigneeSelectedItemListAsync(Ppt_Consignee_AppGetTreeInputDto input)
        {
            try
            {
                string dto = JsonUtils.SerializeObject(input);
                var result = await _dataRepository.GetPptConsigneeOutputListAsync(dto);
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
    }
}
