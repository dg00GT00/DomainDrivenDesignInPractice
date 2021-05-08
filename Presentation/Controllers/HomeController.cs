using System.Diagnostics;
using Domain.SnackMachine;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    [ValidateAntiForgeryToken]
    public class HomeController : Controller
    {
        private readonly SnackMachine _snackMachine;

        public HomeController(SnackMachine snackMachine)
        {
            _snackMachine = snackMachine;
        }

        [IgnoreAntiforgeryToken]
        public IActionResult Index()
        {
            return View(new SnackModel
            {
                Machine = _snackMachine,
                Message = "You have inserted: None"
            });
        }

        [HttpPost]
        public IActionResult Insert(decimal value)
        {
            Money money = Money.None;
            if (value == Money.Cent.Amount)
            {
                money = Money.Cent;
            }

            else if (value == Money.Quarter.Amount)
            {
                money = Money.Quarter;
            }

            else if (value == Money.TenCent.Amount)
            {
                money = Money.TenCent;
            }

            else if (value == Money.Dollar.Amount)
            {
                money = Money.Dollar;
            }

            else if (value == Money.FiveDollar.Amount)
            {
                money = Money.FiveDollar;
            }

            else if (value == Money.TwentyDollar.Amount)
            {
                money = Money.TwentyDollar;
            }

            _snackMachine.InsertMoney(money);
            return View("Index", new SnackModel {Machine = _snackMachine, Message = $"You have inserted: {money}"});
        }

        [HttpPost]
        public IActionResult ReturnMoney()
        {
            _snackMachine.ReturnMoney();
            return View("Index", new SnackModel {Machine = _snackMachine, Message = "The money was returned"});
        }

        [HttpPost]
        public IActionResult Buy()
        {
            _snackMachine.BuySnack();
            return View("Index",
                new SnackModel
                    {Machine = _snackMachine, Message = "Congratulations you have just brought a delicious snack!"});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}