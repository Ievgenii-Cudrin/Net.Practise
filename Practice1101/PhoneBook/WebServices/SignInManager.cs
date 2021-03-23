using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhoneBook.WebServices
{
    public class SignInManager
    {
		private readonly IHttpContextAccessor httpContextAccessor;

		public SignInManager(
			IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor;
		}

		private HttpContext HttpContext =>
			this.httpContextAccessor.HttpContext;

		public async Task<bool> SignInAsync(User user, string password, bool isPersistent)
		{
			// check password

			var claims = new[]
			{
			new Claim(ClaimTypes.Name, user.Name),
			new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
		};
			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var principal = new ClaimsPrincipal(identity);

			await this.HttpContext.SignInAsync(
				principal,
				new AuthenticationProperties
				{
					IsPersistent = isPersistent
				});

			return true;
		}

		public Task SignOutAsync()
		{
			return this.HttpContext.SignOutAsync();
		}

		public Guid GetUserId()
		{
			var claim = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
			if (claim == null || !Guid.TryParse(claim.Value, out var id))
			{
				return Guid.Empty;
			}

			return id;
		}
	}
}
