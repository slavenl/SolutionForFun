import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';

import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
//import { NgbModule, NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { ChartsModule } from 'ng2-charts';

import { RouterModule } from '@angular/router';

//import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { DataTablesModule } from 'angular-datatables';

import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SignalRComponent } from './signalr-client/signalr-client.component';

import { CRUDComponent } from './employee/employee-list.component';
//import { EmployeeAddComponent } from './employee-add/employee-add.component';
//import { EmployeeUpdateComponent } from './employee-update/employee-update.component';
import { NgbdModalContentModule } from './modal-component/modal-component.module';

import { EmployeeDataService } from './services/employeedata.service'




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    SignalRComponent,
    CRUDComponent//,
    //EmployeeAddComponent,
    //EmployeeUpdateComponent    
  ],
  imports: [
    BrowserModule,//.withServerTransition({ appId: 'ng-cli-universal' }),   
    NgbModule,
    NgbdModalContentModule,    
    AngularFontAwesomeModule,
    ChartsModule,
    HttpClientModule,
  //  AppRoutingModule,
    FormsModule,
    DataTablesModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'signalR', component: SignalRComponent },   
      { path: 'crud', component: CRUDComponent },
    ])
  ],
  providers: [
    EmployeeDataService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }


