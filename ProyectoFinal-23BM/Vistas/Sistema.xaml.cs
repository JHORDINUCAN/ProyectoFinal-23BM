﻿using Google.Protobuf;
using ProyectoFinal_23BM.Entities;
using ProyectoFinal_23BM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinal_23BM.Vistas
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUserTable();
        }
        UsuarioServices services = new UsuarioServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            if (usuario.Nombre == null && usuario.UserName == null && usuario.Password == null)
            {
                usuario.Nombre = txtNombre.Text;
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;

                services.AddUser(usuario);

                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();

                MessageBox.Show("SE AGREGÓ CORRECTAMENTE");
            }

            else if (usuario != null)
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                    usuario.Nombre = txtNombre.Text;

                if (!string.IsNullOrEmpty(txtUserName.Text))
                    usuario.UserName = txtUserName.Text;

                if (!string.IsNullOrEmpty(txtPassword.Text))
                    usuario.UserName = txtUserName.Text;

                services.AddUser(usuario);

                MessageBox.Show("¡Empleado editado correctamente!");
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
            }

        }

        private void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = (sender as FrameworkElement).DataContext as Usuario;

            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();        
        }

        public void GetUserTable()
        {
            UserTable.ItemsSource = services.GetUsuarios();
        }
    }
}
