using GraphQL.Types;

namespace Test.Api.GraphQL
{
    public class TestMutation : ObjectGraphType<object>
    {
        public TestMutation()
        { 
            Name = "TestMutation";           
        }
    }    

}
