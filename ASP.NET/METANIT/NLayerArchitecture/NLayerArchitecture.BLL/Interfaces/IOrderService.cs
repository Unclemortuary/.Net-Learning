using System.Collections.Generic;
using NLayerArchitecture.BLL.DTO;

namespace NLayerArchitecture.BLL.Interfaces
{
    public interface IOrderService
    {
        void MakeOrder(OrderDTO orderDto);
        PhoneDTO GetPhone(int? id);
        IEnumerable<PhoneDTO> GetPhones();
        void Dispose();
    }
}
