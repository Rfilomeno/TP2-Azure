using System;
using System.Runtime.Serialization;

namespace Tp3_Azure.Domain
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public Guid ProdutoId { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Categoria { get; set; }

        [DataMember]
        public string Preco { get; set; }

        [DataMember]
        public int Quantidade { get; set; }

        public Produto()
        {
            this.ProdutoId = new Guid();
        }
    }
}
