import logo from './logo.svg';
import './App.css';

import {  useState } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import EmployeeManagement from './components/EmployeeManagement';
import EmployeeCreate from './components/EmployeeCreate';
import EmployeeDetails from './components/EmployeeDetails';
import EmployeeEdit from './components/EmployeeEdit';
import EmployeeDelete from './components/EmployeeDelete';



function App() {
   

  return (
      <div className="App">

          <BrowserRouter>
              <Routes>
                  <Route path="/" element={<EmployeeManagement />} />
                  <Route path="/employee/create" element={<EmployeeCreate />} />
                  <Route path="/employee/edit/:id" element={<EmployeeEdit />} />
                  <Route path="/employee/delete/:id" element={<EmployeeDelete />} />
                  <Route path="/employee/details/:id" element={<EmployeeDetails />} />

              </Routes>
          </BrowserRouter>
          

      </div>
        
   );
   
 }

export default App;
