using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ixq.Soft.Core;
using Ixq.Soft.Core.Extensions;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Ixq.Soft.Services.Identity
{
    public class ApplicationUserService : BaseService, IApplicationUserService
    {
        private readonly IRepositoryInt64<ApplicationUser> _userRepository;

        public ApplicationUserService(IRepositoryInt64<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public PagingList<ApplicationUser> GetApplicationUserList(DataRequestModel requestModel)
        {
            var query = _userRepository.TableNoTracking;

            if (!string.IsNullOrEmpty(requestModel.SortField))
            {
                query = requestModel.ListSortDirection == System.ComponentModel.ListSortDirection.Ascending
                    ? query.OrderBy(requestModel.SortField)
                    : query.OrderByDescending(requestModel.SortField);
            }

            return query.PagingList(requestModel.PageIndex, requestModel.PageSize);
        }
    }
}