using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tp3_Azure.Data.Context;
using Tp3_Azure.Domain;

namespace Tp3_Azure.Client.Controllers
{
    public class ProdutosController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Produtos
        public ActionResult Index()
        {
            List<Produto> produtos = new List<Produto>();

            using (var proxy = new ServiceReference1.GerenciamentoDeProdutoServiceClient())
            {
                foreach (var item in proxy.GetAll())
                {
                    produtos.Add(new Produto()
                    {
                        ProdutoId = item.ProdutoId,
                        Nome=item.Nome,
                        Categoria=item.Categoria,
                        Preco = item.Preco,
                        Quantidade = item.Quantidade
                    });
                }

                return View(produtos);
            }
        }

        // GET: Produtos/Details/5
        public ActionResult Details(string nome)
        {
            Produto produto = new Produto();

            using (var proxy = new ServiceReference1.GerenciamentoDeProdutoServiceClient())
            {
                var item = proxy.Get(nome);
                produto = new Produto()
                {
                    ProdutoId = item.ProdutoId,
                    Nome = item.Nome,
                    Categoria = item.Categoria,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade
                };
                return View(produto);
            }
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Nome,Categoria,Preco,Quantidade")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.ProdutoId = Guid.NewGuid();

                ServiceReference1.Produto produtosr = new ServiceReference1.Produto()
                {
                    ProdutoId = produto.ProdutoId,
                    Nome = produto.Nome,
                    Categoria = produto.Categoria,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade
                };


                using (var proxy = new ServiceReference1.GerenciamentoDeProdutoServiceClient())
                {
                    proxy.Create(produtosr);
                }
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(string nome)
        {
            Produto produto = new Produto();

            using (var proxy = new ServiceReference1.GerenciamentoDeProdutoServiceClient())
            {
                var item = proxy.Get(nome);
                produto = new Produto()
                {
                    ProdutoId = item.ProdutoId,
                    Nome = item.Nome,
                    Categoria = item.Categoria,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade
                };
                return View(produto);
            }
            
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,Nome,Categoria,Preco,Quantidade")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                ServiceReference1.Produto produtosr = new ServiceReference1.Produto()
                {
                    ProdutoId = produto.ProdutoId,
                    Nome = produto.Nome,
                    Categoria = produto.Categoria,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade
                };


                using (var proxy = new ServiceReference1.GerenciamentoDeProdutoServiceClient())
                {
                    proxy.Edit(produtosr.ProdutoId, produtosr);
                    return RedirectToAction("Index");
                }
                
            }
            
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(string nome)
        {
            Produto produto = new Produto();

            using (var proxy = new ServiceReference1.GerenciamentoDeProdutoServiceClient())
            {
                var item = proxy.Get(nome);
                produto = new Produto()
                {
                    ProdutoId = item.ProdutoId,
                    Nome = item.Nome,
                    Categoria = item.Categoria,
                    Preco = item.Preco,
                    Quantidade = item.Quantidade
                };
                TempData["deleteid"] = produto.ProdutoId;
                TempData.Keep();
                return View(produto);
            }
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            Guid id = (Guid)TempData["deleteid"];
            using (var proxy = new ServiceReference1.GerenciamentoDeProdutoServiceClient())
            {
                proxy.Delete(id);
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
