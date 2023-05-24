using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net_test.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using net_test.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using net_test.Libraries;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace erp.Controllers
{
    [Route("api/AspNetUser")]
    [ApiController]
    public class AspNetUserController : ControllerBase
    {

        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly AspNetUserService _aspNetUserService;
        private readonly SessionsService _sessionsService;
        private readonly IHostingEnvironment _root;
        private readonly ApplicationDBContext _context;
        

        public AspNetUserController (   UserManager<AspNetUser> userManager, 
                                        SignInManager<AspNetUser> signInManager, 
                                        IConfiguration configuration,
                                        AspNetUserService aspNetUserService,
                                        SessionsService sessionsService,
                                        IHostingEnvironment root,
                                        ApplicationDBContext context
                                    )
        {
            _userManager        = userManager;
            _signInManager      = signInManager;
            _aspNetUserService  = aspNetUserService;
            _sessionsService    = sessionsService;
            _root               = root;
            _context            = context;
            this._configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] dynamic argLogin)
        {
            if (ModelState.IsValid)
            {
                string email = (string)argLogin.email;

                AspNetUser objAspNetUser = _context.AspNetUsers
                                            .Where(itemUser => itemUser.Email == email && !itemUser.Deleted)
                                            .FirstOrDefault();

                if(objAspNetUser != null) {

                    var result = await _signInManager.PasswordSignInAsync(objAspNetUser, argLogin.password.ToString(), isPersistent: false, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return _sessionsService.createToken(argLogin);
                    }
                    else
                    {
                        return new OkObjectResult(new { action = false, result = "Password incorrecto. Por favor verifique la informacíon." });
                    }
                    
                } else{
                    return new OkObjectResult(new { action = false, result = "Usuario Incorrecto." });
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("createPassword/{newPassword}")]
        [HttpGet]
        public ActionResult createPassword(string newPassword) {

            AspNetUser objTemp = new AspNetUser();
            return Content(_userManager.PasswordHasher.HashPassword(objTemp, newPassword));
        }
    }
}