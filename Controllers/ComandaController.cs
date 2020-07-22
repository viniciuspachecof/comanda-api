// FAZER IMPORTAÇÕES

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiComanda.Data;
using ApiComanda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiComanda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComandaController : ControllerBase
    {
        private readonly IRepository _repo;

        public ComandaController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comanda>>> Get()
        {
            try
            {
                var result = await _repo.GetAllComandasAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{comandaId}")]
        public async Task<IActionResult> GetByComandaId(int comandaId)
        {
            try
            {
                var result = await _repo.GetComandaAsyncById(comandaId, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Comanda model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro:  {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{comandaId}")]
        public async Task<IActionResult> put(int comandaId, Comanda model)
        {
            try
            {
                var comanda = await _repo.GetComandaAsyncById(comandaId, false);
                if(comanda == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
    }
}