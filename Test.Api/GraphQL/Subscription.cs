using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Test.Api.Model;

namespace Test.Api.GraphQL
{
    public class TestSubscription : ObjectGraphType<object>
    {
        private List<ReplaySubject<DomainValue>> _subscriptions = new List<ReplaySubject<DomainValue>>();
        private IObservable<long> _timer;

        public TestSubscription()
        {
            
            this._timer = Observable.Interval(TimeSpan.FromMilliseconds(500)).AsObservable();
            this._timer.Subscribe(x =>
            {
                Parallel.ForEach<ReplaySubject<DomainValue>>(this._subscriptions, (sub) =>
                {
                    sub.OnNext(new DomainValue
                    {
                        Name = "test",
                        Value = x.ToString()                        
                    });
                });
            });            
            
            AddField(new EventStreamFieldType
            {
                Name = "symbolUpdated",
                Type = typeof(DatastreamType),
                Resolver = new FuncFieldResolver<DomainValue>(ResolveSymbol),
                Subscriber = new EventStreamResolver<DomainValue>(Subscribe),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<ListGraphType<StringGraphType>>> { Name = "variableNames", Description = "variable Name in appsettings.json" }),
            });
        }

        private IObservable<DomainValue> Subscribe(ResolveEventStreamContext context)
        {            
            var stream = new ReplaySubject<DomainValue>(1);
            _subscriptions.Add(stream);            
            return stream;            
        }

        private DomainValue ResolveSymbol(ResolveFieldContext context)
        {            
            return context.Source as DomainValue;

        }
    }
}

