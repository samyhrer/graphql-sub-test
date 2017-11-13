import { ApolloLink } from "apollo-client-preset";
import ApolloClient from "apollo-client-preset";
import { HttpLink } from "apollo-client-preset";
import { WebSocketLink } from "apollo-link-ws";
import { SubscriptionClient } from "subscriptions-transport-ws";
import { getOperationAST } from "graphql";
const wsClient = new SubscriptionClient("ws://localhost:50166/api/graphql", {
  reconnect: true
});

const apolloClient = new ApolloClient({
  link: ApolloLink.split(
    operation => {
      const operationAST = getOperationAST(
        operation.query,
        operation.operationName
      );
      return !!operationAST && operationAST.operation === "subscription";
    },
    new WebSocketLink(wsClient),
    new HttpLink({ uri: "http://localhost:50166/api/graphql" })
  )
});

export default apolloClient;
