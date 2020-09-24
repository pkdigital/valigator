// 
//    Valigator
// 
//    EmailController.cs
// 
// 

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Valigator.Services;

namespace Valigator.Controllers
{
    [Route("[controller]")]
    public class EmailController : Controller
    {
        /// <summary>
        ///     Checks if the email is in valid format, is not black-listed and provides common
        ///     suggestions to misspelt domains
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("validate")]
        [Produces("application/json")]
        public async Task<IActionResult> Validate(string address)
        {
            var response = await new EmailValidationService().Validate(address, false);
            return Ok(response);
        }

        /// <summary>
        ///     Provides all validation plus a DNS lookup to check the domain is valid
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("verify")]
        public async Task<IActionResult> Verify(string address)
        {
            var response = await new EmailValidationService().Validate(address, true);
            return Ok(response);
        }
    }
}