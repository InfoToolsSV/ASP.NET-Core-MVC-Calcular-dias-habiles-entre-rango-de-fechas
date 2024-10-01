using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BusinessDays.Models;

namespace BusinessDays.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var model = new DateRangeViewModel
        {
            StartDate = DateTime.Today,
            EndDate = DateTime.Today,
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(DateRangeViewModel model)
    {
        if (ModelState.IsValid)
            model.BusinessDays = CalculateBusinessDays(model.StartDate, model.EndDate);

        return View(model);
    }

    private int CalculateBusinessDays(DateTime startDate, DateTime endDate)
    {
        int businessDays = 0;

        for (var date = startDate; date <= endDate; date = date.AddDays(1))
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                businessDays++;
            }
        }
        return businessDays;
    }
}
