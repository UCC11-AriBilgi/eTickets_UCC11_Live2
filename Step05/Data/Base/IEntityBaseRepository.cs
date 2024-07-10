using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    // 31
    // Tüm metotları ortak bir yerde tutmak Generic yapıda...
    // Ortak metotlar
    public interface IEntityBaseRepository<T> where T : class, IEntityBase,new ()
    {
        // Buralarda hep metot imzaları(kendileri değil) olacak
        // Tüm bunlar Asenkron Task yapısı şeklinde tasarlanacaktır.

        // Herbir model için tüm kayıtları getiren metot.
        Task<IEnumerable<T>> GetAllAsync(); 

        // Herbir model için parametresel olarak tüm kayıtları getiren metot.Polymorphism.
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        // Tek bir kayıdı getiren metot
        Task<T> GetByIdAsync(int id);

        // Herbir model için parametresel olarak tek bir kayıdı getiren metot.Polymorphism.
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);

        //Her bir model için kayıt ekleme
        Task AddAsync(T entity);

        // Her bir model için kayıt güncelleme
        Task UpdateAsync(int id,T entity);

        // Her bir model için kayıt silme
        Task DeleteAsync(int id);
    }
}
