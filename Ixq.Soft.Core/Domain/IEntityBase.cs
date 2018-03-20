namespace Ixq.Soft.Core.Domain
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string SoteCode { get; set; }
    }
}