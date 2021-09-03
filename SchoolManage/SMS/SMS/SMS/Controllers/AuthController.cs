using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SMS.Models;
using SMSAPI.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IJwtAuthenticationManager _JwtAuthenticationManager;
		private readonly SchoolManagementContext _dbcontext;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IConfiguration _configuration;

		public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration,
			           IJwtAuthenticationManager JwtAuthenticationManager, SchoolManagementContext dbcontext)
		{
			this._JwtAuthenticationManager = JwtAuthenticationManager;
			this._dbcontext = dbcontext;
			this.userManager = userManager;
			this.roleManager = roleManager;
			_configuration = configuration;
		}

		[AllowAnonymous]
		[HttpPost ("UserAuth")]
		[Route("api/[controller]/UserAuth")]
		[Consumes("application/json")]
		public async Task<IActionResult> UserAuth([FromBody]  LoginCreds loginCred)
		{
			string _AuthToken, _Firstname;
			var user = await userManager.FindByNameAsync(loginCred.UserName);
			if (user != null && await userManager.CheckPasswordAsync(user, loginCred.Password))
			{

				_AuthToken = _JwtAuthenticationManager.Authenticate(loginCred.UserName);

				_Firstname = this._dbcontext.Staffs.Where(_userName => _userName.Mobile.ToString() == loginCred.UserName).FirstOrDefault().FirstName;

				return StatusCode(StatusCodes.Status200OK, new { AuthToken = _AuthToken, FirstName = _Firstname });

			}
			return Unauthorized();


		}
	}
}
