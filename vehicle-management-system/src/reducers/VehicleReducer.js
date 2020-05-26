import ActionTypes from '../actiontypes/VehicleActionTypes';

const initialState = {
  vehicles: [],
  alert: {
    type: '',
    message: ''
  }
};

export default function VehicleReducer(state = initialState, action) {
  switch (action.type) {
    case ActionTypes.EDIT_VEHICLE_PROPERTY:
      const updatedVehicles = state.vehicles.map(vehicle => {
        if (vehicle.vehicleId === action.data.vehicleId) {
          return {
            ...vehicle,
            [action.data.name]: action.data.value
          }
        }
        return vehicle;
      });

      return {
        ...state,
        vehicles: updatedVehicles
      }
    case ActionTypes.FETCHING_VEHICLES_SUCCESS:
      return {
        ...state,
        vehicles: action.data
      }
    case ActionTypes.SUBMIT_CREATED_VEHICLE_SUCCESS:
      return {
        ...state,
        alert: {
          type: action.alertType,
          message: action.alertMessage
        }
      }
    case ActionTypes.SUBMIT_CREATED_VEHICLE_FAILED:
      return {
        ...state,
        alert: {
          type: action.alertType,
          message: action.alertMessage
        }
      }     
    case ActionTypes.DELETE_VEHICLE_SUCCESS:
      return {
        ...state,
        alert: {
          type: action.alertType,
          message: action.alertMessage
        } 
      }
    case ActionTypes.DELETE_VEHICLE_FAILED:
      return {
        ...state,
        alert: {
          type: action.alertType,
          message: action.alertMessage
        }
      }
    case ActionTypes.SUBMIT_UPDATED_VEHICLE_SUCCESS:
      return {
        ...state,
        alert: {
          type: action.alertType,
          message: action.alertMessage
        }
      }
    case ActionTypes.SUBMIT_UPDATED_VEHICLE_FAILED:
      return {
        ...state,
        alert: {
          type: action.alertType,
          message: action.alertMessage
        }
      }      
    case ActionTypes.CLOSE_ALERT_BAR:
      return {
        ...state,
        alert: {
          type: null,
          message: null
        }
      } 
    default:
      return state;
  }
}