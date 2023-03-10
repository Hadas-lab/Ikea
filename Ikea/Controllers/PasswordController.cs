using Microsoft.AspNetCore.Mvc;
using Services;


namespace LogInSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        PasswordService passwordService = new();
        

        [HttpPost]
        public async Task<int> Post([FromBody] string value)
        {
            int score = await passwordService.passwordScore(value);
            return score;
        }
    }
}
