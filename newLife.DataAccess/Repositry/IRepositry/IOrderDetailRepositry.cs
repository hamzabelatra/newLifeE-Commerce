using newLife.Models;

namespace newLife.DataAccess.Repositry.IRepositry
{
    public interface IOrderDetailRepositry : IRepositry<OrderDetail>
    {
        void Update(OrderDetail obj);


    }
}
