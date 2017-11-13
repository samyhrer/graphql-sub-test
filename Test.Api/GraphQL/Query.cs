using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Api.GraphQL
{
    public class TestQuery : ObjectGraphType<object>
    {
        public TestQuery()
        {
            Name = "TestQuery";
            Field<ListGraphType<StringGraphType>>("variables", resolve: context => new List<StringGraphType>());
        }
    }
}

