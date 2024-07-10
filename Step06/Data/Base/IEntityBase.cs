namespace eTickets.Data.Base
{
    // 30
    // Tüm modellerimizde ortak olan property leri burada toplayalım. Şu anki durumda en ortak olan property Id propertysi
    public interface IEntityBase
    {
        int Id { get; set; }
    }
}
