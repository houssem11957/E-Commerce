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
using MyAxiaMarket1.ViewModels;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.DataAccess.Services.Abstract;
using System;
using MyAxiaMarket1.DataLinkers;
using MyAxiaMarket1.CustomSpecificationPattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace MyAxiaMarket.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoutiqueController : ControllerBase
    {
        // GET: BoutiqueController
        private readonly IMapper _mapper;
        //private readonly IMediator _mediator;
        //private readonly IConfiguration _configuration;
        private readonly Context _context;
        public PersonneViewModel PVM;
        private IBoutiqueRepository _repsitory_boutique;
        private ICategoryRepository _repsitory_category;
        private readonly UserManager<Personne> _userManager;
        public BoutiqueController(UserManager<Personne>  userManager,IMapper mapper, Context context, IBoutiqueRepository repsitory_boutique, ICategoryRepository repsitory_category)
        {
            //_mediator = mediator;
            _userManager = userManager;
            _mapper = mapper;
            // _configuration = configuration;
            _context = context;
            _repsitory_boutique = repsitory_boutique;
            _repsitory_category = repsitory_category;

        }


        // GET: api/Boutique
        [Authorize(Policy = "AdminPrivilege")]
        [HttpGet("GetListBoutique")]

        public async Task<ActionResult<GetManyResult<Boutique>>> GetListBoutique()
        {
            var result = new GetManyResult<Boutique>() { Success = false };
            try
            {

                return await _repsitory_boutique.GetAllAsync();
            }
            catch (Exception e)
            {
                result.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return result;
        }

        [Authorize(Policy = "AdminPrivilege")]
        [HttpGet("{id}")]
        public async Task<GetOneResult<Boutique>> GetBoutique(int BoutiqueId)
        {
            var restoreturn = new GetOneResult<Boutique>() { Success = false };
            try
            {
                return await _repsitory_boutique.GetBoutiqueByIdAsync(BoutiqueId);

            }
            catch (Exception e)
            {
                restoreturn.Message = "error occured : " + e.Message + e.StackTrace;
            }
            return restoreturn;

        }

        // POST: api/Boutique
        [Authorize(Policy = "AdminPrivilege")]
        [HttpPost]
        public async Task<ActionResult<GetOneResult<BoutiqueViewModel>>> CreateBoutique(BoutiqueViewModel bvm)
        {
            var res = new GetOneResult<BoutiqueViewModel>() { Success = false };

            try
            {
                if (ModelState.IsValid && await GlobalSpecifications.Specification(_userManager,bvm.ManagerId))
                {
                    var btique = new Boutique()
                    {

                        NomBoutique = bvm.NomBoutique,
                        NatureBoutique = bvm.NatureBoutique,
                        Description = bvm.Description,
                        ManagerId = bvm.ManagerId,
                        valide = bvm.valide

                    };

                    var result = await _repsitory_boutique.InsertOneAsync(btique);
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
        public async Task<ActionResult<GetOneResult<BoutiqueViewModel>>> DeleteBoutique(int id)
        {
            var res = new GetOneResult<BoutiqueViewModel>() { Success = false };
            try
            {
                if (id > 0)
                {
                    var result = await _repsitory_boutique.DeleteByIdAsync(id);
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
        public async Task<ActionResult<GetOneResult<BoutiqueViewModel>>> UpdateBoutique(int id, BoutiqueViewModel bvm)
        {
            var res = new GetOneResult<BoutiqueViewModel>() { Success = false };
            try
            {
                if (ModelState.IsValid && await GlobalSpecifications.Specification(_userManager, bvm.ManagerId))
                {
                    var artcle = new Boutique()
                    {
                        status = bvm.status,
                        valide = bvm.valide,
                        NomBoutique = bvm.NomBoutique,
                        NatureBoutique = bvm.NatureBoutique,
                        Description = bvm.Description,
                        ManagerId = bvm.ManagerId,
                    };
                    var result = await _repsitory_boutique.UpdateBoutiqueAsync(artcle, id);

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
