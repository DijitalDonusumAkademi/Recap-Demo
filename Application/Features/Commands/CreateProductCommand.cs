﻿using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Commands
{
    public class CreateProductCommand : IFeatureCommand
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }

        public class CreateProductCommandHandler
        {
            private readonly IApplicationContext _applicationContext;

            public CreateProductCommandHandler(IApplicationContext applicationContext)
            {
                _applicationContext = applicationContext;
            }

            public async Task<int> Handle(CreateProductCommand command)
            {
                var product = new Product()
                {
                    Name = command.Name,
                    Barcode = command.Barcode,
                    Description = command.Description,
                    Rate = command.Rate
                };
                _applicationContext.Products.Add(product);
                await _applicationContext.SaveChanges();
                return product.Id;
            }
        }
    }
}