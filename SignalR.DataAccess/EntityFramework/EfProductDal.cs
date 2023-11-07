using Microsoft.EntityFrameworkCore;
using SignalR.DataAccess.Abstract;
using SignalR.DataAccess.Concrete;
using SignalR.DataAccess.Repositories;
using SignalR.Dto.ProductDto;
using SignalR.Entities.Entities;

namespace SignalR.DataAccess.EntityFramework;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    public EfProductDal(SignalRContext context) : base(context)
    {
    }

    //public List<Product> GetProductsWithCategory()
    //{
    //    var context = new SignalRContext();
    //    var results = context.Products.Include(x=>x.Category).ToList();

    //    return results;
    //}

    public List<ResultProductWithCategoryDto> GetProductsWithCategory()
    {
        using var context = new SignalRContext();
        var results = context.Products
            .Include(x => x.Category)
            .Select(x => new ResultProductWithCategoryDto
            {
                Id = x.Id,
                ProductName = x.ProductName,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Status = x.Status,
                CategoryName = x.Category.CategoryName
            })
            .ToList();

        return results;
    }
}