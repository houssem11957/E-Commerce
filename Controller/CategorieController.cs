using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
//using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyAxiaMarket.Models;
using MyAxiaMarket.ModelView;

using System.Data;
using MyAxiaMarket.ViewModels;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using MyAxiaMarket.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using MyAxiaMarket1.CustomSpecificationPattern;
using Microsoft.AspNetCore.Authorization;

namespace MyAxiaMarket.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        
        private readonly ICategoryRepository _repository;
        private readonly IBoutiqueRepository _boutiquerepository;

        public CategorieController(ICategoryRepository repository, IBoutiqueRepository boutiquerepository)
        {
          
            _repository = repository;
            _boutiquerepository = boutiquerepository;

        }


        
        [Authorize(Policy = "AdminPrivilege")]
        [HttpGet("GetListCategorie")]
        public async Task<ActionResult<GetManyResult<Categorie>>> GetListCategorie()
        {
            var result = new GetManyResult<Categorie>() { Success = false };
            try
            {

                return await _repository.GetAllAsync();
            }
            catch (Exception e)
            {
                result.Message = "error occured : " + e.Message + e.StackTrace;
                return result;
            }
           
        }


        
        [HttpGet("{id}")]
        public async Task<ActionResult<GetOneResult<Categorie>>> GetCategorieById(int id)
        {
            var restoreturn = new GetOneResult<Categorie>() { Success = false };
            try
            {
                return await _repository.GetCategorieByIdAsync(id);

            }
            catch (Exception e)
            {
                restoreturn.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return restoreturn;

        }

        
        [Authorize(Policy = "AdminPrivilege")]
        [HttpPost]
        public async Task<ActionResult<GetOneResult<CategorieViewModel>>> CreateCategorie(CategorieViewModel cvm)
        {
            var res = new GetOneResult<CategorieViewModel>() { Success = false };

            try
            {
                if (ModelState.IsValid && await CategorySpecification.Specification(_boutiquerepository, cvm.boutiqueId))
                {
                    var artcle = new Categorie()
                    {

                        NomCategorie = cvm.NomCategorie,
                        boutiqueId = cvm.boutiqueId,
                        Description = cvm.Description,
                        valide = cvm.valide,
                        modifiedBy = cvm.modifiedBy,
                        
                    };

                    var result = await _repository.InsertOneAsync(artcle);
                    if (result.Success)
                    {
                        res.Success = true;
                        res.Message = "Data inserted correctly !";
                        return res;
                    }
                   
                }
                else
                {
                    res.Message = "please verify that the boutique exist";
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
        public async Task<ActionResult<GetOneResult<CategorieViewModel>>> DeleteCategorie(int id)
        {
            var res = new GetOneResult<CategorieViewModel>() { Success = false };
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
        public async Task<ActionResult<GetOneResult<CategorieViewModel>>> UpdateCategorie(int id, CategorieViewModel cvm)
        {
            var res = new GetOneResult<CategorieViewModel>() { Success = false };
            try
            {
                if (ModelState.IsValid)
                {
                    var artcle = new Categorie()
                    {

                        NomCategorie = cvm.NomCategorie,
                       boutiqueId = cvm.boutiqueId,
                        Description = cvm.Description,
                        valide = cvm.valide,
                        modifiedBy = cvm.modifiedBy,
                        status = cvm.status
                        
                    };
                    var result = await _repository.UpdateCategorieAsync(artcle, id);

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
