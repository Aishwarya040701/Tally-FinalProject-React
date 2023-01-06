import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';



function EmployeeManagement() {
    const [Employees, setGetEmployees] = useState([]);
    const [value, setValue] = useState("");
    const [search, setSearch] = useState("");
  

    let time = new Date().toLocaleTimeString();
    const [CurrentTime, setCurrentTime] = useState(time);
    const navigate = useNavigate();

    const updateTime = (format) => {
        if (format == '24HrFormat') {

            let d = new Date();
            let h = d.getHours();
            let m = d.getMinutes();
            let s = d.getSeconds();
            let time = h + ":" + m + ":" + s;
            setCurrentTime(time);
     

        } else if (format == '12HrFormat'){
            let time = new Date().toLocaleTimeString();
           
            setCurrentTime(time);
           

        }


       
    }

    setInterval(updateTime,1000);
  
    const HandleDetails = (id) => {
        navigate("/employee/details/" + id);

    }


    const HandleEdit = (id) => {
        navigate("/employee/edit/" + id);

    }


    const HandleDelete = (id) => {
        navigate("/employee/delete/" + id);

    }

    const load = (e) => {
        e.preventDefault();
        setSearch(value);

    }

    const reset = (e) => {
        e.preventDefault();
        
        setValue('');
        setSearch('');

    }

    const getdata = () => {
        return axios.get('https://localhost:7107/api/Employees')


            .then((res) => {
                console.log(res);

                setGetEmployees(res.data);

            })
            .catch(err => {
                console.log(err);
            });

    }

  
   
    useEffect(() => {
        getdata();
    
    }, []);

   return(
        <div className="container">
            <div className="card">
              <div className="card-title">
                  <div className="row" >
                      <div className="offset-lg-3 col-lg-6">
                          <h2 className="bg-dark text-white">EmployeeManagement</h2>
                      </div>
                  </div>
                  
                  <div className="divbtn">
                      <h4>{CurrentTime}</h4>
                      <select className="bg-secondary text-white" onClick={(e) => updateTime(e.target.value)}>
                         
                          <option>12HrFormat</option>
                          <option>24HrFormat</option>
                      </select>
                  </div>
                  
              </div>
                 
              <div className="card-body">
                    <div className="divbtn">
                       <Link to="employee/create" className="btn btn-success">Add New</Link>
                  </div>


           
           <div className="row" >
              <div className="offset-lg-9 col-lg-6">
                  <div className="col-lg-4" align="center">
                      <form onSubmit={load}>

                          <input value={value} onChange={e => setValue(e.target.value)} placeholder="Search.." className="form-control"></input>
                          <button className="btn btn-success" type="submit">Search</button>
                          <button onClick={reset} className="btn btn-danger" >Reset</button>


                      </form>
                     </div>
                          </div> 
                      </div>
                  </div>



                    <table className="table table-bordered table-hover table-striped">
                       <thead className="bg-dark text-white">
                          <tr>
                              <th>ID</th>
                              <th>Name</th>
                              <th>Band</th>
                              <th>Role</th>
                              <th>Designation</th>
                              <th> Responsibility</th>
                              <th>Operations</th>
                           </tr>
                       </thead>
                      <tbody > 
                          {
                              Employees &&
                              Employees.filter(searchValue => {
                                  if (search === '') {
                                      return searchValue;
                                  } else if (searchValue.designation.toLowerCase().includes(search.toLowerCase())) {
                                      return searchValue;
                                  }
                              }).map((emp,index) => (
                                  <tr key={index}>
                                      <td>{emp.employeeId}</td>
                                      <td>{emp.name}</td>
                                      <td>{emp.band}</td>
                                      <td>{emp.role}</td>
                                      <td>{emp.designation}</td>
                                      <td>{emp.responsibilities}</td>
                                      <td>
                                         
                                          <a onClick={() => { HandleDetails(emp.employeeId)}} className="btn btn-primary">Details</a>
                                          <a onClick={() => { HandleEdit(emp.employeeId)}} className="btn btn-success">Edit</a>
                                          
                                          <a onClick={() => { HandleDelete(emp.employeeId)}} className="btn btn-danger">Delete</a>

                                      </td>
                                  </tr>

                              ))
                          }
                      </tbody>
                  </table>
  
                </div>

       

        </div>
     );
}

export default EmployeeManagement;