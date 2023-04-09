using Microsoft.AspNetCore.Mvc;
using Services;


namespace LogInSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService) 
        {
            _passwordService = passwordService;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] string value)
        {
            int score = await _passwordService.passwordScore(value);
            return score;
        }
    }
}
