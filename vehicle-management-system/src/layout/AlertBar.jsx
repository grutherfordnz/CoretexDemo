import React from 'react';
import PropTypes from 'prop-types';

export default class Alertbar extends React.Component {
  static get PropTypes() {
    return {
      alertMessage: PropTypes.string,
      type: PropTypes.string,
      onCloseAlertBar: PropTypes.func.isRequired
    };
  }
  componentDidMount() {
    if (this.props.alertMessage) {
      setTimeout(this.props.onCloseAlertBar, 5000);
    }
  }

  componentDidUpdate(prevProps) {
    if (prevProps.alertMessage !== this.props.alertMessage && this.props.alertMessage) {
      setTimeout(this.props.onCloseAlertBar, 5000);
    }
  }

  render() {
    if (!this.props.alertMessage) {
        return null;
    }

    return (
      <div className={`alert-bar--${this.props.type}`}>
        {this.props.alertMessage}
      </div>
    );
  }
}