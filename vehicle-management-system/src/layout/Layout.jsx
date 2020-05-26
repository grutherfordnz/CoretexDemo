import React from 'react';
import PropTypes from 'prop-types';
import '../scss/styles.scss';
import AlertbarContainer from './AlertBarContainer';


class Layout extends React.Component {
	static get propTypes() {
		return {
			childer: PropTypes.object
		};
	}

	constructor(props) {
		super(props);
	}

	render() {
		return (
			<div>
			  <AlertbarContainer />	
				<div id="home-page">
					<div className="col-xs-4 home-page-header">
						<div className="title-medium--light">
							Vehicle Management System
						</div>						
					</div>
					<div className="container-fluid clearfix">
						<div className="home-page-container">
							{this.props.children}
						</div>
					</div>					
				</div>
			</div>
		);
	}
}

export default Layout;
