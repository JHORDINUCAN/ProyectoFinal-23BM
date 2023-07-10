using ProyectoFinal_23BM.Context;
using ProyectoFinal_23BM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23BM.Services
{
    public class UsuarioServices
    {
        public void AddUser(Usuario request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Usuario res = new Usuario();
                        res.Nombre = request.Nombre;
                        res.UserName = request.UserName;
                        res.Password = request.Password;
                        //res.FkRol= request.FkRol;

                        _context.Usuarios.Add(res);
                        _context.SaveChanges();
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public List<Usuario> GetUsuarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Usuario> usuarios = _context.Usuarios.ToList();

                    if (usuarios.Count > 0)
                    {

                        return usuarios;

                    }

                    return usuarios;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
        }

    }
}
