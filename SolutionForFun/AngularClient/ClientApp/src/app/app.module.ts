import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { ChartsModule } from 'ng2-charts';

import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SignalRComponent } from './signalr-client/signalr-client.component';

import { DataTablesModule } from 'angular-datatables';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    SignalRComponent
  ],
  imports: [
    BrowserModule,//.withServerTransition({ appId: 'ng-cli-universal' }),   
    NgbModule,
    AngularFontAwesomeModule,
    ChartsModule,
    HttpClientModule,
    FormsModule,
    DataTablesModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'signalR', component: SignalRComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


