import { Component, OnInit, ViewChild, Input, EventEmitter, Output, ElementRef } from '@angular/core';
import { EmployeeDataService } from '../services/employeedata.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Employee } from '../models/employeemodel';
@Component({
  selector: 'app-employee-update',
  templateUrl: './employee-update.component.html'
})
export class EmployeeUpdateComponent implements OnInit {

  constructor(private dataservice: EmployeeDataService, private route: Router) {

  }

  @Output() nameEvent = new EventEmitter<string>();
  @ViewChild('closeBtn') cb: ElementRef;
  ngOnInit() {
  }

  @Input() reset: boolean = false;
  @ViewChild('editform') myForm: NgForm;
  @Input() isReset: boolean = false;
  objtempemp: Employee;
  @Input() objemp: Employee = new Employee();

  EditEmployee(regForm: NgForm) {

    this.dataservice.editEmployee(this.objemp).subscribe(res => {
      alert("Employee updated successfully");
      this.nameEvent.emit("ccc");
      this.cb.nativeElement.click();

    })
  }
}
