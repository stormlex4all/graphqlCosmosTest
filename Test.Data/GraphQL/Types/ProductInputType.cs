using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.GraphQL.Types
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInputType";
            //again tryin different definition ways
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
        }
    }
}
