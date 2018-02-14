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
        private readonly IRepository<ApplicationUser, long> _userRepository;

        public ApplicationUserService(IRepository<ApplicationUser, long> userrepository)
        {
            _userRepository = userrepository;
        }

        public PaginatedList<ApplicationUser> GetApplicationUserList()
        {

            var query = _userRepository.TableNoTracking;

            var allUser = query.ToList();

            return new PaginatedList<ApplicationUser>(allUser, allUser.Count, 1, allUser.Count);
        }
    }
}