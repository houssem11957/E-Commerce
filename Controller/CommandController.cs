using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CommandController : ControllerBase
    {
        private readonly ICommandeRepository _repository;
        private readonly IPanierRepository _panier_repository;
        private readonly IModeDePaiementRepository _mdp_repository;

        public CommandController(IModeDePaiementRepository mdp_repository,ICommandeRepository repository, IPanierRepository panier_repository)
        {
            _repository = repository;
            _panier_repository = panier_repository;
            _mdp_repository = mdp_repository;
        }
        [Authorize(Policy = "AdminPrivilege")]
        [HttpGet("GetListCommand")]
        public async Task<ActionResult<GetManyResult<Commande>>> GetListCommand()
        {
            var result = new GetManyResult<Commande>() { Success = false };
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
        public async Task<ActionResult<GetOneResult<Commande>>> GetCommandById([FromQuery] int id)
        {
            var restoreturn = new GetOneResult<Commande>() { Success = false};
            try
            {
                return await _repository.GetCommandeByIdAsync(id);

            }catch(Exception e)
            {
                restoreturn.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return restoreturn;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<GetOneResult<Commande>>> CreateCommand([FromBody] CommandeVM cvm)
        {
            var res = new GetOneResult<Commande>() { Success = false };

            try
            {
                if (ModelState.IsValid && await CommandeSpecification.Specification(_panier_repository,cvm.panierId,_mdp_repository,cvm.modeDpaiement))
                {
                    var artcle = new Commande()
                    {

                        commandRefrence = cvm.commandRefrence,
                        status = cvm.status,
                        modifiedBy = cvm.modifiedBy,    
                        valide = cvm.valide
                      
                  
                    };

                    var result = await _repository.InsertOneAsync(artcle);
                    if (result.Success)
                    {
                        res.Success = true;
                        res.Message = "Data inserted correctly !";
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
        [HttpDelete("{id}")]
        public async Task<GetOneResult<Commande>> DeleteArticle(int id)
        {
            var res = new GetOneResult<Commande>() { Success = false };
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
        public async Task<ActionResult<GetOneResult<Commande>>> UpdateCommand(int id, CommandeVM cvm)
        {
            var res = new GetOneResult<Commande>() { Success = false };
            try
            {
                if (ModelState.IsValid)
                {
                    var cmd = new Commande()
                    {

                        commandRefrence = cvm.commandRefrence,
                        status = cvm.status,
                        modifiedBy = cvm.modifiedBy,
                        valide = cvm.valide


                    };
                    
                    var result = await _repository.UpdateCommandeAsync(cmd, id);

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

        [Authorize]
        [HttpPatch("{id}")]
        public async Task<ActionResult<GetOneResult<Commande>>> UpdateLivraisonCommand(int id, string etatlivraison,string modifiedby)
        {
            var res = new GetOneResult<Commande>() { Success = false };
            try
            {
                if (ModelState.IsValid)
                {
                    var cmd = new Commande()
                    {

                        modifiedBy = modifiedby,
                        status = etatlivraison,
                        lastModified = DateTime.Now


                    };

                    var result = await _repository.UpdatestatusAsync(cmd, id);

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
