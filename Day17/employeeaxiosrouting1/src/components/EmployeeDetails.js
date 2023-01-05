import { useEffect,useState } from "react";
import {useLocation,Link} from 'react-router-dom'

const EmployeeDetails=(props)=>{
    let [empob,setempob]=useState({empid:"",ename:"",sal:""});
    let state=useLocation().state;
    useEffect(()=>{
        setempob({...state.employee})
    },[])
return(
    <div>
        <div className="card" style={{"width": "18rem"}}>
  <div className="card-body">
    <h5 className="card-title">Employee Details</h5>
    <h6 className="card-subtitle mb-2 text-muted">{empob.empid}</h6>
    <p className="card-text">
        Id: {empob.empid}
        Name : {empob.ename} <br/>
        Salary : {empob.sal}
    </p>
    <Link to="/list">
         <button type="button" name="btn" id="btn" className="btn btn-success">Back</button>
    </Link>
  </div>
</div>
    </div>
)
}

export default EmployeeDetails;