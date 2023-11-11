using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Dto.BasketDto;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfBasketDal : GenericRepository<Basket>, IBasketDal
{
    public EfBasketDal(SignalRContext context) : base(context)
    {
    }

    public List<Basket> GetBasketByMenuTableNumber(int id)
    {
        using var context = new SignalRContext() ;

        var results = context.Baskets.Where(x => x.MenuTableId == id).Include(y=>y.Product).ToList();

        return results;
    }

    public List<ResultBasketWithProductDto> GetBasketListByMenuTableWithProductName(int id)
    {
        using var context = new SignalRContext() ;

        var results = context.Baskets.Where(x => x.MenuTableId == id).Include(y=>y.Product).Select(x=> new ResultBasketWithProductDto
        {
            Id = x.Id,
            ProductName = x.Product.ProductName,
            Count = x.Count,
            Price = x.Price,
            TotalPrice = x.TotalPrice,
            MenuTableId = x.MenuTableId
        }).ToList();

        return results;
    }
}
