using System.Linq.Expressions;

namespace newLife.DataAccess.Repositry.IRepositry
{
    public interface IRepositry<T> where T : class
    {
        //T Category
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
