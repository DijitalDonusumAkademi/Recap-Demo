using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries
{
    public class GetAllProductsQuery : IFeatureCommand
    {
        public class GetAllProductsQueryHandler
        {
            private readonly IApplicationContext _context;

            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
            {
                var productList = await _context.Products.ToListAsync();
                return productList?.AsReadOnly();
            }
        }
        
    }
}

//Burada ki yapımızı diğer feature larımızda da kullanacağız. Uygulamamıza bu handler sınıflar ile isteklerini bildirecekler eğer gerekiyorsa parametre olarakta bu işin yapılması için gereken değerleri yine query ve ya command sınıflarımızla iletecekler. Gördüğünüz gibi veritabanı için ApplicationContext’in interface ini constructor ile alıyoruz bunu dependency injection ile webapi bizim yerimize sınıflarımıza geçirecektir. Diğer feature larımızda da aynı yolu izleyeceğiz.