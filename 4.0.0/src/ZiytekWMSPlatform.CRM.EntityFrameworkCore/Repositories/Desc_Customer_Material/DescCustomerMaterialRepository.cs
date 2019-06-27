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
    /// 客户-物资仓储
    /// </summary>
    public class DescCustomerMaterialRepository : CRMRepositoryBase<Desc_Customer_Material, string>, IDescCustomerMaterialRepository
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="dbContextProvider"></param>
        public DescCustomerMaterialRepository(IDbContextProvider<CRMDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        #region 查询客户-物资列表
        /// <summary>
        /// 查询客户-物资列表
        /// </summary>
        /// <param name="dto">条件参数json</param>
        /// <returns></returns>
        public async Task<PaginatedList<Desc_Customer_Material_OutputDto>> GetDescCustomerMaterialOutputListAsync(string dto)
        {
            try
            {
                Desc_Customer_Material_InputDto inputDto = JsonUtils.DeserializeObject<Desc_Customer_Material_InputDto>(dto);
                IQueryable<Desc_Customer_Material> query = GetAll();
                if (!string.IsNullOrWhiteSpace(inputDto.Id))
                {
                    query = query.Where(d => d.Id == inputDto.Id);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Customerid))
                {
                    query = query.Where(d => d.Customerid == inputDto.Customerid);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Materialid))
                {
                    query = query.Where(d => d.Materialid == inputDto.Materialid);
                }
                if (!string.IsNullOrWhiteSpace(inputDto.Warehouseid))
                {
                    query = query.Where(d => d.Warehouseid == inputDto.Warehouseid);
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

                                 select new Desc_Customer_Material_OutputDto
                                 {
                                     Id = q.Id,
                                     Customerid = q.Customerid,
                                     Materialid = q.Materialid,
                                     Warehouseid = q.Warehouseid,
                                     TenantId = q.TenantId,
                                     CreatorUserId = q.CreatorUserId,
                                     CreationTime = q.CreationTime,
                                     LastModifierUserId = q.LastModifierUserId,
                                     LastModificationTime = q.LastModificationTime
                                 };
                int totalCount = await filterList.Distinct().CountAsync();
                var resultList = new List<Desc_Customer_Material_OutputDto>();
                if (inputDto.PageNo * inputDto.PageSize > 0)
                {
                    resultList = await filterList.Distinct().OrderByDescending(d => d.LastModificationTime).Skip((inputDto.PageNo - 1) * inputDto.PageSize).Take(inputDto.PageSize).ToListAsync();
                }
                else
                {
                    resultList = await filterList.Distinct().OrderByDescending(d => d.LastModificationTime).ToListAsync();
                }
                return new PaginatedList<Desc_Customer_Material_OutputDto>(inputDto.PageNo, inputDto.PageSize, totalCount, resultList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 批量保存客户物资关系
        /// <summary>
        /// 批量保存客户物资关系
        /// </summary>
        /// <param name="desc_Customer_MaterialList"></param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(List<Desc_Customer_Material> desc_Customer_MaterialList)
        {
            try
            {
                var result = await base.InsertAsync(desc_Customer_MaterialList);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region 判断是否存在对应的客户物资关系
        /// <summary>
        /// 判断是否存在对应的客户物资关系
        /// </summary>
        /// <param name="warehouseid"></param>
        /// <param name="tenantId"></param>
        /// <param name="customerid"></param>
        /// <param name="materialId"></param>
        /// <returns></returns>
        public async Task<bool> GetDescCustomerMaterialOutputInfoAsync(string warehouseid, string tenantId, string customerid, string materialId)
        {
            try
            {
                IQueryable<Desc_Customer_Material> query = GetAll();

                if (!string.IsNullOrWhiteSpace(customerid))
                {
                    query = query.Where(d => d.Customerid == customerid);
                }
                if (!string.IsNullOrWhiteSpace(materialId))
                {
                    query = query.Where(d => d.Materialid == materialId);
                }
                if (!string.IsNullOrWhiteSpace(warehouseid))
                {
                    query = query.Where(d => d.Warehouseid == warehouseid);
                }
                if (!string.IsNullOrWhiteSpace(tenantId))
                {
                    query = query.Where(d => d.TenantId == tenantId);
                }

                var filterList = from q in query


                                 select new Desc_Customer_Material_OutputDto
                                 {
                                     Id = q.Id,
                                     Customerid = q.Customerid,
                                     Materialid = q.Materialid,
                                     Warehouseid = q.Warehouseid,
                                     TenantId = q.TenantId,
                                     CreatorUserId = q.CreatorUserId,
                                     CreationTime = q.CreationTime,
                                     LastModifierUserId = q.LastModifierUserId,
                                     LastModificationTime = q.LastModificationTime
                                 };
                int totalCount = await filterList.Distinct().CountAsync();

                return totalCount > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
