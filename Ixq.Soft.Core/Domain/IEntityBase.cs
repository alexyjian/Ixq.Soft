namespace Ixq.Soft.Core.Domain
{
    public interface IEntityBase<TKey>
    {
        TKey Id { get; set; }
        string SoteCode { get; set; }
    }
}