using Login.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Login.Model
{
    public class LoginPrincipal
    {
        public static void VerificacionLogin(LoginBibliotecaDataContext miDataContext, string usuario, string password, LoginView loginView)
        {
            Usuario verificarUsuario = miDataContext.Usuario.FirstOrDefault(li => li.NombreUsuario.Equals(usuario));

            if(verificarUsuario != null && verificarUsuario.Password == password)
            {
                PrincipalPage principalPage = new PrincipalPage();
                principalPage.Show();
                loginView.Close();
            }
            else 
            {
                MessageBox.Show("Error en usuario o contraseña");
            }
        }
    }


}
