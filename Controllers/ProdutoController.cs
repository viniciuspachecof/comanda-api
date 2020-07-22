using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiComanda.Data;
using ApiComanda.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProdutoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            try
            {
                var result = await _repo.GetAllProdutosAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{produtoId}")]
        public async Task<IActionResult> GetByProdutoId(int produtoId)
        {
            try
            {
                var result = await _repo.GetProdutoAsyncById(produtoId, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        } 
    }
}