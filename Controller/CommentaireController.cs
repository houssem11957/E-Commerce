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
    public class CommentaireController : ControllerBase
    {
        ICommentaireRepository _repository;


        public CommentaireController(ICommentaireRepository repository)
        {
            _repository = repository;
        }
        [Authorize(Policy = "AdminPrivilege")]
        [HttpPost("InsertCommentaire")]
        public async Task<ActionResult<GetOneResult<Commentaire>>> AddCommentaire(Commentaire Commentaire)
        {
            var result = new GetOneResult<Commentaire>();
            if (ModelState.IsValid)
            {
                try
                {
                    var ctr = new Commentaire()
                    {
                        Title = Commentaire.Title,
                        description = Commentaire.description,
                        modifiedBy = Commentaire.modifiedBy,
                        valide = Commentaire.valide,
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
        [HttpGet("GetListCommentaire")]
        public async Task<ActionResult<GetManyResult<Commentaire>>> GetListCommentaire()
        {
            var result = new GetManyResult<Commentaire>() { Success = false };
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
        public async Task<ActionResult<GetOneResult<Commentaire>>> GetCommentaireById([FromQuery] int id)
        {
            var restoreturn = new GetOneResult<Commentaire>() { Success = false };
            try
            {
                return await _repository.GetCommentaireByIdAsync(id);

            }
            catch (Exception e)
            {
                restoreturn.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return restoreturn;
        }
        [Authorize(Policy = "AdminPrivilege")]
        [HttpDelete("{id}")]
        public async Task<GetOneResult<Commentaire>> DeleteCommentaire(int id)
        {
            var res = new GetOneResult<Commentaire>() { Success = false };
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
        public async Task<ActionResult<GetOneResult<Commentaire>>> UpdateCommentaire(int id, Commentaire Commentaire)
        {
            var res = new GetOneResult<Commentaire>() { Success = false };
            try
            {
                if (ModelState.IsValid)
                {
                    var fctr = new Commentaire()
                    {
                        Title = Commentaire.Title,
                        description = Commentaire.description,
                        modifiedBy = Commentaire.modifiedBy,
                        valide = Commentaire.valide,
                    };
                    var result = await _repository.UpdateCommentaireAsync(fctr, id);

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
