using GraphQL.Types;
using Test.Api.Model;

namespace Test.Api.GraphQL
{
    public class DatastreamType : ObjectGraphType<DomainValue>
    {
        public DatastreamType()
        {
            Name = "DatastreamType";
    
            Field(w => w.Name, nullable: false)
                .Description("The name of the field.");
    
            Field(w => w.Value, nullable: true)
                .Description("The value of the field.");
    
            Field(w => w.TimeStamp, nullable: true)
                .Description("The Timestamp of the field.");    
        }
    }
}