using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tp3_Azure.Domain;

namespace Tp3_Azure.Data.Context
{
    public class DataContext:DbContext
    {
        public DataContext():base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\workspace\Tp3-Azure\Tp3-Azure.Data\DataBase\Tp3-Azure-DataBase.mdf;Integrated Security=True")
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
