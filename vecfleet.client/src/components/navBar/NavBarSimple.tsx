import Navbar from 'react-bootstrap/Navbar';
import { Link } from 'react-router-dom';
import logo from '/vec-logo-1.jpeg'

function NavBarSimple() {
  return (
    <Navbar style={{ backgroundColor: "#591987" }} expand="lg">
      <Navbar.Brand><Link to={"/"}><img src={logo} className='mx-10 h-16' /></Link></Navbar.Brand>
    </Navbar>
  );
}

export { NavBarSimple };