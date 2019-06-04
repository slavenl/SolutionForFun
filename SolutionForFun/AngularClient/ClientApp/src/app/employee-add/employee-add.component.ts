import { Component, OnInit, Input, ViewChild, ElementRef, EventEmitter, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { Employee, EmployeeData } from '../models/employeemodel';

import { EmployeeDataService } from '../services/employeedata.service'

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html'
})

export class EmployeeAddComponent implements OnInit {

  @Input() cleardata: boolean = false;
  @Input() objemp: Employee = new Employee();
  @Output() resultFromComp = new EventEmitter<string>();
  objtempemp: Employee;

  @ViewChild('closeBtn', { static: false }) cb: ElementRef;

  constructor(private dataservice: EmployeeDataService, private route: Router) {    
  }

  ngOnInit() {
    this.ResetValues();
  }

  ResetValues() {
    this.objemp = new Employee();
    this.objemp.employeeData = new EmployeeData();
  }

  Register(regForm: NgForm) {

    this.objtempemp = new Employee();
    this.objtempemp.firstName = regForm.value.firstName;
    this.objtempemp.lastName = regForm.value.lastName;

    this.objtempemp.employeeData = new EmployeeData();
    this.objtempemp.employeeData.gender = regForm.value.gender;
    this.objtempemp.employeeData.email = regForm.value.email;
    this.objtempemp.employeeData.phone = regForm.value.phone;

    this.dataservice.addEmployee(this.objtempemp).subscribe(res => {
      this.HandleResponse();
    })
  }

  HandleResponse() {
    alert("Employee Added successfully");
    this.resultFromComp.emit("result from add modal component");
   
  }

}
