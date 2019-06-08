import React from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

export default class HomeNavMenu extends React.Component {
  constructor (props) {
    super(props);

    this.toggle = this.toggle.bind(this);
    this.state = {
      isOpen: false
    };
  }
  toggle () {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }
  render () {
    return (
      <header>
        
       <Navbar className=" navbar-expand-lg navbar-light bg-light lo-navbar">
       <NavbarToggler onClick={this.toggle} className="navbar-toggler-right align-self-center mt-3" />
   
        <NavbarBrand tag={Link} to="/" className="order-lg-last order-0 lo-brand" >
          <img alt="لوپاک - مدیریت پسماند و بازیافت" src="/assets/home/logo.png" />
        </NavbarBrand>

        <Collapse className=" navbar-collapse flex-column" isOpen={this.state.isOpen} navbar>
          <ul className="navbar-nav justify-content-start mb-2 lo-navbar-sec">
            <li className="nav-item px-3">
              <h3 className="lo-contact-num">021-75038004   <img src="/assets/home/headphones.png" alt="" /></h3>
            </li>
            <div className="v-devider d-none d-lg-block" />
            <NavItem className="px-4 my-2">
            <NavLink tag={Link} to="/Dashboard" className="nav-link btn btn-outline-primary lo-btn" >ورود به داشبورد </NavLink>
            </NavItem>
{/*             <li className="nav-item my-2">
              <div className="searchbar">
                <input className="search_input" type="text" name placeholder="جستجو..." />
                <a  className="search_icon"><i className="fa fa-search" /></a>
              </div>
            </li> */}
          </ul>
          <ul className="navbar-nav flex-md-row-reverse justify-content-between pt-3 lo-navbar-main">
            <NavItem>
            <NavLink tag={Link} to="/">صفحه اصلی </NavLink>
            </NavItem>
            <NavItem>
            <NavLink tag={Link} to="/">دانلود اپلیکیشن </NavLink>
            </NavItem>
            <NavItem>
            <NavLink tag={Link} to="/">خدمات رانندگان </NavLink>
            </NavItem>
            <NavItem>
            <NavLink tag={Link} to="/">بلاگ </NavLink>
            </NavItem>
            <NavItem>
            <NavLink tag={Link} to="/">درباره ما</NavLink>
            </NavItem>
          </ul>
        </Collapse>
      </Navbar>
    </header>
    );
  }
}