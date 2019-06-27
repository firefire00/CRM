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
    /// 收货人仓储
    /// </summary>
    public class PptConsigneeRepository : CRMRepositoryBase<Ppt_Consignee, string>, IPptConsigneeRepository
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbContextProvider"></param>
        public PptConsigneeRepository(IDbContextProvider<CRMDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        #region 查询收货人列表
        /// <summary>
        /// 查询收货人列表
        /// </summary>
        /// <param name="dto">条件参数json</param>
        /// <returns></returns>
        public async Task<PaginatedList<Ppt_Consignee_OutputDto>> GetPptConsigneeOutputListAsync(string dto)
        {
            try
            {
                Ppt_Consignee_InputDto inputDto = JsonUtils.DeserializeObject<Ppt_Consignee_InputDto>(dto);
                IQueryable<Ppt_Consignee> query = GetAll();
                if (!string.IsNullOrWhiteSpace(inputDto.Consigneename))
                {
                    query = query.Where(d => d.Consigneename.Contains(inputDto.Consigneename));
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Mobilephone))
                {
                    query = query.Where(d => d.Mobilephone == inputDto.Mobilephone);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Receivingunit))
                {
                    query = query.Where(d => d.Receivingunit.Contains(inputDto.Receivingunit));
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Warehouseid))
                {
                    query = query.Where(d => d.Warehouseid == inputDto.Warehouseid);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Province))
                {
                    query = query.Where(d => d.Province == inputDto.Province);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.City))
                {
                    query = query.Where(d => d.City == inputDto.City);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Area))
                {
                    query = query.Where(d => d.Area == inputDto.Area);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Detailaddress))
                {
                    query = query.Where(d => d.Detailaddress == inputDto.Detailaddress);
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
                                 select new Ppt_Consignee_OutputDto
                                 {
                                     Id = q.Id,
                                     Consigneename = q.Consigneename,
                                     Mobilephone = q.Mobilephone,
                                     Receivingunit = q.Receivingunit,
                                     Warehouseid = q.Warehouseid,
                                     Province = q.Province,
                                     City = q.City,
                                     Area = q.Area,
                                     ProvinceText = q.ProvinceText,
                                     CityText = q.CityText,
                                     AreaText = q.AreaText,
                                     Detailaddress = q.Detailaddress,
                                     TenantId = q.TenantId,
                                     CreatorUserId = q.CreatorUserId,
                                     CreationTime = q.CreationTime,
                                     LastModifierUserId = q.LastModifierUserId,
                                     LastModificationTime = q.LastModificationTime
                                 };
                int totalCount = await filterList.Distinct().CountAsync();
                var resultList = new List<Ppt_Consignee_OutputDto>();
                if (inputDto.PageNo * inputDto.PageSize > 0)
                {
                    resultList = await filterList.Distinct().OrderByDescending(d => d.LastModificationTime).Skip((inputDto.PageNo - 1) * inputDto.PageSize).Take(inputDto.PageSize).ToListAsync();
                }
                else
                {
                    resultList = await filterList.Distinct().OrderByDescending(d => d.LastModificationTime).ToListAsync();
                }
                return new PaginatedList<Ppt_Consignee_OutputDto>(inputDto.PageNo, inputDto.PageSize, totalCount, resultList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
