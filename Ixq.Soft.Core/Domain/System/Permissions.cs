namespace Ixq.Soft.Core.Domain.System
{
    public class Permissions : EntityBase
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Link { get; set; }
    }
}