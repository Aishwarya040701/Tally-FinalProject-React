import React, { useState,useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { useParams } from 'react-router-dom';

function EmployeeDetails() {
    const { id } = useParams();

    const [Employees, setGetEmployeeById] = useState([]);

    useEffect(() => {
        axios.get("https://localhost:7107/api/Employees/" + id)
            .then((res) => {
                console.log(res);
                setGetEmployeeById(res.data);
                // alert(JSON.stringify(res.data))
            })
            .catch(err => {
                console.log(err);
            });
    }, []);

    return (
        <div className="container">
            <div className="card" >
            <div className="row" >
                <div className="offset-lg-1 col-lg-10">
                    <h2 className="bg-dark text-white">EmployeeDetails</h2>
                </div>
            </div>
            
            {

                Employees &&
                <div className="row">
                    <div className="offset-lg-1 col-lg-10">

                        <table className="table table-bordered  table-hover table-striped" >

                            <tbody className="border border-dark">

                                <tr>
                                    <td><h5>EmployeeId</h5></td>
                                    <td>{Employees.employeeId}</td>
                                </tr>

                                <tr >
                                    <td><h5>Name</h5></td>
                                    <td>{Employees.name}</td>
                                </tr>

                                <tr>
                                    <td><h5>Band</h5></td>
                                    <td>{Employees.band}</td>
                                </tr>

                                <tr>
                                    <td><h5>Role</h5></td>
                                    <td>{Employees.role}</td>
                                </tr>

                                <tr>
                                    <td><h5>Designation</h5></td>
                                    <td>{Employees.designation}</td>
                                </tr>

                                <tr>
                                    <td><h5>Responsibilities</h5></td>
                                    <td>{Employees.responsibilities}</td>
                                </tr>

                            </tbody>

                                </table>

                                <Link to="/" className="btn btn-primary">Back to List</Link>

                    </div>

                    </div>
               
                    
            }

            
        </div>
        </div>
    );

}
export default EmployeeDetails