namespace DemoApplication.Database.Models.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
