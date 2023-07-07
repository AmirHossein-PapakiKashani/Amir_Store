using Amir_Store.Application.Interfaces.Context;
using Amir_Store.Common;
using Amir_Store.Common.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir_Store.Application.Services.Queries.GetProductForSite
{
    internal interface IGetProductForSiteService
    {
        ResultDto<ResultProductForSiteDto> Execute(int Page);
    }

    public class GetProductForSiteService : IGetProductForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetProductForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultProductForSiteDto> Execute(int Page)
        {
            int totalrow = 0;
            var products = _context.Products.Include(p => p.ProductImages).ToPaged( Page, 5, out totalrow);

            return new ResultDto<ResultProductForSiteDto>
            {
                Data = new ResultProductForSiteDto
                {
                    TotalRow = totalrow,
                    Products = products.Select(p => new ProductForSiteDto
                    {
                        Id = 3,
                        Title = p.Name,
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                    }).ToList(),
                },
                IsSuccess = true,
            };
        }
    }

    public class ResultProductForSiteDto
    {
        public List<ProductForSiteDto> Products { get; set; }
        public int TotalRow { get; set; }
    }

    public class ProductForSiteDto
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageSrc { get; set; }

    }
}
