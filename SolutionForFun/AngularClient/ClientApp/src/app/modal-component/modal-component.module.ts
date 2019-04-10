import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { EmployeeAddComponent } from '../employee-add/employee-add.component';
import { EmployeeUpdateComponent } from '../employee-update/employee-update.component';

import { NgbdModalComponent, NgbdModalContentAdd,NgbdModalContentUpdate } from './modal-component';

@NgModule({
  imports: [BrowserModule, FormsModule, NgbModule],
  declarations: [NgbdModalComponent, NgbdModalContentAdd, NgbdModalContentUpdate, EmployeeAddComponent, EmployeeUpdateComponent], 
  exports: [NgbdModalComponent],
  bootstrap: [NgbdModalComponent],
  entryComponents: [NgbdModalContentAdd, NgbdModalContentUpdate]
})
export class NgbdModalContentModule { }
