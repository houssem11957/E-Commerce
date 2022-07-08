using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyAxiaMarket.Models;
using MyAxiaMarket.ModelView;

using MyAxiaMarket1.AccountDTOs;
using MyAxiaMarket1.Response;
using MyAxiaMarket1.Settings;
using MyAxiaMarket1.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyAxiaMarket.Controller
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {
       
        private readonly IMapper _mapper;
       
        private readonly UserManager<Personne> _userManager;
        private readonly SignInManager<Personne> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWTConfig _jWTConfig;
       
        public AuthentificationController(IOptions<JWTConfig> jwtConfig, RoleManager<IdentityRole> roleManager,SignInManager<Personne> signinManager,UserManager<Personne> userManager, IMapper mapper)
        {
           
           
            _mapper = mapper;
            _userManager = userManager;
            _signinManager = signinManager;
            _roleManager = roleManager;
            _jWTConfig = jwtConfig.Value;

        }
        [AllowAnonymous]
        [HttpPost]
        [ActionName("Login")]
        public async Task<ActionResult<SignInModel<Personne>>> Login([FromBody] LoginViewModel lvm)
        {
            var restoreturn = new SignInModel<Personne>() { Entity = null, jwt = null, Success = false };
            try
            {
               

                if (ModelState.IsValid)
                {
                    var res = await _userManager.FindByEmailAsync(lvm.email);
                    if (res is null)
                    {
                        restoreturn.Message = "authentication faild please register first ...";
                        return BadRequest(restoreturn);
                    }
                    var authres = await _signinManager.CheckPasswordSignInAsync(res, lvm.password, false);
                    if (!authres.Succeeded)
                    {
                        restoreturn.Message = "invalid credentials !";
                        return BadRequest(restoreturn);
                    }

                    var appUser = await _userManager.FindByEmailAsync(lvm.email);
                    var roles = (await _userManager.GetRolesAsync(appUser)).FirstOrDefault();
                    restoreturn.Success = true;
                    restoreturn.jwt = GenerateToken(appUser, roles);
                    restoreturn.Message = "signed in successfully !";

                    return restoreturn;
                }
                return restoreturn;
            }
            catch (Exception e)
            {
                restoreturn.Message = e.Message + "/" + e.StackTrace;
                return restoreturn;
            }
           
                
            }
        [Authorize(Policy = "AdminPrivilege")]
        [HttpGet("{id}")]
        [ActionName("GetUserById")]
        public async Task<object> GetUserById(string id)
        {
            try
            {

                var user = await _userManager.FindByIdAsync(id);

                if (user != null)
                {
                  
                    return user;
                }
                return await Task.FromResult("user introuvable");
            }
            catch (Exception ex)
            {
                return await Task.FromResult("rien a afficher" + "cause possible :" + ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost, DisableRequestSizeLimit]
        [ActionName("RegisterUser")]

        public async Task<ActionResult<SignInModel<Personne>>> RegisterUser([FromForm] PersonneDTO model)
        {
            var restoreturn = new SignInModel<Personne>() { Entity = null, jwt = null, Success = false };
            restoreturn.Success = false;

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.role == null)
                    {
                        restoreturn.Message = "roles n'existe pas";
                        return restoreturn;
                    }


                    if (!await _roleManager.RoleExistsAsync(model.role))
                    {
                        restoreturn.Message = "roles n'existe pas";
                        return restoreturn;
                    }

                    var per = new Personne() {UserName = model.userName,Email = model.email,NomP = model.nom,PrenomP = model.prenom };
                    var result = await _userManager.CreateAsync(per, model.password);
                    if (result.Succeeded)
                    {
                       
                        var tempUser = await _userManager.FindByEmailAsync(model.email);
                        await _userManager.AddToRoleAsync(tempUser, model.role);

                        restoreturn.Message = "register user avec succee";
                        restoreturn.Success = true;
                        return restoreturn;
                    }
                    restoreturn.Message = " failed to  register ";
                    return restoreturn;
                }
                else
                {
                    restoreturn.Message = "saisir votre informations soigneusement";
                    return restoreturn;
                }

            }
            catch (Exception ex)
            {
                restoreturn.Message = "erreur" + ex.Message + "/" + ex.StackTrace;
                return restoreturn;
            }
        }

        [Authorize(Policy = "AdminPrivilege")]
        [HttpGet("GetUserList")]
        public async Task<object> GetUserList()
        {
            try
            {
                List<PersonNroleDTO> allUserDTO = new List<PersonNroleDTO>();
                var users = _userManager.Users.ToList();
                foreach (var user in users)
                {
                    var role = (await _userManager.GetRolesAsync(user)).ToList();

                    allUserDTO.Add(new PersonNroleDTO(user, role.ElementAt(0)));


                }
                return await Task.FromResult(allUserDTO);
            }
            catch (Exception ex)
            {
                return await Task.FromResult("rien a afficher" + "cause possible :" + ex.Message);
            }
        }

        [Authorize(Policy = "AdminPrivilege")]
        [HttpPost, DisableRequestSizeLimit]
        [ActionName("RegisterAdmin")]
        public async Task<ActionResult<SignInModel<Personne>>> RegisterAdmin([FromForm] AdminDTO model)
        {
            var restoreturn = new SignInModel<Personne>() { Entity = null, jwt = null, Success = false };
            restoreturn.Success = false;

            try
            {
                string Role = "admin";
               




                if (ModelState.IsValid)
                {
                    if (Role == null)
                    {
                        restoreturn.Message = "roles n'existe pas";
                        return restoreturn;
                    }


                    if (!await _roleManager.RoleExistsAsync(Role))
                    {
                        restoreturn.Message = "roles n'existe pas";
                        return restoreturn;
                    }

                    var per = new Personne() { UserName = model.userName, Email = model.email, NomP = model.nom, PrenomP = model.prenom };
                    var result = await _userManager.CreateAsync(per, model.password);
                    if (result.Succeeded)
                    {

                        var tempUser = await _userManager.FindByEmailAsync(model.email);
                        await _userManager.AddToRoleAsync(tempUser, Role);

                        restoreturn.Message = "register user avec succee";
                        restoreturn.Success = true;
                        return restoreturn;
                    }
                    restoreturn.Message = " failed to  register ";
                    return restoreturn;
                }
                else
                {
                    restoreturn.Message = "saisir votre informations soigneusement";
                    return restoreturn;
                }

            }
            catch (Exception ex)
            {
                restoreturn.Message = "erreur" + ex.Message + "/" + ex.StackTrace;
                return restoreturn;
            }
        }

        [Authorize]
        [HttpPost]
        [ActionName("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                
                var result = await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(model.UserId), model.Token, model.NewPassword);


                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return Ok("new password subbmitted !");
                }

            }
            return Ok("wrong data !, temporary data will be removed please try again later !");
        }
         [Authorize]
        [HttpPut("{UserId}")]
        [ActionName("EditUser")]
        public async Task<ActionResult> EditUser([FromBody] UpdateUserVM mdl, [FromHeader] string UserId,string role)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (!string.IsNullOrWhiteSpace(UserId))
                    {



                        var user = await _userManager.FindByIdAsync(UserId);

                        if (user == null) return Ok("donnee non valide");

                        var model = new Personne
                        {
                            Id = user.Id,
                            AccessFailedCount = user.AccessFailedCount,
                            ConcurrencyStamp = user.ConcurrencyStamp,
                            Email = mdl.Email,
                            EmailConfirmed = user.EmailConfirmed,
                            LockoutEnabled = user.LockoutEnabled,
                            LockoutEnd = user.LockoutEnd,

                            PasswordHash = user.PasswordHash,
                            PhoneNumber = mdl.PhoneNumber,

                            SecurityStamp = user.SecurityStamp,
                            TwoFactorEnabled = user.TwoFactorEnabled,
                            UserName = mdl.UserName,
                          
                            NomP = mdl.NomP,
                            PrenomP = mdl.PrenomP,
                           


                        };
                        var res = await _userManager.UpdateAsync(model);
                        if (res.Succeeded)
                        {
                            if (role != null && await _roleManager.RoleExistsAsync(role))
                            {
                                var mytemp = await _userManager.FindByEmailAsync(model.Email);
                                if (mytemp != null)
                                {
                                    var addingtorole = await _userManager.AddToRoleAsync(mytemp, role);
                                    if (addingtorole.Succeeded)
                                    {
                                        return Ok("change submitted");
                                    }
                                    else
                                    {
                                        return Ok("chnage was not submitted Role does not exist");
                                    }
                                }
                                else
                                {
                                    return Ok("chnage was not submitted Invalid Informations !");
                                }
                            }
                            else
                            {
                                return Ok("chnage was not submitted Invalid Informations !");
                            }

                        }
                        else
                        {
                            return Ok("invalid data");
                        }

                    }
                    else
                    {
                        return Ok("invalid data");
                    }
                }
                catch (Exception ex)
                {
                    return Ok("operation cancelled : " + ex.Message);
                }
            }
            else return Ok("donnee non valide");
        }
        [Authorize(Policy = "AdminPrivilege")]
        [HttpPost("AddRole")]
        public async Task<object> AddRole([FromBody] AddRoleBindingModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return await Task.FromResult("role can't be empty");

                }
                if (await _roleManager.RoleExistsAsync(model.Role))
                {
                    return await Task.FromResult("Role already exist");

                }
                var role = new IdentityRole();
                role.Name = model.Role;
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {

                    return await Task.FromResult("Role added successfully");
                }
                return await Task.FromResult("something went wrong please try again later");
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }

        private string GenerateToken(Personne user, string role)
        {
            var claims = new List<System.Security.Claims.Claim>(){
            new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
               new Claim(JwtRegisteredClaimNames.Email,user.Email),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
           };

            claims.Add(new System.Security.Claims.Claim(ClaimTypes.Role, role));


            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jWTConfig.key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(720),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _jWTConfig.Audience,
                Issuer = _jWTConfig.Issuer
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }


    }
}
