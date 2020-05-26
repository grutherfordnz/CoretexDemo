import React from 'react';
import { Link } from 'react-router-dom';
import PropTypes from 'prop-types';

import '../scss/styles.scss';

const getInputComponent = (inputName, value, onChange) => {
  return (
    <input
      name={inputName}
      type="number"
      placeholder="0"
      value={value}
      onChange={onChange}
      min="0.00"
    />
  )
}

const renderEditMode = (props) => {
  return (
    <div className="display-flex">
      <Link
        className="a-blue"
        onClick={props.onChangeEditMode}
      >
        Details
      </Link> 
      <div className="xs-right-margin xs-left-margin">|</div>        
      <Link
        className="a-blue"
        onClick={() => { 
          props.onSubmitUpdateVehicle(props.vehicleId)
          props.onChangeEditMode();
        }}
      >
        Submit
      </Link> 
      <div className="xs-right-margin xs-left-margin">|</div>    
      <Link
        className="a-blue"
        onClick={props.onDeleteVehicle}
      >
        Delete
      </Link>
    </div>
  );
}

const renderNonEditMode = (props) => {
  return (
    <div className="display-flex">
      <Link
        className="a-blue"
        onClick={props.onChangeEditMode}
      >
        Edit
      </Link> 
      <div className="xs-right-margin xs-left-margin">|</div>  
      {
      } 
      <Link
        className="a-blue"
        onClick={props.onDeleteVehicle}
      >
        Delete
      </Link>  
    </div>
  );
}

const ViewVehicleRow = (props) => {
  return (
    <div className="vehicle-table__row">
      <div className="vehicle-table__column column-size__width-30">
        {props.name}
      </div>
      <div className="vehicle-table__column column-size__width-15">
        {
          props.editMode ?
            getInputComponent('speed', props.speed, (evt) => props.onChange('speed', parseInt(evt.target.value))) : 
            props.speed 
        }
      </div>      
      <div className="vehicle-table__column column-size__width-15">
        {
          props.editMode ?
            getInputComponent('latitude', props.latitude, (evt) => props.onChange('latitude', parseFloat(evt.target.value))) : 
            props.latitude
        }
      </div>
      <div className="vehicle-table__column column-size__width-15">
        {
          props.editMode ?
            getInputComponent('longitude', props.longitude, (evt) => props.onChange('longitude', parseFloat(evt.target.value))) : 
            props.longitude
        }
      </div>      
      <div className="vehicle-table__column column-size__width-15">
        {
          props.editMode ?
            getInputComponent('engineTemperature', props.engineTemperature, (evt) => props.onChange('engineTemperature', parseFloat(evt.target.value))) : 
            props.engineTemperature
        }
      </div>
      <div className="vehicle-table__column column-size__width-15">
        {
          props.editMode ?
            getInputComponent('radiatorPressure', props.radiatorPressure, (evt) => props.onChange('radiatorPressure', parseFloat(evt.target.value))) : 
            props.radiatorPressure
        }
      </div>
      <div className="vehicle-table__column column-size__width-15">
        {
          props.editMode ?
            getInputComponent('fuelRemaining', props.fuelRemaining, (evt) => props.onChange('fuelRemaining', parseFloat(evt.target.value))) : 
            props.fuelRemaining
        }
      </div>
      <div className="vehicle-table__column column-size__width-19">
        {
          new Date(props.updatedTimestamp).toLocaleDateString('en-NZ')
        }
      </div>    
      <div className="vehicle-table__column column-size__width-19">
        {
          new Date(props.createdTimestamp).toLocaleDateString('en-NZ')
        }
      </div>    


      <div className="vehicle-table__column column-size__width-30">
        <div className="pull-right">
        {
          props.editMode ?
            renderEditMode(props) :
            renderNonEditMode(props)
        }
        </div> 
      </div>
         
    </div>
  );
}

ViewVehicleRow.propTypes = {
  vehicleId: PropTypes.string,
  name: PropTypes.string,
  speed: PropTypes.number,
  latitude: PropTypes.number,
  longitude: PropTypes.number,
  engineTemperature: PropTypes.number,
  radiatorPressure: PropTypes.number,
  fuelRemaining: PropTypes.number,  
  updatedTimestamp: PropTypes.string,
  createdTimestamp: PropTypes.string,
  editMode: PropTypes.bool.isRequired,
  onChange: PropTypes.func.isRequired,
  onSubmitUpdateVehicle: PropTypes.func.isRequired,
  onChangeEditMode: PropTypes.func.isRequired,
  onDeleteVehicle: PropTypes.func.isRequired
};

export default ViewVehicleRow;