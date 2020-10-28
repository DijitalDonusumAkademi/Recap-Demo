using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChanges();
    }
}

//Bu interface bizim ürünlerimizin kalıcı olarak saklanması, getirilmesi gibi işlemleri yapacak olan sınıflar için bir sözleşmedir bunun implementasyonu Infrastructure katmanında yapılacaktır. Bunu bir interface yaparak Application ve Infrastructure katmanı arasındaki bağımlılığı azaltıyorum.