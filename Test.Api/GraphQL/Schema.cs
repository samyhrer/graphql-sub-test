using GraphQL;
using GraphQL.Types;

namespace Test.Api.GraphQL
{
    public class TestSchema : Schema
    {
        public TestSchema()
        {
            Query = new TestQuery();            
            Subscription = new TestSubscription();
        }
    }
}
