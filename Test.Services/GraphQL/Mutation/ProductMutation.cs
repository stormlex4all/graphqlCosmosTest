using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;
using Test.Data.GraphQL.Types;
using Test.Interfaces.IServices;

namespace Test.Services.GraphQL.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService service)
        {
            //for creating
            Name = "ProductMutation";
            FieldAsync<ProductType>(
                name: "addProduct",
                description: "Is used to add a new product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>>
                    {
                        Name = "product",
                        Description = "product input to create"
                    }
                ),
                resolve: async context =>
                {
                    try
                    {
                        var course = context.GetArgument<Product>("product");
                        return await service.SaveProductAsync(course);
                    }
                    catch (Exception ex)
                    {
                        throw new ExecutionError(ex.Message + " " + ex.StackTrace);
                    }
                });


            //for updating
            FieldAsync<ProductType>(
                name: "updateProduct",
                description: "Is used to update the product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "ProductId" },
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product", Description = "product details to update" }
                ),
                resolve: async context =>
                {
                    try
                    {
                        var id = context.GetArgument<string>("id");
                        var product = context.GetArgument<Product>("product");
                        return await service.UpdateProductAsync(id, product);
                    }
                    catch (Exception ex)
                    {
                        throw new ExecutionError(ex.Message + " " + ex.StackTrace);
                    }
                });


            //for deletion
            FieldAsync<BooleanGraphType>(
                name: "deleteProductById",
                description: "Is used to delete a product using the product id",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "Product id of the product to be deleted" }
                ),
                resolve: async context =>
                {
                    string id = context.GetArgument<string>("id");
                    try 
                    { 
                        await service.DeleteProductAsync(id);
                    } 
                    catch(Exception ex)
                    {
                        throw new ExecutionError(ex.Message + " " + ex.StackTrace);
                    }
                    return true;
                });

        }
    }
}
