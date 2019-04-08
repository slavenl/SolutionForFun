import { Component, OnInit, Input, ViewChild, ElementRef, EventEmitter, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { Employee } from '../models/employeemodel';

import { EmployeeDataService } from '../services/employeedata.service'

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html'  

})
export class EmployeeAddComponent implements OnInit {

  @Input() cleardata: boolean = false;
  @Output() nameEvent = new EventEmitter<string>();
  objtempemp: Employee;
  @Input() objemp: Employee = new Employee();;
  @ViewChild('closeBtn') cb: ElementRef;

  constructor(private dataservice: EmployeeDataService, private route: Router) {

  }

  ngOnInit() {
    // this.ResetValues();
  }

  ResetValues() {    
  }

  Register(regForm: NgForm) {

    this.objtempemp = new Employee();
    this.objtempemp.email = regForm.value.email;
    this.objtempemp.firstname = regForm.value.firstname;
    this.objtempemp.lastname = regForm.value.lastname;
    this.objtempemp.gender = regForm.value.gender;

    this.dataservice.AddEmployee(this.objtempemp).subscribe(res => {
      alert("Employee Added successfully");
      this.TakeHome();
    }
    )


  }
  TakeHome() {
    this.nameEvent.emit("ccc");
    this.cb.nativeElement.click();
    this.route.navigateByUrl('');
  }

}
