using System;
using System.Collections.Generic;
using System.Linq;
using Tp3_Azure.Data.Context;
using Tp3_Azure.Domain;

namespace Tp3_Azure.Data
{
    public class ProdutoDao
    {
        DataContext _contexto;
        public ProdutoDao()
        {
            this._contexto = new DataContext();
        }
        public void Add(Produto p)
        {
            _contexto.Produtos.Add(p);
            _contexto.SaveChanges();
        }

        public Produto Get(string nome)
        {
            return _contexto.Produtos.Where(p => p.Nome.Equals(nome)).FirstOrDefault();
        }

        public IList<Produto> GetAll()
        {
            return _contexto.Produtos.ToList();
        }

        public void Edit(Guid produtoId, Produto p)
        {
            var busca = _contexto.Produtos.Where(x => x.ProdutoId.Equals(produtoId)).FirstOrDefault();

            busca.Nome = p.Nome;
            busca.Categoria = p.Categoria;
            busca.Preco = p.Preco;
            busca.Quantidade = p.Quantidade;
            _contexto.SaveChanges();

        }

        public void Delete (Guid produtoId)
        {
            var busca = _contexto.Produtos.Where(x => x.ProdutoId.Equals(produtoId)).FirstOrDefault();

            _contexto.Produtos.Remove(busca);
            _contexto.SaveChanges();

        }
    }
}
