import { Component, Input } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';


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
      <app-employee-add #empadd (nameEvent)="refreshdata($event)"></app-employee-add>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-dark" (click)="activeModal.close('Close click')">Close</button>
    </div>
  `
})

export class NgbdModalContentAdd {
  @Input() name;

  constructor(public activeModal: NgbActiveModal) { }
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
      <app-employee-update #editform (nameEvent)="refreshdata($event)" [isReset]="resetForm"></app-employee-update>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-outline-dark" (click)="activeModal.close('Close click')">Close</button>
    </div>
  `
})

export class NgbdModalContentUpdate {
  @Input() name;

  constructor(public activeModal: NgbActiveModal) { }
}



@Component({
  selector: 'ngbd-modal-component',
  templateUrl: './modal-component.html'
})

export class NgbdModalComponent {
  @Input() id;  

  constructor(private modalService: NgbModal) {    

  }

  open() {

    switch (this.id) {
      case 0:
        this.modalService.open(NgbdModalContentAdd);
        //modalRef.componentInstance.name = 'Add';
        break;
      default:
        this.modalService.open(NgbdModalContentUpdate).componentInstance.name = this.id;
        //modalRef.componentInstance.name = 'Update  ';const modalRef = 
        break;
    }
  }
}
