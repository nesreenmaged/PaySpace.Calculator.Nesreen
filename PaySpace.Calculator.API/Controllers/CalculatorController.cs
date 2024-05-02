using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Services.Abstractions.Calculators;
using PaySpace.Calculator.Shared.DTOs;

namespace PaySpace.Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public sealed class CalculatorController(
        ILogger<CalculatorController> logger,
        ICalculatorHistoryService historyService,
        ITaxCalculatorsMainService taxCalculatorsMainService,
        IPostalCodeService postalCodeService,
        IMapper mapper)
        : ControllerBase
    {
        [HttpPost("calculate-tax")]
        public async Task<ActionResult<CalculateResultDto>> Calculate(CalculateRequestDto request)
        {
            try
            {
                if (request != null)
                {
                    var result = await taxCalculatorsMainService.Calculate(request);
                    await historyService.AddAsync(new CalculatorHistoryDto
                    {
                        Timestamp = DTOHelper.GetDateTimeNow(),
                        Tax = result.Tax,
                        Calculator = result.Calculator.ToString(),
                        PostalCode = request.PostalCode ?? "Unknown",
                        Income = request.Income
                    });

                    return this.Ok(mapper.Map<CalculateResultDto>(result));
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, e.Message);
                return this.BadRequest(e.Message);
            }
        }

        [HttpGet("history")]
        public async Task<ActionResult<List<CalculatorHistoryDto>>> History()
        {
            var history = await historyService.GetAllAsync();
            return this.Ok(mapper.Map<List<CalculatorHistoryDto>>(history));
        }


        [HttpGet("posta1code")]
        public async Task<ActionResult<List<PostalCodeDto>>> Posta1Code()
        {
            var postalCodes = await postalCodeService.GetAllAsync();
            return this.Ok(mapper.Map<List<PostalCodeDto>>(postalCodes));
        }



    }
}