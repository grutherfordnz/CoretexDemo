import axios from 'axios';
import Routes from '../routes';

import ActionTypes from '../actiontypes/VehicleActionTypes'

export function submitUpdatedVehicle(vehicleId) {
  return (dispatch, getState) => {
    dispatch({ type: ActionTypes.SUBMITTING_UPDATED_VEHICLE });

    const vehicles = getState().vehicles;
    const updatedVehicle = vehicles
      .find(vehicle => vehicle.vehicleId === vehicleId);    
      
    return axios.put(process.env.REACT_APP_VEHICLE_API_URL, updatedVehicle)
      .then(response => {
        if (response.status === 200) {
          dispatch({ 
            type: ActionTypes.SUBMIT_UPDATED_VEHICLE_SUCCESS,
            alertType: 'success',
            alertMessage: 'Vehicle successfully updated'
          });         
        } else {
          dispatch({ 
            type: ActionTypes.SUBMIT_UPDATED_VEHICLE_FAILED,
            alertType: 'fail',
            alertMessage: 'Something went wrong'
          });            
        }
      })    
  }  
}

export function submitNewVehicle(newVehicle) {
  return (dispatch) => {
    dispatch({ type: ActionTypes.SUBMITTING_CREATED_VEHICLE });
      
    return axios.post(process.env.REACT_APP_VEHICLE_API_URL, newVehicle)
      .then(response => {     
        if (response.status === 200) {
          dispatch({ 
            type: ActionTypes.SUBMIT_CREATED_VEHICLE_SUCCESS,
            alertType: 'success',
            alertMessage: 'Vehicle successfully submitted'
          }); 
          window.location = Routes.HomePage.path;
        } else {
          dispatch({ 
            type: ActionTypes.SUBMIT_CREATED_VEHICLE_FAILED,
            alertType: 'fail',
            alertMessage: 'Something went wrong'
          });  
        }
      })
      .catch(() => {
        dispatch({ 
          type: ActionTypes.SUBMIT_CREATED_VEHICLE_FAILED,
          alertType: 'fail',
          alertMessage: 'Something went wrong'
        });   
      })
  }    
}

export function deleteVehicle(vehicleIdToDelete) {
  return (dispatch, getState) => {
    dispatch({ type: ActionTypes.DELETING_VEHICLE });

    const vehicleCount = getState().vehicles.length;
    if (vehicleCount <= 1) {
      dispatch({ 
        type: ActionTypes.DELETE_VEHICLE_FAILED,
        alertType: 'fail',
        alertMessage: 'At least 1 vehicle must always exist'
      });  
    } else {
      return axios.delete(`${process.env.REACT_APP_VEHICLE_API_URL}/${vehicleIdToDelete}`)
      .then(response => {     
        if (response.status === 200) {
          dispatch({ 
            type: ActionTypes.DELETE_VEHICLE_SUCCESS,
            alertType: 'success',
            alertMessage: 'Vehicle successfully deleted'
          }); 
          dispatch(fetchVehicles());
        } else {
          dispatch({ 
            type: ActionTypes.DELETE_VEHICLE_FAILED,
            alertType: 'fail',
            alertMessage: 'Something went wrong'
          });  
        }
      })
      .catch(() => {
        dispatch({ 
          type: ActionTypes.DELETE_VEHICLE_FAILED,
          alertType: 'fail',
          alertMessage: 'Something went wrong'
        });   
      })   
    }
  }      
}

export function fetchVehicles() {
  console.log(process.env.REACT_APP_VEHICLE_API_URL);
  return (dispatch) => {
    dispatch({ type: ActionTypes.FETCHING_VEHICLE_DETAILS });
    return axios.get(process.env.REACT_APP_VEHICLE_API_URL)
      .then(response => {
        if (response.status === 200)
        {
          const vehicles = response.data.map(vehicle => {
            return {
              vehicleId: vehicle.vehicleId,
              name: vehicle.name,
              speed: vehicle.speed,
              latitude: vehicle.latitude,
              longitude: vehicle.longitude,
              engineTemperature: vehicle.engineTemperature,
              radiatorPressure: vehicle.radiatorPressure,
              fuelRemaining: vehicle.fuelRemaining,
              updatedTimestamp: vehicle.updatedTimestamp,
              createdTimestamp: vehicle.createdTimestamp
            }
          });

          dispatch({ 
            type: ActionTypes.FETCHING_VEHICLES_SUCCESS,
            data: vehicles
          });
        }
      });
  }
}

export function closeAlertBar() {
  return (dispatch) => {
    dispatch({ type: ActionTypes.CLOSE_ALERT_BAR });
  };  
}

export function updateVehicle(vehicleId, propertyName, propertyValue) {
  return {
    type: ActionTypes.EDIT_VEHICLE_PROPERTY,
    data: {
      vehicleId,
      name: propertyName,
      value: propertyValue
    }
  }  
}