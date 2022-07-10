using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using MyAxiaMarket1.Models;
using MyAxiaMarket1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAxiaMarket1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MDPController : ControllerBase
    {
        IModeDePaiementRepository _repository;
        

        public MDPController(IModeDePaiementRepository repository)
        {
            _repository = repository;
        }
        [Authorize(Policy = "AdminPrivilege")]
        [HttpPost("InsertModeDePaiement")]
        public async Task<ActionResult<GetOneResult<ModeDePaiement>>> AddModeDePaiement(ModeDePaiement ModeDePaiement)
        {
            var result = new GetOneResult<ModeDePaiement>();
            if ( ModelState.IsValid  )
            {
                try
                {
                    var ctr = new ModeDePaiement()
                    {
                        RefModeDepaiement = ModeDePaiement.RefModeDepaiement,
                        description = ModeDePaiement.description,
                        modifiedBy = ModeDePaiement.modifiedBy,
                        valide = ModeDePaiement.valide,
                    };
                    var res = await _repository.InsertOneAsync(ctr);
                    if (res.Success)
                    {
                        result.Success = true;
                        result.Entity = ctr;
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
        
        [Authorize(Policy = "AdminPrivilege")]
        [HttpGet("GetListModeDePaiement")]
        public async Task<ActionResult<GetManyResult<ModeDePaiement>>> GetListModeDePaiement()
        {
            var result = new GetManyResult<ModeDePaiement>() { Success = false };
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
        [Authorize(Policy = "AdminPrivilege")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetOneResult<ModeDePaiement>>> GetModeDePaiementById([FromQuery] int id)
        {
            var restoreturn = new GetOneResult<ModeDePaiement>() { Success = false };
            try
            {
                return await _repository.GetModeDePaiementByIdAsync(id);

            }
            catch (Exception e)
            {
                restoreturn.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return restoreturn;
        }
        [Authorize(Policy = "AdminPrivilege")]
        [HttpDelete("{id}")]
        public async Task<GetOneResult<ModeDePaiement>> DeleteModeDePaiement(int id)
        {
            var res = new GetOneResult<ModeDePaiement>() { Success = false };
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
        [Authorize(Policy = "AdminPrivilege")]
        [HttpPut("{id}")]
        public async Task<ActionResult<GetOneResult<ModeDePaiement>>> UpdateModeDePaiement(int id, ModeDePaiement ModeDePaiement)
        {
            var res = new GetOneResult<ModeDePaiement>() { Success = false };
            try
            {
                if (ModelState.IsValid)
                {
                    var fctr = new ModeDePaiement()
                    {
                        RefModeDepaiement = ModeDePaiement.RefModeDepaiement,
                        description = ModeDePaiement.description,
                        modifiedBy = ModeDePaiement.modifiedBy,
                        valide = ModeDePaiement.valide,
                    };
                    var result = await _repository.UpdateModeDePaiementAsync(fctr, id);

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
