﻿using Dashboard.Viewer.Entity;
using Dashboard.Viewer.Infrastructure;
using Dashboard.Viewer.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Viewer.Service
{
    public class UsuarioController 
    {
        private string _mensagem = "";

        public string Salvar(Usuario entity)
        {
            DashboardViewerContext _db = new DashboardViewerContext();
            using (DbContextTransaction transacao = DashboardViewerTransaction.CreateDbContextTransaction(_db))
            {
                if (entity.Id == 0)
                    _mensagem = new UsuarioRepository(_db).Incluir(entity);
                else
                    _mensagem = new UsuarioRepository(_db).Alterar(entity);

                if (_mensagem == "")
                    transacao.Commit();
                else
                    transacao.Rollback();
            }
            return _mensagem;
        }

        public string Excluir(Usuario entity)
        {
            DashboardViewerContext _db = new DashboardViewerContext();
            using (DbContextTransaction transacao = DashboardViewerTransaction.CreateDbContextTransaction(_db))
            {
                _mensagem = new UsuarioRepository(_db).Excluir(entity);
                if (_mensagem == "")
                    transacao.Commit();
                else
                    transacao.Rollback();
            }
            return _mensagem;
        }

        public Usuario Selecionar(int id)
        {
            return new UsuarioRepository().Selecionar(id);
        }

        public List<Usuario> SelecionarTodos()
        {
            return new UsuarioRepository().SelecionarTodos().ToList();
        }

        public List<Usuario> Filtrar(string condicao)
        {
            return new UsuarioRepository().Filtrar(condicao).ToList();
        }

        public string ValidarLogin(string login, string senha)
        {
            return new UsuarioRepository().ValidarLogin(login, senha);
        }

        public string AlterarSenha(string login, string senhaantiga, string novasenha, string confirmacao)
        {
            return new UsuarioRepository().AlterarSenha(login, senhaantiga, novasenha, confirmacao);
        }
    }
}
