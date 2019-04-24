import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Employee, EmployeeData } from '../models/employeemodel';
import { EmployeeDataService } from '../services/employeedata.service';
@Component({
  selector: 'app-employee-update',
  templateUrl: './employee-update.component.html'
})
export class EmployeeUpdateComponent implements OnInit {

  @Input() reset: boolean = false;
  @Input() isReset: boolean = false;
  @Input() employeeId: number;
  @Input() objemp: Employee = new Employee();

  @Output() resultFromComp = new EventEmitter<string>();

  constructor(private dataservice: EmployeeDataService, private route: Router) {
  }

  @ViewChild('closeBtn') cb: ElementRef;

  ngOnInit() {
    this.LoadInitialData(this.employeeId);
  }

  @ViewChild('editEmployeeForm') myForm: NgForm;

  LoadInitialData(employeeId) {
    this.dataservice.getEmployeeById(employeeId).subscribe((res) => {
      this.objemp.employeeId = res.employeeId;
      this.objemp.firstName = res.firstName;
      this.objemp.lastName = res.lastName;

      this.objemp.employeeData = new EmployeeData();
      this.objemp.employeeData.email = res.employeeData.email;
      this.objemp.employeeData.gender = res.employeeData.gender;
      this.objemp.employeeData.phone = res.employeeData.phone;
    })
      , err => {
        console.log(err);
      }
  }

  EditEmployee(regForm: NgForm) {

    this.dataservice.editEmployee(this.objemp).subscribe(res => {
      this.HandleResponse();
    })
  }

  HandleResponse() {
    alert("Employee updated successfully");
    this.resultFromComp.emit("result from update modal component");
  }
}
