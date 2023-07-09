import React from "react";
import { BrowserRouter as Router, Routes, Route, } from "react-router-dom"
import './App.css';
import HomePage from "./Components/HomePage";
import Admin from './Components/Admin';
import User from './Components/User';
import AdminPage from './Components/AdminPage';
import UserPage from './Components/UserPage';
import MedicineList from "./Components/MedicineList";
import AddMedicine from "./Components/AddMedicine";
import RemoveMedicine from "./Components/RemoveMedicine";
import RequestMedicine from "./Components/RequestMedicine";
import NewRequest from "./Components/NewRequest";
import UpdateMedicine from "./Components/UpdateMedicine";
import Feedback from "./Components/Feedback";
import ViewFeedback from "./Components/ViewFeedback";
import About from "./Components/About";
import Navbar from './Components/Navbar';
import SearchMedicine from './Components/SearchMedicine';


function App() {
  return (
    <div className="App">
      <Router>
         <Navbar/>


        <Routes>
          <Route path="/">
          <Route path="/HomePage" element={<HomePage/>}/>
          <Route path="/Admin" element={<Admin/>}/>
          <Route path="/AdminPage" element={<AdminPage/>}/>
          <Route path="/UserPage" element={<UserPage/>}/>
          <Route path="/User" element={<User/>}/>
          <Route path="/About" element={<About/>}/>
          <Route path="/MedicineList" element={<MedicineList />} />
          <Route path="/AddMedicine" element={<AddMedicine/>} />
          <Route path="/UpdateMedicine" element={<UpdateMedicine />} />
          <Route path="/RequestMedicine" element={<RequestMedicine/>} />
          <Route path="/RemoveMedicine" element={<RemoveMedicine/>} />
          <Route path="/NewRequest" element={<NewRequest/>} />
          <Route path="/Feedback" element={<Feedback/>} />
          <Route path="/ViewFeedback" element={<ViewFeedback/>} />
          <Route path="/SearchMedicine" element={<SearchMedicine/>} />
          
          </Route>
        </Routes>
      </Router>
    </div>
  );
}

export default App;