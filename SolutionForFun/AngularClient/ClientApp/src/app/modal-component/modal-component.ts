import { Component, Input, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EmployeeDataService } from '../services/employeedata.service'
import { Router } from '@angular/router';


@Component({
  selector: 'ngbd-modal-content-Add',
  template: `
    <div class="modal-header">
      <h4 class="modal-title">Add new employee</h4>
      <button type="button" class="close" aria-label="Close" (click)="activeModal.dismiss('Cross click')">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">      
      <app-employee-add #addEmployeeForm (resultFromComp)="RefreshDataTriggeredByComponent($event)"></app-employee-add>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-dark" name="closeBtn" id="closeBtn" #closeBtn (click)="activeModal.close('Close click') ">Close</button>
    </div>
  `
})

export class NgbdModalContentAdd {
  @Input() name;

  @ViewChild('closeBtn') cb: ElementRef;

  constructor(public activeModal: NgbActiveModal, private router: Router) {
  }
  RefreshDataTriggeredByComponent(message: string) {
    console.log("tu sam - " + event);
    this.cb.nativeElement.click();
    this.router.navigateByUrl('/crud/path?refresh=1');
  }
}

@Component({
  selector: 'ngbd-modal-content-Update',
  template: `
    <div class="modal-header">
      <h4 class="modal-title">Edit employee {{name}}</h4>
      <button type="button" class="close" aria-label="Close" (click)="activeModal.dismiss('Cross click')">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">      
      <app-employee-update #editEmployeeForm (resultFromComp)="RefreshDataTriggeredByComponent($event)" [isReset]="resetForm" [employeeId]="employeeId"></app-employee-update>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-dark" name="closeBtn" id="closeBtn" #closeBtn (click)="activeModal.close('Close click') ">Close</button>
    </div>
  `
})

export class NgbdModalContentUpdate {
  @Input() employeeId;

  @ViewChild('closeBtn') cb: ElementRef;

  constructor(public activeModal: NgbActiveModal, private router: Router) {

  }
  RefreshDataTriggeredByComponent(message: string) {
    console.log("tu sam - " + event);
    this.cb.nativeElement.click();
    this.router.navigateByUrl('/crud/path?refresh=1');
  }
}



@Component({
  selector: 'ngbd-modal-component',
  templateUrl: './modal-component.html'
})

export class NgbdModalComponent {
  @Input() id;
  @Output() resultFromComp = new EventEmitter<string>();

  constructor(private modalService: NgbModal) {

  }

  OpenModalDialog() {
    switch (this.id) {
      case 0:
        this.modalService.open(NgbdModalContentAdd);
        //modalRef.componentInstance.name = 'Add';
        break;
      default:
        this.modalService.open(NgbdModalContentUpdate).componentInstance.employeeId = this.id;
        break;
    }
  }



}
