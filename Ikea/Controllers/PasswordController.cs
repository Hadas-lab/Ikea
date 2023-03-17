using Microsoft.AspNetCore.Mvc;
using Services;


namespace LogInSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        IPasswordService passwordService;

        public PasswordController(IPasswordService passwordService) 
        {
            this.passwordService = passwordService;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] string value)
        {
            int score = await passwordService.passwordScore(value);
            return score;
        }
    }
}
