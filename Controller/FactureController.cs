using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAxiaMarket.Models;
using MyAxiaMarket1.CustomSpecificationPattern;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using MyAxiaMarket1.Models;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactureController : ControllerBase
    {
        private readonly IFactureRepository _repository;
        private readonly UserManager<Personne> _userManager;
        public FactureController(UserManager<Personne> userManage, IFactureRepository repository)
        {
            _userManager = userManage;
            _repository = repository;
        }

        [Authorize]
        [HttpPost("InsertFacture")]
        public async Task<ActionResult<GetOneResult<Facture>>> AddFacture(FactureVM facture)
        {
            var result = new GetOneResult<Facture>();
            if (ModelState.IsValid
                && await GlobalSpecifications.Specification(_userManager, facture.adminId)
                && await GlobalSpecifications.Specification(_userManager, facture.fourissuerId)


                )
            {
                try
                {
                    var fctr = new Facture()
                    {
                        Description = facture.Description,
                        FactureRef = facture.FactureRef,
                        status = facture.status,
                        payBefore = facture.payBefore,
                        CommandId = facture.CommandId,
                        unitprice = facture.unitprice,
                        quantity = facture.quantity,
                        currency = facture.currency,
                        taxes = facture.taxes,
                        total = facture.total,
                        adminId = facture.adminId,
                        fourissuerId = facture.fourissuerId,
                        valide = facture.valide
                    };
                    var res = await _repository.InsertOneAsync(fctr);
                    if (res.Success)
                    {
                        result.Success = true;
                        result.Entity = fctr;
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
        [HttpGet("GetListFacture")]
        public async Task<ActionResult<GetManyResult<Facture>>> GetListFacture()
        {
            var result = new GetManyResult<Facture>() { Success = false };
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
        public async Task<ActionResult<GetOneResult<Facture>>> GetFactureById([FromQuery] int id)
        {
            var restoreturn = new GetOneResult<Facture>() { Success = false };
            try
            {
                return await _repository.GetFactureByIdAsync(id);

            }
            catch (Exception e)
            {
                restoreturn.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return restoreturn;
        }
        [Authorize(Policy = "AdminPrivilege")]
        [HttpDelete("{id}")]
        public async Task<GetOneResult<Facture>> DeleteFacture(int id)
        {
            var res = new GetOneResult<Facture>() { Success = false };
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
        public async Task<ActionResult<GetOneResult<Facture>>> UpdateFacture(int id, FactureVM facture)
        {
            var res = new GetOneResult<Facture>() { Success = false };
            try
            {
                if (ModelState.IsValid
                    && await GlobalSpecifications.Specification(_userManager, facture.adminId)
                    && await GlobalSpecifications.Specification(_userManager, facture.fourissuerId)
                    )
                {
                    var fctr = new Facture()
                    {
                        Description = facture.Description,
                        FactureRef = facture.FactureRef,
                        status = facture.status,
                        payBefore = facture.payBefore,
                        CommandId = facture.CommandId,
                        unitprice = facture.unitprice,
                        quantity = facture.quantity,
                        currency = facture.currency,
                        taxes = facture.taxes,
                        total = facture.total,
                        adminId = facture.adminId,
                        fourissuerId = facture.fourissuerId,
                        valide = facture.valide
                    };
                    var result = await _repository.UpdateFactureAsync(fctr, id);

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
