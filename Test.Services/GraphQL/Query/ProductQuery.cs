using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.GraphQL.Types;
using Test.Interfaces;
using Test.Interfaces.IServices;

namespace Test.Services.GraphQL.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService service)
        {
            FieldAsync<ListGraphType<ProductType>>(
                name: "getAllProducts",
                description: "Returns list of product",
                resolve: async context =>
                {
                    try
                    {
                        return await service.GetAllProductsAsync();
                    }
                    catch (Exception ex)
                    {
                        throw new ExecutionError(ex.Message + " " + ex.StackTrace);
                    }
                });

            FieldAsync<ProductType>(
                name: "getProduct",
                description: "Returns a product by Id",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Product id" }),
                resolve: async context =>
                {
                    try
                    {
                        return await service.GetProductAsync(context.GetArgument<string>("id"));
                    }
                    catch (Exception ex)
                    {
                        throw new ExecutionError(ex.Message + " " + ex.StackTrace);
                    }
                });

        }
    }
}
