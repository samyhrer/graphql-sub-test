import * as React from "react";
import gql from "graphql-tag";
import { graphql } from "react-apollo";

class Datastream extends React.Component {
  constructor(props) {
    super(props);
    this.data = {};
  }
  render() {
    if (this.props.data.loading === true) {
      return null;
    }
    this.data[this.props.data.name] = this.props.data.value;
    return this.props.render(this.data);
  }
}

export default graphql(
  gql`
    subscription symbolUpdated($variableNames: [String]!) {
      symbolUpdated(variableNames: $variableNames) {
        value
        name
        timeStamp
      }
    }
  `,
  {
    options: props => {
      return {
        variables: {
          variableNames: props.variableNames
        }
      };
    }
  }
)(Datastream);
