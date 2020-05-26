import { connect } from 'react-redux';

import { submitNewVehicle } from '../actions/VehicleAction';
import { getCreateVehiclesSuccess } from '../selectors/VehicleSelector';

import CreateVehicleManager from './CreateVehicleManager'

function mapStateToProps(state){
  return {
    createVehicleSuccess: getCreateVehiclesSuccess(state)
  };
}

function mapDispatchToProps(dispatch) {
  return {
    submitNewVehicle: (vehicle) => dispatch(submitNewVehicle(vehicle)),
  };
}

const CreateVehicleContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(CreateVehicleManager);

export default CreateVehicleContainer;