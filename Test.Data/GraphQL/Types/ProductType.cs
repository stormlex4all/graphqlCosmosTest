using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Entities;

namespace Test.Data.GraphQL.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            //if u choose the 'id' convention u have to follow it verbatim
            Field(name: "id", type: typeof(IdGraphType), description: "Id property from the Product object");

            Field(p => p.Name, type: typeof(StringGraphType)).Description("Name property from the Product object");
            Field<StringGraphType>(name: "Description", description: "Description property from the Product object");
            //choosing a diff ways of configuring the properites for learning purposes

        }
    }
}
