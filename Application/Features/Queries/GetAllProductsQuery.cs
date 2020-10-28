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