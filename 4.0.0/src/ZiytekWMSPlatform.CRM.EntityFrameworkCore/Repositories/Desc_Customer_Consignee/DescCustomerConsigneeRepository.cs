using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nezada.Common.Utils;
using Nezada.Common.Abp.Entity;
using ZiytekWMSPlatform.CRM.Entities;
using ZiytekWMSPlatform.CRM.IRepositories;
using ZiytekWMSPlatform.CRM.EntityFrameworkCore;

namespace ZiytekWMSPlatform.CRM.Repositories
{
    /// <summary>
    /// 客户-收货人仓储
    /// </summary>
    public class DescCustomerConsigneeRepository : CRMRepositoryBase<Desc_Customer_Consignee, string>, IDescCustomerConsigneeRepository
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbContextProvider"></param>
        public DescCustomerConsigneeRepository(IDbContextProvider<CRMDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        #region 查询客户-收货人列表
        /// <summary>
        /// 查询客户-收货人列表
        /// </summary>
        /// <param name="dto">条件参数json</param>
        /// <returns></returns>
        public async Task<PaginatedList<Desc_Customer_Consignee_OutputDto>> GetDescCustomerConsigneeOutputListAsync(string dto)
        {
            try
            {
                Desc_Customer_Consignee_InputDto inputDto = JsonUtils.DeserializeObject<Desc_Customer_Consignee_InputDto>(dto);
                IQueryable<Desc_Customer_Consignee> query = GetAll();
                if (!string.IsNullOrWhiteSpace(inputDto.Id))
                {
                    query = query.Where(d => d.Id == inputDto.Id);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Customerid))
                {
                    query = query.Where(d => d.Customerid == inputDto.Customerid);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Consigneeid))
                {
                    query = query.Where(d => d.Consigneeid == inputDto.Consigneeid);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.TenantId))
                {
                    query = query.Where(d => d.TenantId == inputDto.TenantId);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.CreatorUserId))
                {
                    query = query.Where(d => d.CreatorUserId == inputDto.CreatorUserId);
                }
                if (inputDto.CreationTime != null)
                {
                    query = query.Where(d => d.CreationTime == inputDto.CreationTime);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.LastModifierUserId))
                {
                    query = query.Where(d => d.LastModifierUserId == inputDto.LastModifierUserId);
                }
                if (inputDto.LastModificationTime != null)
                {
                    query = query.Where(d => d.LastModificationTime == inputDto.LastModificationTime);
                }
                var filterList = from q in query
                                 select new Desc_Customer_Consignee_OutputDto
                                 {
                                     Id = q.Id,
                                     Customerid = q.Customerid,
                                     Consigneeid = q.Consigneeid,
                                     TenantId = q.TenantId,
                                     CreatorUserId = q.CreatorUserId,
                                     CreationTime = q.CreationTime,
                                     LastModifierUserId = q.LastModifierUserId,
                                     LastModificationTime = q.LastModificationTime
                                 };
                int totalCount = await filterList.Distinct().CountAsync();
                var resultList = new List<Desc_Customer_Consignee_OutputDto>();
                if (inputDto.PageNo * inputDto.PageSize > 0)
                {
                    resultList = await filterList.Distinct().OrderByDescending(d => d.LastModificationTime).Skip((inputDto.PageNo - 1) * inputDto.PageSize).Take(inputDto.PageSize).ToListAsync();
                }
                else
                {
                    resultList = await filterList.Distinct().OrderByDescending(d => d.LastModificationTime).ToListAsync();
                }
                return new PaginatedList<Desc_Customer_Consignee_OutputDto>(inputDto.PageNo, inputDto.PageSize, totalCount, resultList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 新增客户-收货人
        /// <summary>
        /// 新增客户-收货人
        /// </summary>
        /// <param name="dataEntityList">客户-收货人列表</param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(List<Desc_Customer_Consignee> dataEntityList)
        {
            try
            {
                var result = await base.InsertAsync(dataEntityList);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
