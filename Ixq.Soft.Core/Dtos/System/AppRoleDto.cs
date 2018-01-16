using Ixq.Soft.Core.Dtos.Base;
using Ixq.Soft.Entities.System;
using Ixq.UI.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Ixq.Soft.Core.Dtos.System
{
    [Page(DefaultSortname = nameof(SoteCode), Title = "系统角色", MultiSelect = true, MultiBoxOnly = true,
        ShowRowNumber = true)]
    public class AppRoleDto : DtoBaseLong<AppRole>
    {
        [Required]
        [Display(Name = "角色名称", Order = 1)]
        [ColModel(Sortable = true)]
        public string Name { get; set; }

        [Display(Name = "角色描述", Order = 10)]
        public string Description { get; set; }

        [Display(Name = "排序码", Order = 20)]
        [ColModel(Sortable = true)]
        public string SoteCode { get; set; }
    }
}
