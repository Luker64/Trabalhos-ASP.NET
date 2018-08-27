using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LojaWeb.Models;

namespace LojaWeb.DAO {
    public class UsuarioDAO {
        private EntidadeContext context;

        public UsuarioDAO() {
            context = new EntidadeContext();
        }

        public IList<Usuario> ListarUsuarios() {
            return context.Usuarios.ToList();
        }

        public IList<Usuario> BuscarId(int id) {
            return (from u in context.Usuarios where u.Id == id select u).ToList();
        }

        public Usuario Buscar1Id(int id)
        {
            return context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void Atualizar() {
            context.SaveChanges();
        }

        public void Inserir(Usuario usuario) {
            context.Usuarios.Add(usuario);
            Atualizar();
        }

        public void Remover(Usuario usuario) {
            context.Usuarios.Remove(usuario);
            Atualizar();
        }

        public bool Login(Usuario user)
        {
            Usuario check = context.Usuarios.FirstOrDefault(u => u.Nome == user.Nome && u.Senha == user.Senha);
            try
            {
                if (user.Nome != null && check.Nome != null)
                {
                    UserLogado.Id = check.Id;
                    UserLogado.Nome = check.Nome;
                    UserLogado.Senha = check.Senha;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}