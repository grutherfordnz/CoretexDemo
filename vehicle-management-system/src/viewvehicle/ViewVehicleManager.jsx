import React from 'react';
import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import Routes from '../routes';
import ViewVehicleRow from './ViewVehicleRow'

class ViewVehicleManager extends React.Component
{
  static get PropTypes() {
    return {
      vehicles: PropTypes.arrayOf(PropTypes.shape({
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
      })),
      getVehicles: PropTypes.func.isRequired,
      onUpdateVehicle: PropTypes.func.isRequired,
      onSubmitUpdateVehicle: PropTypes.func.isRequired,
      onDeleteVehicle: PropTypes.func.isRequired
    };
  }

  constructor(props) {
    super(props)

    this.state = {
      editMode: false,
      edit: {}
    };

    this.onChange = this.onChange.bind(this);
    this.onChangeEditMode = this.onChangeEditMode.bind(this);
  }
  
  componentWillMount() {
    this.props.getVehicles();
  }

  onChangeEditMode() {
    this.setState({
      editMode: !this.state.editMode
    });
  }
  
  onChange(vehicleId, propertyName, propertyValue) {
    this.props.onUpdateVehicle(vehicleId, propertyName, propertyValue);
  }

  render() {
    return (
      <div>
        <div className="vehicle-table">
          <div className="vehicle-table__row">
            <div className="col-sm-4 col-sm-offset-2">
              <Link
                className="btn btn-primary"
                to={Routes.VehiclePage.path}
              >
                Create New Vehicle
              </Link>
            </div>
          </div>
          <div className="vehicle-table__row vehicle-table__row--header">
            <div className="vehicle-table__column column-size__width-30">
              Vehicle Name
            </div>
            <div className="vehicle-table__column column-size__width-15">
              Vehicle Speed (km/h)
            </div>            
            <div className="vehicle-table__column column-size__width-15">
              Latitude
            </div>
            <div className="vehicle-table__column column-size__width-15">
              Longitude
            </div>
            <div className="vehicle-table__column column-size__width-15">
              Engine Temperature (°C)
            </div>
            <div className="vehicle-table__column column-size__width-15">
              Radiator Pressure (kPa)
            </div>
            <div className="vehicle-table__column column-size__width-15">
              Fuel Remaining (L)
            </div>
            <div className="vehicle-table__column column-size__width-19">
              Last Updated
            </div>
            <div className="vehicle-table__column column-size__width-19">
              Date Created
            </div>
            <div className="vehicle-table__column column-size__width-30"></div> 
          </div>    
          {
            this.props.vehicles.map((v) => 
              <ViewVehicleRow
                vehicleId={v.vehicleId}
                name={v.name}
                speed={v.speed}
                latitude={v.latitude}
                longitude={v.longitude}
                engineTemperature={v.engineTemperature}
                radiatorPressure={v.radiatorPressure}
                fuelRemaining={v.fuelRemaining}  
                updatedTimestamp={v.updatedTimestamp}
                createdTimestamp={v.createdTimestamp}
                editMode={this.state.editMode}
                onChange={(name, value) => {        
                  this.onChange(v.vehicleId, name, parseFloat(value));
                }}
                onSubmitUpdateVehicle={this.props.onSubmitUpdateVehicle}
                onChangeEditMode={this.onChangeEditMode}
                onDeleteVehicle={() => {
                  this.props.onDeleteVehicle(v.vehicleId);
                }}
              />
            )
          }
      </div>
    </div>  
    )
  }
}

ViewVehicleManager.propTypes = {
  onUpdateVehicle: PropTypes.func.isRequired,
  onSubmitUpdateVehicle: PropTypes.func.isRequired,
  onDeleteVehicle: PropTypes.func.isRequired
};


export default ViewVehicleManager;