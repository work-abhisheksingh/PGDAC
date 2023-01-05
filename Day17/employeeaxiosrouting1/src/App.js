import logo from './logo.svg';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';

import {BrowserRouter as Router,Route,Switch} from 'react-router-dom'
import EmployeeList from './components/EmployeeList';
import EmployeeAdd from './components/EmployeeAdd';
import Header from './components/Header';
import EmployeeEdit from './components/EmployeeEdit';
import EmployeeDetails from './components/EmployeeDetails';
function App() {
  return (
    <div>
       <Header></Header>
      <Router>
        <Switch>
          <Route path="/" exact component={EmployeeList}></Route>
          <Route path="/list" component={EmployeeList}></Route>
          <Route path="/addemp" component={EmployeeAdd}></Route>
          <Route path="/edit/:empid" component={EmployeeEdit}></Route>
          <Route path="/view/:empid" component={EmployeeDetails}></Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
