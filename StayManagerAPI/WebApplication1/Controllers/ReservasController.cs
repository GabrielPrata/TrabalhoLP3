using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayManager.Core.Interfaces;
using StayManager.Data.DTO;

namespace StayManager.API.Controllers
{
    public class ReservasController : ControllerBase
    {
        private readonly IFazerReservaService _reservaService;

        public ReservasController(IFazerReservaService reservaService)
        {
            _reservaService = reservaService;
        }


        [HttpPost]
        [Route("FazerReserva")]
        [AllowAnonymous]
        public async Task<IActionResult> FazerReserva(ReservaDTO reserva)
        {
            try
            {
                await _reservaService.SalvarReserva(reserva);

                return Ok();

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("DeletarReserva/{reservaId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeletarReserva(int reservaId)
        {
            try
            {
                await _reservaService.DeletarReserva(reservaId);

                return Ok();

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("ListarReservas")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ReservaDTO>>> ListarReservas()
        {
            try
            {
                var reservas = await _reservaService.ListarReservas();

                return Ok(reservas);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
