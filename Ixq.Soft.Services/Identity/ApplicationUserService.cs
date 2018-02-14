using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ixq.Soft.Core.Domain.Identity;
using Ixq.Soft.Core.Infrastructure;
using Ixq.Soft.Repository;
using Microsoft.AspNetCore.Http;

namespace Ixq.Soft.Services.Identity
{
    public class ApplicationUserService : BaseService, IApplicationUserService
    {
        private readonly IRepositoryInt64<ApplicationUser> _userRepository;

        public ApplicationUserService(IRepositoryInt64<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public PaginatedList<ApplicationUser> GetApplicationUserList()
        {
            var query = _userRepository.TableNoTracking;

            var allUser = query.ToList();

            return new PaginatedList<ApplicationUser>(allUser, allUser.Count, 1, allUser.Count);
        }
    }
}