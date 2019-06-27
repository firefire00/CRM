using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using ZiytekWMSPlatform.CRM.EntityFrameworkCore;

namespace ZiytekWMSPlatform.CRM.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class CRMRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<CRMDbContext, TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
    {
        protected CRMRepositoryBase(IDbContextProvider<CRMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        // Add your common methods for all repositories
        /// <summary>
        /// 新增列表
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="entityList">Entity list</param>
        /// <returns></returns>
        public async virtual Task<bool> InsertAsync<T>(List<T> entityList) where T : class
        {
            try
            {
                await Context.AddRangeAsync(entityList);

                var result = await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
