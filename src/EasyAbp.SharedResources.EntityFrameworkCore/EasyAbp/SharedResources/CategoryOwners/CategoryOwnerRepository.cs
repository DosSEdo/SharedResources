﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.SharedResources.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.SharedResources.CategoryOwners
{
    public class CategoryOwnerRepository : EfCoreRepository<SharedResourcesDbContext, CategoryOwner, Guid>, ICategoryOwnerRepository
    {
        public CategoryOwnerRepository(IDbContextProvider<SharedResourcesDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<long> GetCountAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            return await GetQueryable().Where(x => x.CategoryId == categoryId)
                .CountAsync(cancellationToken: cancellationToken);
        }
    }
}