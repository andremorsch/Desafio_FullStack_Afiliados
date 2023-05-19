using BackEnd.Data;
using BackEnd.Enumerators;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics;

namespace BackEnd.Controllers
{
    [ApiController]
    public class AffiliateController : ControllerBase
    {
        [HttpPost("v1/file")]
        public async Task<IActionResult> ProcessFile(
            [FromForm] TextFile file,
            [FromServices] AffiliateDataContext context)
        {
            if (file?.File != null)
            {
                var response = await FileService.ProcessFile(file, context);

                if (response.Success == EnumSuccess.TOTAL_SUCCESS)
                    return Ok(response);

                if (response.Success == EnumSuccess.PARTIAL_SUCCESS)
                    return StatusCode(206, response);

                return BadRequest(response);
            }

            return BadRequest("Nenhum arquivo enviado");
        }

        [HttpGet("v1/files")]
        public async Task<IActionResult> GetAll(
            [FromServices] AffiliateDataContext context)
        {
            try
            {
                var result = await context.AffiliateData.ToListAsync();

                if (result.Count == 0)
                    return NotFound("Nenhum arquivo encontrado");

                return Ok(result);
            }
            catch
            {
                return BadRequest("Erro ao buscar dados no banco de dados");
            }
        }
    }
}
