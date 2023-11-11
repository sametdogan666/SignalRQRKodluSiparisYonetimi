using SignalR.Dto.BasketDto;
using SignalR.Entities.Entities;

namespace SignalR.Business.Abstract;

public interface IBasketService : IGenericService<Basket>
{
    List<Basket> GetBasketByMenuTableNumber(int id);
    List<ResultBasketWithProductDto> GetBasketListByMenuTableWithProductName(int id);
}