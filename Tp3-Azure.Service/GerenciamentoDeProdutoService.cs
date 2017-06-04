using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp3_Azure.Data;
using Tp3_Azure.Domain;

namespace Tp3_Azure.Service
{
    public class GerenciamentoDeProdutoService : IGerenciamentoDeProdutoService
    {
        ProdutoDao dao;
        public GerenciamentoDeProdutoService()
        {
            this.dao = new ProdutoDao();
        }

        public void Create(Produto p)
        {
            dao.Add(p);
        }

        public void Delete(Guid produtoId)
        {
            dao.Delete(produtoId);
        }

        public void Edit(Guid produtoId, Produto p)
        {
            dao.Edit(produtoId, p);
        }

        public Produto Get(string nome)
        {
            return dao.Get(nome);
        }

        public IList<Produto> GetAll()
        {
            return dao.GetAll();
        }
    }
}
