using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccess.Concrete;

namespace SignalRApi.Hubs;

//Hub sınıfı bir sunucu görevi görüyor. Dağıtım işlemleri buradan yapılır
public class SignalRHub : Hub
{
    SignalRContext _context = new SignalRContext();

    public async Task SendCategoryCount()
    {
        var results = _context.Categories.Count();
        await Clients.All.SendAsync("ReceiveCategoryCount", results);
    }
}