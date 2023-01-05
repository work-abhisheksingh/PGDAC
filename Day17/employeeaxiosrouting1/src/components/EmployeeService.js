import axios from 'axios';

class EmployeeService{
    constructor(){
        this.baseUrl="http://localhost:4000/";
   }
    getEmployees(){
        return axios.get(this.baseUrl+"employee");
    }

    addEmployee(emp){
        return axios.post(this.baseUrl+"employee",emp)
    }

    deleteEmployee(id){
        return axios.delete(this.baseUrl+"employee/"+id)

    }
    updateemeployee(emp){
        return axios.put(this.baseUrl+"employee/"+emp.empid,emp)
    }

}

export default new EmployeeService();