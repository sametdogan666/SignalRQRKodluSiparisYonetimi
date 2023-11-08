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

    public int GetProductCount()
    {
        using var context = new SignalRContext();

        return context.Products.Count();
    }

    public int GetProductCountByCategoryNameHamburger()
    {
        using var context = new SignalRContext();

        return context.Products.Count(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(z => z.Id)
            .FirstOrDefault()));
    }

    public int GetProductCountByCategoryNameDrink()
    {
        using var context = new SignalRContext();

        return context.Products.Count(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(z => z.Id)
            .FirstOrDefault()));
    }

    public decimal GetProductPriceAvg()
    {
        using var context = new SignalRContext();

        return context.Products.Average(x => x.Price);
    }

    public string GetProductNameByMaxPrice()
    {
        using var context = new SignalRContext();

        return context.Products.Where(x=>x.Price == (context.Products.Max(y=>y.Price))).Select(z=>z.ProductName).FirstOrDefault();
    }

    public string GetProductNameByMinPrice()
    {
        using var context = new SignalRContext();

        return context.Products.Where(x => x.Price == (context.Products.Min(y => y.Price))).Select(z => z.ProductName).FirstOrDefault();
    }

    public decimal GetProductPriceByHamburgerAvg()
    {
        using var context = new SignalRContext();

        return context.Products
            .Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburger")).Select(z => z.Id)
                .FirstOrDefault()).Average(z => z.Price);
    }
}