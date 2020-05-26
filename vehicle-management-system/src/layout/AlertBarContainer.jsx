import { connect } from 'react-redux';
import {
  getAlertType,
  getAlertMessage
} from '../selectors/VehicleSelector';

import {
  closeAlertBar
} from '../actions/VehicleAction';
import Alertbar from './AlertBar';

const mapStateToProps = (state) => ({
  type: getAlertType(state),
  alertMessage: getAlertMessage(state)
});

const mapDispatchToProps = (dispatch) => ({
  onCloseAlertBar: () => dispatch(closeAlertBar())
});

const AlertbarContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(Alertbar);

export default AlertbarContainer;