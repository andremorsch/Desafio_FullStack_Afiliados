using BackEnd.Data;
using BackEnd.Enumerators;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics;

namespace BackEnd.Controllers
{
    [ApiController]
    public class AffiliateController : ControllerBase
    {
        [HttpPost("v1/processFile/")]
        public async Task<IActionResult> ProcessFile(
            [FromForm] TextFile file,
            [FromServices] AffiliateDataContext context)
        {
            if (file?.File != null)
            {
                var response = await FileService.ProcessFile(file, context);

                if (response.Success != EnumSuccess.TOTAL_FAILURE)
                    return Ok();

                return BadRequest("Nenhuma linha foi válida");
            }

            return BadRequest("Nenhum arquivo enviado");
        }
    }
}
