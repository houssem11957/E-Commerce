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
    public class ContratController : ControllerBase
    {
        private readonly IContratRepository _repository;
        private readonly UserManager<Personne> _userManager;
        public ContratController(UserManager<Personne> userManager , IContratRepository repository)
        {
            _repository = repository;
            _userManager = userManager;
        }
        [Authorize(Policy = "AdminPrivilege")]
        [HttpPost("InsertContrat")]
        public async Task<ActionResult<GetOneResult<Contrat>>> AddContrat(ContratVM contrat)
        {
            var result = new GetOneResult<Contrat>();
            if (
                ModelState.IsValid 
                && await GlobalSpecifications.Specification(_userManager, contrat.fournisseurId)
                && await GlobalSpecifications.Specification(_userManager, contrat.AdminId)
                )
            {
                try
                {
                    var ctr = new Contrat()
                    {
                        Description = contrat.Description,
                        modifiedBy = contrat.modifiedBy,
                        status = contrat.status,
                        fournisseurId = contrat.fournisseurId,
                        startDate = contrat.startDate,
                        clauses = contrat.clauses,
                        AdminId = contrat.AdminId,
                        valide = contrat.valide,
                        EndDate = contrat.EndDate,

                        
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
        [HttpGet("GetListContrat")]
        public async Task<ActionResult<GetManyResult<Contrat>>> GetListContrat()
        {
            var result = new GetManyResult<Contrat>() { Success = false };
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
        public async Task<ActionResult<GetOneResult<Contrat>>> GetContratById([FromQuery] int id)
        {
            var restoreturn = new GetOneResult<Contrat>() { Success = false };
            try
            {
                return await _repository.GetContratByIdAsync(id);

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
        [Authorize(Policy = "AdminPrivilege")]
        [HttpPut("{id}")]
        public async Task<ActionResult<GetOneResult<Contrat>>> UpdateContrat(int id, ContratVM contrat)
        {
            var res = new GetOneResult<Contrat>() { Success = false };
            try
            {
                if (ModelState.IsValid
                     && await GlobalSpecifications.Specification(_userManager, contrat.fournisseurId)
                     && await GlobalSpecifications.Specification(_userManager, contrat.AdminId)
                    )
                {
                    var fctr = new Contrat()
                    {
                        Description = contrat.Description,
                        modifiedBy = contrat.modifiedBy,
                        status = contrat.status,
                        fournisseurId = contrat.fournisseurId,
                        startDate = contrat.startDate,
                        clauses = contrat.clauses,
                        AdminId = contrat.AdminId,
                        valide = contrat.valide,
                        EndDate = contrat.EndDate,
                    };
                    var result = await _repository.UpdateContratAsync(fctr, id);

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
