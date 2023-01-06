import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function EmployeeCreate() {

    
    const [Name, setName] = useState("");
    const [Band, setBand] = useState("");
    const [Role, setRole] = useState("");
    const [Designation, setDesignation] = useState("");
    const [Responsibilities, setResponsibilities] = useState("");
    const navigate = useNavigate();

    const handleSubmit = (e) => {
        e.preventDefault();
        /*const formData = new FormData(form);*/
        const data = {name: Name, band: Band, role: Role, designation: Designation, responsibilities: Responsibilities }
        axios.post('https://localhost:7107/api/Employees', data)
            .then((res) => {
                console.log(res.data)
                swal({
                    title: "Success!!!",
                    text: "Employee Added Successfully!!!",
                    icon: "success",
                    button: "ok!",
                }).then((result) => {
                    if (result) {
                        navigate("/")

                    }
                });
                
                
            
            })
            .catch(err => console.log(err))


      
    }
       
    




    const handleReset = () => {

        setName("");
        setBand("");
         setRole("");
        setDesignation("");
        setResponsibilities("");

    }


    return (

        <div>
            <div className="row">
                <div className="offset-lg-3 col-lg-6">
                    
                    <form className="container" onSubmit={handleSubmit}>
                        <div className="card" style={{ "textAlign":"left" }}>
                            <div className="card-title">
                                <h2 className="bg-dark text-white" style={{ "textAlign": "center" }}>EmployeeCreate</h2>
                               

                             
                            </div>

                            <div className="row">

                               
                                <div className="col-lg-12">
                                    <div className="form-group">
                                        <lable>Name</lable>
                                        <input required value={Name} onChange={ e=>setName(e.target.value)} className="form-control"></input>
                                        
                                    </div>
                                </div>
                                <div className="col-lg-12">
                                    <div className="form-group">
                                        <lable>Band</lable>
                                        <input required value={Band} onChange={e => setBand(e.target.value)} className="form-control"></input>
                                        
                                    </div>
                                </div>

                                <div className="col-lg-12">
                                    <div className="form-group">
                                        <lable>Role</lable>
                                        <input required value={Role} onChange={e => setRole(e.target.value)} className="form-control"></input>
                                       
                                    </div>
                                </div>

                                <div className="col-lg-12">
                                    <div className="form-group">
                                        <lable>Designation</lable>
                                        <input required value={Designation} onChange={e => setDesignation(e.target.value)}  className="form-control"></input>
                                       
                                    </div>
                                </div>

                                <div className="col-lg-12">
                                    <div className="form-group">
                                        <lable>Responsibilities</lable>
                                        <input required value={Responsibilities} onChange={e => setResponsibilities(e.target.value)} className="form-control"></input>
                                        
                                    </div>
                                </div>

                                <div className="col-lg-12">
                                    <div className="form-group">
                                       
                                        <button className="btn btn-success" type="submit">Save</button>
                                        
                                        <Link to="/" className="btn btn-danger">Back to List</Link>
                                        <button className="btn btn-dark" onClick={handleReset} type="reset">Reset</button>
                                        

                                    </div> 
                                </div>

                            </div>

                        </div>
                    </form>
                </div>
            </div>
        </div>

       
      )

}

export default EmployeeCreate