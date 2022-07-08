using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAxiaMarket1.Models;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAxiaMarket1.Shared;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace MyAxiaMarket1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanierController : ControllerBase
    {
        private readonly IPanierRepository _repository;
        public PanierController(IPanierRepository repository)
        {
            _repository = repository;
        }
        [Authorize]
        [HttpPost("InsertPanier")]
        public async Task<ActionResult<GetOneResult<Panier>>> AddPanier(PanierVM panier)
        {
            var result = new GetOneResult<Panier>();
            if (ModelState.IsValid)
            {
                try
                {
                    var pan = new Panier()
                    {
                        description = panier.description,
                        NomPanier = panier.NomPanier,
                        Reference = panier.Reference,
                        status = panier.status,
                        visitorId = panier.visitorId,
                        valide = panier.valide,
                        Articles = panier.Articles
                    };
                    var res = await _repository.InsertOneAsync(pan);
                    if (res.Success)
                    {
                        result.Success = true;
                        result.Entity = pan;
                    }
                    return Ok(result);
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = "unexpected error has occured " + e.Message + e.StackTrace;
                }
                
            }
            return BadRequest(result);
        }
        [Authorize]
        [HttpGet("GetListPaniers")]
        public async Task<ActionResult<GetManyResult<Panier>>> GetListPaniers()
        {
            var result = new GetManyResult<Panier>() { Success = false };
            try
            {

                return await _repository.GetAllAsync();
            }
            catch (Exception e)
            {
                result.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return result;
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetOneResult<Panier>>> GetPanierById([FromQuery] int id)
        {
            var restoreturn = new GetOneResult<Panier>() { Success = false };
            try
            {
                return await _repository.GetPanierByIdAsync(id);

            }
            catch (Exception e)
            {
                restoreturn.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return restoreturn;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<GetOneResult<Panier>> DeletePanier(int id)
        {
            var res = new GetOneResult<Panier>() { Success = false };
            try
            {
                if (id > 0)
                {
                    var result = await _repository.DeleteByIdAsync(id);
                    if (result.Success)
                    {
                        result.Success = true;
                        res.Message = "Data Removed successfully !";
                    }
                }

                return res;
            }
            catch (Exception e)
            {
                res.Message = "unexpected error occured :" + e.Message + e.StackTrace;
                return res;
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<GetOneResult<Panier>>> UpdatePanier(int id, PanierVM panier)
        {
            var res = new GetOneResult<Panier>() { Success = false };
            try
            {
                if (ModelState.IsValid )
                {
                    var pan = new Panier()
                    {
                        description = panier.description,
                        NomPanier = panier.NomPanier,
                        Reference = panier.Reference,
                        status = panier.status,
                        visitorId = panier.visitorId,
                        valide = panier.valide
                    };
                    var result = await _repository.UpdatePanierAsync(pan, id);

                    if (result.Success)
                    {
                        res.Success = true;
                        res.Message = "data updated !";
                    }
                }
                return res;
            }
            catch (Exception e)
            {
                res.Success = false;
                res.Message = "error occured !" + e.Message + e.StackTrace;
                return res;
            }
        }
    }
}
