using newLife.Models;

namespace newLife.DataAccess.Repositry.IRepositry
{
    public interface IOrderHeaderRepositry : IRepositry<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);



    }
}
