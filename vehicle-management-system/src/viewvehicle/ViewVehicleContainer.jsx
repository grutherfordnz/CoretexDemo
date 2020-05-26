import { connect } from 'react-redux';

import { 
  fetchVehicles,
  updateVehicle,
  submitUpdatedVehicle,
  deleteVehicle
} from '../actions/VehicleAction';

import { getVehicles } from '../selectors/VehicleSelector';
import ViewVehicleManager from './ViewVehicleManager';

function mapStateToProps(state){
  return {
    vehicles: getVehicles(state)
  };
}

function mapDispatchToProps(dispatch) {
  return {
    getVehicles: () => dispatch(fetchVehicles()),
    onUpdateVehicle: (vehicleId, propertyName, propertyValue) => dispatch(updateVehicle(vehicleId, propertyName, propertyValue)),
    onSubmitUpdateVehicle: (vehicleId) => dispatch(submitUpdatedVehicle(vehicleId)),
    onDeleteVehicle: (vehicleId) => dispatch(deleteVehicle(vehicleId))
  };
}

const ViewVehicleContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(ViewVehicleManager);


export default ViewVehicleContainer;
