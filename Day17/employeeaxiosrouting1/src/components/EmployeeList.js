import { useEffect, useState} from "react";
import EmployeeService from './EmployeeService';
import {Link,useHistory} from 'react-router-dom';

const EmployeeList=()=>{
    let [emparr,setemparr] =useState([]);
    let [flag,setflag]=useState(false);
    let history=useHistory();
    //initialization data
    useEffect(()=>{
     EmployeeService.getEmployees().
     then((response)=>{
        console.log("in useffect of emplist initialization");
        console.log(response.data);
        setemparr(response.data);
     })
     .catch((err)=>{console.log("error occured",err)});

    },[]);
    useEffect(()=>{
        EmployeeService.getEmployees().
        then((response)=>{
           console.log("in useffect of emplist initialization");
           console.log(response.data);
           setemparr(response.data);
        })
        .catch((err)=>{console.log("error occured",err)});
   
       },[flag]); 
    const deleteData=(id)=>{
        EmployeeService.deleteEmployee(id)
        .then((result)=>{
            console.log(result.data);
           // history.push("/");
           setflag(true);
        })
        .catch((err)=>{
            console.log("error occured",err);
        })

    }
    const renderList=()=>{
        return emparr.map((emp)=>{
            return <tr key={emp.empid}><td>{emp.empid}</td><td>{emp.ename}</td><td>{emp.sal}</td>
            <td>
                <button type="button" className="btn btn-danger" name='btn' id="delete" onClick={()=>deleteData(emp.empid)}>Delete</button>
                &nbsp;&nbsp;&nbsp;
                <Link to={{pathname:`/edit/${emp.empid}`,state:{employee:emp}}}>
                     <button type="button" className="btn btn-primary" name='btn' id="edit">Edit</button>
                </Link>
                &nbsp;&nbsp;&nbsp;
                <Link to={{pathname:`/view/${emp.empid}`,state:{employee:emp}}}>
                    <button type="button" className="btn btn-success" name='btn' id="view">View</button>
                </Link>
            </td></tr>
        });
    }
    return(
        <div>
        <Link to="/addemp">
            <button type="button" name="btn" id="btn" className="btn btn-primary">Add Employee</button>
        </Link>
        <table border="2"><thead>
        <tr><th>Employee ID</th><th>Name</th><th>sal</th></tr>
        </thead>
        <tbody>
            {renderList()}
        </tbody>
        </table>
        </div>
    )
}

export default EmployeeList;