import React from 'react';
import PropTypes from 'prop-types';

import { Button } from 'reactstrap';
import { Link } from 'react-router-dom';

import Routes from '../routes';
import CreateVehicle from './CreateVehicle';

class CreateVehicleManager extends React.Component 
{
  static get PropTypes() {
    return {
      submitNewVehicle: PropTypes.func.isRequired
    };
  }

  constructor(props) {
    super(props);  

    this.state = {
      vehicle: {
        name: '',
        speed: 0,
        latitude: 0,
        longitude: 0,
        engineTemperature: 0,
        radiatorPressure: 0,
        fuelRemaining: 0
      },
      submitError: true
    };

    this.onSubmit = this.onSubmit.bind(this);
    this.onChange = this.onChange.bind(this);
    this.validateForm = this.validateForm.bind(this);
  }


  validateForm(submitFormIfValidCallBack) {
    const submitError = !this.state.vehicle.name

    this.setState(
        { submitError }, () => submitFormIfValidCallBack(submitError)
    );
  }  

  onSubmit() {
    this.validateForm(
      (inValid) => {
        if (!inValid) {
          this.props.submitNewVehicle(this.state.vehicle);
        }
      }
    );
  }

  onChange(prop, value) {
    const updatedVehicle = { ...this.state.vehicle }
    updatedVehicle[prop] = value;

    this.setState({ 
      vehicle: updatedVehicle 
    }, () => {
      if (prop === 'name'){
        this.setState({
          submitError: !this.state.vehicle.name
        })
      }
    });
  }

  render() {
    return (
      <div className="vehicle-view vehicle-view__centered-set-width">
        <div className="vehicle-view-box">
          <CreateVehicle
            vehicle={this.state.vehicle}
            submitError={this.state.submitError}
            onChange={this.onChange}
          />    
          <div className="row l-top-margin xl-bottom-margin">
            <div className="col-sm-4 col-sm-offset-2 m-bottom-margin">
              <Link
                className="btn btn-warning"
                to={Routes.HomePage.path}
              >
                Cancel
              </Link>
            </div>
            <div className="col-sm-8">
              <Button
                className="btn btn-primary"
                data-test="submitForm"
                disabled={this.state.submitError}
                onClick={this.onSubmit}
              >
                Submit
              </Button>
            </div>
          </div> 
        </div>
      </div>        
    );
  }
}

export default CreateVehicleManager;