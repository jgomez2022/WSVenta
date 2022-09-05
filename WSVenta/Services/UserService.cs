using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Tools;
using WSVenta.Models.Response;
using WSVenta.Models.Request;
using WSVenta.Models;

namespace WSVenta.Services
{
    public class UserService : IUserService
    {
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userresponse = null;
            using (var db = new VentaRealContext())
            {
                string spassword = Encrypt.GetSHA256(model.Password);
                var usuario = db.Usuario.Where(d => d.Email == model.Email && d.Password == spassword).FirstOrDefault();

                if (usuario == null) return null;
                userresponse.Email = usuario.Email;
            }

            return userresponse;
   
        }
    }
}
