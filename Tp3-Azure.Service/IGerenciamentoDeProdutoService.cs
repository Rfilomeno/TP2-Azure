using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Tp3_Azure.Domain;

namespace Tp3_Azure.Service
{
    [ServiceContract]
    public interface IGerenciamentoDeProdutoService
    {
        [OperationContract]
        void Create(Produto p);

        [OperationContract]
        Produto Get(string nome);

        [OperationContract]
        IList<Produto> GetAll();

        [OperationContract]
        void Edit(Guid produtoId, Produto p);

        [OperationContract]
        void Delete(Guid produtoId);
    }
}
