using Microsoft.IdentityModel.Tokens;
using System.Text;
 
namespace TestTask1
    {
        public class AuthOptions
        {
            public const string ISSUER = "MyAuthServer";
            public const string AUDIENCE = "MyAuthClient";
            const string KEY = "you_will123never-never_knoW__Any_PaSsWoRd";  
            public const int LIFETIME = 1;
            public static SymmetricSecurityKey GetSymmetricSecurityKey()
            {
                return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
            }
        }
    }