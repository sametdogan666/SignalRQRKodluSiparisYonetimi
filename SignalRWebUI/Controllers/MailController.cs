using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.ViewModels.MailViewModels;

namespace SignalRWebUI.Controllers;

public class MailController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(CreateMailViewModel createMailViewModel)
    {
        MimeMessage mimeMessage = new MimeMessage();

        MailboxAddress mailboxAddressFrom = new MailboxAddress("SignalR Rezervasyon", "s.doqann1570@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailViewModel.ReceiverMail);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = createMailViewModel.Body;
        mimeMessage.Body = bodyBuilder.ToMessageBody();

        mimeMessage.Subject = createMailViewModel.Subject;

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Connect("smtp.gmail.com", 587, false);
        smtpClient.Authenticate("s.doqann1570@gmail.com", "wnxc jqzm eywj bups");

        smtpClient.Send(mimeMessage);
        smtpClient.Disconnect(true);


        return RedirectToAction("Index", "Category");
    }
}