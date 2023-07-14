using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23BM.Context;
using ProyectoFinal_23BM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
                        res.FkRol= request.FkRol;

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
        //public void Editar(Usuario Edit)
        //{
        //    try
        //    {
        //        using (var _context = new ApplicationDbContext())
        //        {
        //            Usuario Existente = _context.Usuarios.Find(Edit.PkUsuario);

        //            if (Existente != null)
        //            {
        //                Existente.Nombre = Edit.Nombre;
        //                Existente.UserName = Edit.UserName;
        //                Existente.Password = Edit.Password;
        //                Existente.FkRol = Edit.FkRol;

        //                _context.SaveChanges();
        //                MessageBox.Show("Usuario editado correctamente");
        //            }
        //            else
        //            {
        //                MessageBox.Show("No se encontró el Usuario");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Sucedió un error: " + ex.Message);
        //    }
        //}

        public List<Usuario> GetUsuarios()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Usuario> usuarios = _context.Usuarios.Include(x=> x.Roles).ToList();

                    if (usuarios.Count > 0) //verificar lista vacia
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

        public void UpdateUser(Usuario request)
        {
            try
            {
                using(var _context = new ApplicationDbContext())
                {
                    Usuario usuario = new Usuario();
                    usuario = _context.Usuarios.Find(request.PkUsuario);
                    usuario.Nombre = request.Nombre;
                    usuario.UserName = request.UserName;
                    usuario.Password = request.Password;

                    //_context.Update(usuario);
                    _context.Entry(usuario).State = EntityState.Modified;
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }
        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Rol> roles = _context.Roles.ToList();
                    return roles;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

    }
}
