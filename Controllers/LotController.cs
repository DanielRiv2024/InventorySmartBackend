﻿using InventorySmart.Interface;
using InventorySmart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace InventorySmart.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LotController : ControllerBase
    {
        private readonly ILot _lotService;

        public LotController(ILot lotService)
        {
            _lotService = lotService;
        }
        [HttpGet("GetLots")]
        public IActionResult Get()
        {
            try
            {
                List<Lot> lots = _lotService.GetAllLots().Result;

                return Ok(lots);
            }
            catch (Exception ex)
            {
                {
                    return BadRequest($"Error en la conexión: {ex.Message}");
                }
            }
        }
        [HttpGet("GetLotsByIdProduct/{idProduct}")]
        public IActionResult GetByIdProduct(int idProduct)
        {
            try
            {
                List<Lot> lots = _lotService.GetLotsByProductId(idProduct).Result;

                return Ok(lots);
            }
            catch (Exception ex)
            {
                {
                    return BadRequest($"Error en la conexión: {ex.Message}");
                }
            }
        }
        [HttpPost("CreateLot")]
        public async Task<IActionResult> CreateLot([FromBody] Lot lot)
        {
            try
            {
                Lot createdLot = await _lotService.CreateLot(lot);
                return Ok(createdLot);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el lote: {ex.Message}");
            }
        }

        [HttpPut("UpdateLot")]
        public async Task<IActionResult> UpdateLot([FromBody] Lot lot)
        {
            try
            {
                Lot updateLot = await _lotService.UpdateLot (lot);
                return Ok(updateLot);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el lote: {ex.Message}");
            }
        }

        [HttpDelete("DeleteLot/{lotId}")]
        public async Task<IActionResult> DeleteLot(int lotId)
        {
            try
            {

                bool isDeleted = await _lotService.DeleteLot(lotId);

                if (isDeleted)
                {
                    return Ok($"Lote con ID {lotId} eliminado correctamente.");
                }
                else
                {
                    return NotFound($"No se encontró el lote con ID {lotId}.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el lote: {ex.Message}");
            }
        }

        [HttpGet("GetLotById/{lotId}")]
        public IActionResult GetLotById(int lotId)
        {
            try
            {
                Lot lot = _lotService.GetLotById(lotId).Result;

                if (lot != null)
                {
                    return Ok(lot);
                }
                else
                {
                    return NotFound($"No se encontró el lote con ID {lotId}.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error en la conexión: {ex.Message}");
            }
        }

    }

    
}
