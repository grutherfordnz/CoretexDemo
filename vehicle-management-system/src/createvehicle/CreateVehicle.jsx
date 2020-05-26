import React from 'react';
import PropTypes from 'prop-types';

const CreateVehicle = (props) => {  
  const vehicle = props.vehicle;
  const speed = isNaN(vehicle.speed) ? '' : vehicle.speed;
  const latitude = isNaN(vehicle.latitude) ? '' : vehicle.latitude;
  const longitude = isNaN(vehicle.longitude) ? '' : vehicle.longitude;
  const engineTemperature = isNaN(vehicle.engineTemperature) ? '' : vehicle.engineTemperature;
  const radiatorPressure = isNaN(vehicle.radiatorPressure) ? '' : vehicle.radiatorPressure;
  const fuelRemaining = isNaN(vehicle.fuelRemaining) ? '' : vehicle.fuelRemaining;

  return(
    <>
      <p className="title-medium--light m-top-margin">Vehicle Details</p>
      <div className="full-size-form m-top-margin form-group"> 
        <div className="control__label">
          Vehicle Name
        </div>
        <input
          name="name"
          className={props.submitError ? 'control-has-error' : ''}
          type="text"
          value={vehicle.name}
          onChange={(evt) => props.onChange('name', evt.target.value)}           
        />
      </div>
      <div className="full-size-form form-group">
        <div className="control__label">
          Vehicle Speed (km/h)
        </div>        
        <input
          name="speed"
          type="number"
          placeholder="0"
          min="0"
          value={speed}
          onChange={(evt) => props.onChange('speed', parseInt(evt.target.value))}     
        />
      </div>
      <div className="full-size-form form-group">
        <div className="control__label">
          Latitude
        </div>        
        <input
          name="latitude"
          type="number"
          placeholder="0"
          min="0" 
          value={latitude}
          onChange={(evt) => props.onChange('latitude', parseFloat(evt.target.value))}     
        />
      </div>
      <div className="full-size-form form-group">
        <div className="control__label">
          Longitude
        </div>        
        <input
          name="latitude"
          type="number"
          placeholder="0"
          min="0"
          value={longitude}
          onChange={(evt) => props.onChange('longitude', parseFloat(evt.target.value))}     
        />
      </div>
      <div className="full-size-form form-group">
        <div className="control__label">
          Engine Temperature (°C)
        </div>        
        <input
          min={0}
          name="engineTemperature"
          type="number"
          placeholder="0"
          min="0"
          value={engineTemperature}
          onChange={(evt) => props.onChange('engineTemperature', parseFloat(evt.target.value))}    
        />     
      </div>
      <div className="full-size-form form-group">
        <div className="control__label">
          Radiator Pressure (kPa)
        </div>        
        <input
          min={0}
          name="radiatorPressure"
          type="number"
          placeholder="0"
          min="0"
          value={radiatorPressure}
          onChange={(evt) => props.onChange('radiatorPressure', parseFloat(evt.target.value))}    
        />     
      </div>   
      <div className="full-size-form form-group">
        <div className="control__label">
          Fuel Remaining (L)
        </div>        
        <input
          min={0}
          name="fuelRemaining"
          type="number"
          placeholder="0"
          min="0"
          value={fuelRemaining}
          onChange={(evt) => props.onChange('fuelRemaining', parseInt(evt.target.value))}    
        />     
      </div>
    </>
  );
}

CreateVehicle.propTypes = {
  vehicle: {
    name: PropTypes.string,
    speed: PropTypes.string,
    latitude: PropTypes.number,
    longitude: PropTypes.number,
    engineTemperature: PropTypes.number,
    radiatorPressure: PropTypes.number,
    fuelRemaining: PropTypes.number
  },
  submitError: PropTypes.bool.isRequired,
  onChange: PropTypes.func.isRequired
};

export default CreateVehicle;