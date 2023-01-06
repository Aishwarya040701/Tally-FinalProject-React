import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import { useParams } from 'react-router-dom';
import swal from 'sweetalert';


function EmployeeDelete() {
    const { id } = useParams();
    const navigate = useNavigate();

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

    const HandleDelete = (e) => {
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover the Employee Data!",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    axios.delete("https://localhost:7107/api/Employees/" + id)
                        .then((res) => {
                            console.log(res);
                            
                            swal({
                                title: "Success!",
                                text: "Employee Deleted!",
                                icon: "success",
                                button: "ok!",
                            }).then((result) => {
                                if (result) {
                                    navigate("/")

                                }
                            });

                            // alert(JSON.stringify(res.data))
                        })
                        .catch(err => {
                            console.log(err);
                        });
                } else {
                    swal("Not deleted!");
                }
            })
        

    }

    return (
        <div className="container">
            <div className="card" >
            <div className="row" >
                <div className="offset-lg-1 col-lg-10">
                    <h2 className="bg-dark text-white">EmployeeDelete</h2>
                </div>
            </div>
            
            <div>
                
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

                        </div>

                    </div>

                }
            </div>



            <div>

                 <button className="btn btn-danger" onClick={HandleDelete}>Delete</button>
                 <Link to="/" className="btn btn-primary">Back to List</Link>
            </div>


            </div>
        </div>
        )

}
export default EmployeeDelete