using TestTaskSupportDashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace TestTaskSupportDashboard.Controllers
{
    public class TicketController : Controller
    {
        MessageContext db;
        public TicketController(MessageContext context)
        {
            db = context;
        }

        [HttpGet]
        [Authorize(Roles = "guest, observer, supportoperator")]
        [Route("tickets/")]
        public IActionResult TicketsList()
        {
            var result = db.Messages.Select(m => m.ChatId).Distinct().ToList();
            return View(result);
        }

        [HttpGet]
        [Authorize(Roles = "observer, supportoperator")]
        [Route("tickets/{chatId?}")]
        public IActionResult Ticket(string chatId)
        {
            if (chatId != null)
            {
                var ticket = db.Messages.Where(m => m.ChatId == chatId);
                ViewBag.ChatId = chatId;
                ViewBag.IsRead = false;
                ViewBag.Date = System.DateTime.Now;
                ViewBag.Type = Enums.SenderType.SupportOperator;
                return View(ticket);
            }
            return View();
        }
        [HttpPost]
        [Route("tickets/{chatId?}")]
        public IActionResult Ticket(Message message)
        {
            if (message != null)
            {
                db.Messages.Add(message);
                db.SaveChanges();
            }
            return RedirectToPage("/tickets/" + message.ChatId);
        }
    }
}
