namespace IdentityService.Domain.Abstractions
{
    public class Entity<T> : IEntity<T>
    {
        public T Id { get; set; } = default!;
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
