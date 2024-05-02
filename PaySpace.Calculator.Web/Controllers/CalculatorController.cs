using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaySpace.Calculator.Shared.DTOs;
using PaySpace.Calculator.Web.Models;
using PaySpace.Calculator.Web.Services.Abstractions;

namespace PaySpace.Calculator.Web.Controllers
{
    public class CalculatorController(ICalculatorHttpService calculatorHttpService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var vm = await this.GetCalculatorViewModelAsync();

            return this.View(vm);
        }

        public async Task<IActionResult> History()
        {
            return this.View(new CalculatorHistoryViewModel
            {
                CalculatorHistory = await calculatorHttpService.GetHistoryAsync()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Index(CalculateRequestViewModel request)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await calculatorHttpService.CalculateTaxAsync(new CalculateRequestDto
                    {
                        PostalCode = request.PostalCode,
                        Income = request.Income
                    });

                    return this.RedirectToAction(nameof(this.History));
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            var vm = await this.GetCalculatorViewModelAsync(request);

            return this.View(vm);
        }

        private async Task<CalculatorViewModel> GetCalculatorViewModelAsync(CalculateRequestViewModel? request = null)
        {
            var postalCodes = await calculatorHttpService.GetPostalCodesAsync();

            return new CalculatorViewModel
            {
                PostalCodes = new SelectList(postalCodes, "Code", "Code"),
                Income = request?.Income ?? 0,
                PostalCode = request?.PostalCode ?? string.Empty
            };
        }
    }
}