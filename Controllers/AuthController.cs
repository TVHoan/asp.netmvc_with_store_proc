using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using netmvc.Dto;
namespace netmvc.Controllers
{   
    public class AuthController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AuthController()
        {
        }

        public AuthController(ApplicationUserManager userManager, ApplicationSignInManager signInManager )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        [Route("api/auth/token")]
        [AllowAnonymous]
        [HttpPost]
        public  Object GetToken([FromBody]LoginInputDto input )
        {                
            var status =  SignInManager.PasswordSignIn(input.Email, input.Password, false, false);
           if (status == SignInStatus.Success)
           {
               var user =  UserManager.FindByName(input.Email);
               var roles =  UserManager.GetRoles(user.Id);
               return Helper.GetToken(user.Id,user,roles.ToList());
           }

           return new {messenge ="Username or Password is Incorrect" };

        }
        [HttpGet]
        [Route("api/auth/test")]
        [Authorize(Roles = "admin")]
        public Object TestAPiAuth()
        {
            return new { messenge ="Test api Authorize success"};
        }
    }
}