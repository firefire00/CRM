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
    /// 客户仓储
    /// </summary>
    public class PptCustomerRepository : CRMRepositoryBase<Ppt_Customer, string>, IPptCustomerRepository
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbContextProvider"></param>
        public PptCustomerRepository(IDbContextProvider<CRMDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        #region 查询客户列表
        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="dto">条件参数json</param>
        /// <returns></returns>
        public async Task<PaginatedList<Ppt_Customer_OutputDto>> GetPptCustomerOutputListAsync(string dto)
        {
            try
            {
                Ppt_Customer_InputDto inputDto = JsonUtils.DeserializeObject<Ppt_Customer_InputDto>(dto);
                IQueryable<Ppt_Customer> query = GetAll();
                if (!string.IsNullOrWhiteSpace(inputDto.Warehouseid))
                {
                    query = query.Where(d => d.Warehouseid == inputDto.Warehouseid);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Name))
                {
                    query = query.Where(d => d.Name != null && d.Name.Contains(inputDto.Name));
                }
                if (inputDto.Sex != null)
                {
                    query = query.Where(d => d.Sex == inputDto.Sex);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Nickname))
                {
                    query = query.Where(d => d.Nickname != null && d.Nickname.Contains(inputDto.Nickname));
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Website))
                {
                    query = query.Where(d => d.Website == inputDto.Website);
                }
                if (inputDto.Ispersonal != null)
                {
                    query = query.Where(d => d.Ispersonal == inputDto.Ispersonal);
                }
                if (inputDto.Customertype != null)
                {
                    query = query.Where(d => d.Customertype == inputDto.Customertype);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Contact))
                {
                    query = query.Where(d => d.Contact == inputDto.Contact);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Postcode))
                {
                    query = query.Where(d => d.Postcode == inputDto.Postcode);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Province))
                {
                    query = query.Where(d => d.Province == inputDto.Province);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.City))
                {
                    query = query.Where(d => d.City == inputDto.City);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.District))
                {
                    query = query.Where(d => d.District == inputDto.District);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Address))
                {
                    query = query.Where(d => d.Address == inputDto.Address);
                }
                if (inputDto.Isactive != null)
                {
                    query = query.Where(d => d.Isactive == inputDto.Isactive);
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
                                 select new Ppt_Customer_OutputDto
                                 {
                                     Id = q.Id,
                                     Warehouseid = q.Warehouseid,
                                     Name = q.Name,
                                     Sex = q.Sex,
                                     Nickname = q.Nickname,
                                     Website = q.Website,
                                     Ispersonal = q.Ispersonal,
                                     Customertype = q.Customertype,
                                     Contact = q.Contact,
                                     Postcode = q.Postcode,
                                     Province = q.Province,
                                     City = q.City,
                                     District = q.District,
                                     Address = q.Address,
                                     Isactive = q.Isactive,
                                     TenantId = q.TenantId,
                                     CreatorUserId = q.CreatorUserId,
                                     CreationTime = q.CreationTime,
                                     LastModifierUserId = q.LastModifierUserId,
                                     LastModificationTime = q.LastModificationTime
                                 };
                int totalCount = await filterList.Distinct().CountAsync();
                var resultList = new List<Ppt_Customer_OutputDto>();
                if (inputDto.PageNo * inputDto.PageSize > 0)
                {
                    resultList = await filterList.Distinct().OrderByDescending(d => d.LastModificationTime).Skip((inputDto.PageNo - 1) * inputDto.PageSize).Take(inputDto.PageSize).ToListAsync();
                }
                else
                {
                    resultList = await filterList.Distinct().OrderByDescending(d => d.LastModificationTime).ToListAsync();
                }
                return new PaginatedList<Ppt_Customer_OutputDto>(inputDto.PageNo, inputDto.PageSize, totalCount, resultList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
