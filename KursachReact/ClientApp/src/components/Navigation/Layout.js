import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import { useEffect } from 'react';

function Layout(props) {
  
  useEffect(() => {
    
  },[])
  

  return (
    <div>
      <NavMenu user={props.user}/>
      <Container>
        {props.children}
      </Container>
    </div>
  );
}

export default Layout;
