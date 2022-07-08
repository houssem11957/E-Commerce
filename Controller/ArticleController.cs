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
using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.ViewModels;
using MyAxiaMarket1.DataLinkers;
using MyAxiaMarket1.CustomSpecificationPattern;

namespace MyAxiaMarket.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        // GET: ArticleController
        private readonly IMapper _mapper;
        //private readonly IMediator _mediator;
        //private readonly IConfiguration _configuration;
        public PersonneViewModel PVM;
        IArticleRepository _repository;
        ICategoryRepository _categoryRepository;

        public ArticleController(ICategoryRepository categoryRepository,IMapper mapper, IArticleRepository repository)
        {
            //_mediator = mediator;
            _mapper = mapper;
            // _configuration = configuration;
            _repository = repository;
            _categoryRepository = categoryRepository;

        }


        // GET: api/Article

        [HttpGet("GetListArticle")]

        public async Task<ActionResult<GetManyResult<Article>>> GetListArticle()
        {
            var result = new GetManyResult<Article>() {Success = false };
            try
            {
                
                return await  _repository.GetAllAsync();
            }catch(Exception e)
            {
                result.Message ="error occured : " + e.Message + e.StackTrace;
            }
            return result;
        }
        [HttpGet("GetArticleByCategory/{categoryId}")]

        public async Task<ActionResult<GetOneResult<CategoryArticleVM>>> GetArticleByCategory(int categoryId)
        {
            var result = new GetOneResult<CategoryArticleVM>() { Success = false };
            try
            {
                return  await CategoryArticleDataLinker.Link(_repository, _categoryRepository,categoryId);
                
            }
            catch (Exception e)
            {
                result.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return result;
        }

        //GET: api/Article/5
        [HttpGet("{id}")]

        public async Task<ActionResult<GetOneResult<Article>>> GetArticleById([FromQuery] int id)
        {
            var restoreturn = new GetOneResult<Article>() { Success = false};
            try
            {
                return await _repository.GetArticleByIdAsync(id);

            }catch(Exception e)
            {
                restoreturn.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return restoreturn;
        }

        // POST: api/Article

        [HttpPost]
        public async Task<ActionResult<GetOneResult<ArticleViewModel>>> CreateArticle([FromBody] ArticleViewModel articlevm)
        {
            var res = new GetOneResult<ArticleViewModel>() { Success = false};

            try
            {
            if(ModelState.IsValid && await ArticleSpecification.Specification(_categoryRepository, articlevm.cateogryId))
             {
                    var artcle = new Article() {

                        NomArticle = articlevm.NomArticle,
                        Reference = articlevm.Reference,
                        description = articlevm.description,
                        price = articlevm.price,
                        categoryId = articlevm.cateogryId,
                        valide = articlevm.valide,
                        modifiedBy = articlevm.modifiedBy,
                        status = articlevm.status
                    };

                    var result = await _repository.InsertOneAsync(artcle);
                    if(result.Success)
                    {
                        res.Success = true;
                        res.Message = "Data inserted correctly !";
                    }
             }
                res.Message = "please verify that the cateogry exist ";
                return res;
            }
            catch(Exception e)
            {
                res.Message = "unexpected error occured :" + e.Message + e.StackTrace;
                return res;
            }

        }


        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        public async Task<GetOneResult<ArticleViewModel>> DeleteArticle(int id)
        {
            var res =  new GetOneResult<ArticleViewModel>() { Success = false };
            try
            {
                if(id>0)
                {
                    var result = await _repository.DeleteByIdAsync(id);
                    if (result.Success)
                    {
                        result.Success = true;
                        res.Message = "Data Removed successfully !";
                    }
                }

                return res;
            }catch(Exception e)
            {
                res.Message = "unexpected error occured :" + e.Message + e.StackTrace;
                return res;
            }
        }


        // PUT: api/Articles/5

        [HttpPut("{id}")]
        public async Task<ActionResult<GetOneResult<ArticleViewModel>>> UpdateArticle(int id, ArticleViewModel articlevm)
        {
            var res = new GetOneResult<ArticleViewModel>() { Success = false };
            try
            {
                if(ModelState.IsValid && await ArticleSpecification.Specification(_categoryRepository, articlevm.cateogryId))
                {
                    var artcle = new Article()
                    {

                        NomArticle = articlevm.NomArticle,
                        Reference = articlevm.Reference,
                        description = articlevm.description,
                        categoryId = articlevm.cateogryId,
                        price = articlevm.price,
                        valide = articlevm.valide,
                        modifiedBy = articlevm.modifiedBy,
                        status = articlevm.status
                    };
                    var result = await _repository.UpdateArticleAsync(artcle, id);

                    if(result.Success)
                    {
                        res.Success = true;
                        res.Message = "data updated !";
                    }
                }
                return res;
            }
            catch(Exception e)
            {
                res.Success = false;
                res.Message = "error occured !" + e.Message + e.StackTrace;
                return res;
            }
        }

    }
}
