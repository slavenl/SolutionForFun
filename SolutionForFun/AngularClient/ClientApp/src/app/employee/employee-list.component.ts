import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

import { Employee } from '../models/employeemodel'
import { EmployeeDataService } from '../services/employeedata.service'
import { EmployeeAddComponent } from '../employee-add/employee-add.component';
import { EmployeeUpdateComponent } from '../employee-update/employee-update.component';

@Component({
  selector: 'app-angular-crud',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']

})
export class CRUDComponent implements OnInit {

  emplist: Employee[];
  dataavailable: Boolean = false;
  tempemp: Employee

  constructor(private dataservice: EmployeeDataService, private route: Router) {
  }

  ngOnInit() {
    this.LoadData();
  }

  LoadData() {
    this.dataservice.getEmployee().subscribe((tempdate) => {
      this.emplist = tempdate;
      console.log(this.emplist);
      if (this.emplist.length > 0) {
        this.dataavailable = true; 
      }
      else {
        this.dataavailable = false;
      }
    }
    )
      , err => {
        console.log(err);
      }
  }

  deleteconfirmation(id: string) {

    if (confirm("Are you sure you want to delete this ?")) {
      this.tempemp = new Employee();
      this.tempemp.employeeid = id;
      this.dataservice.DeleteEmployee(this.tempemp).subscribe(res => {
        alert("Deleted successfully !!!");
        this.LoadData();
      })
    }
  }

  @ViewChild('empadd') addcomponent: EmployeeAddComponent
  @ViewChild('editform') editcomponent: EmployeeUpdateComponent

  loadaddnew() {  
    this.addcomponent.objemp.email = "";
    this.addcomponent.objemp.firstname = "";
    this.addcomponent.objemp.lastname = "";
    this.addcomponent.objemp.employeeid = "";
    this.addcomponent.objemp.gender = 0;
    console.log(this.addcomponent.objemp.gender);
    
  }

  loadnewform(employeeid: string, email: string, firstname: string, lastname: string, gender: number) {
    console.log(gender);
    this.editcomponent.objemp.email = email;
    this.editcomponent.objemp.firstname = firstname;
    this.editcomponent.objemp.lastname = lastname;
    this.editcomponent.objemp.employeeid = employeeid;
    this.editcomponent.objemp.gender = gender;
    console.log(this.addcomponent.objemp.gender);    
  }

  refreshdata() {
    this.LoadData();
  }
} 
