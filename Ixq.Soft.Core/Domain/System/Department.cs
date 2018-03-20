namespace Ixq.Soft.Core.Domain.System
{
    public class Department : EntityBase
    {
        public virtual Department ParentDepartment { get; set; }
    }
}