using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Services
{
    public class PasswordService
    {
        public async Task<int> passwordScore(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;
        }
    }
}
