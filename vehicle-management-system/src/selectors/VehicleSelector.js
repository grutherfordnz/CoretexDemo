export function getVehicles(state) {
  return state.vehicles;
}

export function getCreateVehiclesSuccess(state) {
  return state.createVehicleSuccess;
}

export function getAlertType(state) {
  return state.alert.type;
}

export function getAlertMessage(state) {
  return state.alert.message;
}