using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiComanda.Data;
using ApiComanda.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCategoria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IRepository _repo;

        public CategoriaController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            try
            {
                var result = await _repo.GetAllCategoriasAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{categoriaId}")]
        public async Task<IActionResult> GetByCategoriaId(int categoriaId)
        {
            try
            {
                var result = await _repo.GetCategoriaAsyncById(categoriaId);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        } 
    }
}