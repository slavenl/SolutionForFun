
import { Component, OnDestroy, OnInit, HostListener } from '@angular/core';

import { HttpClient, HttpResponse } from '@angular/common/http';

import { WeatherForecastModel } from '../_interfaces/weatherforecastmodel';
import { Subject } from 'rxjs';
import { map } from 'rxjs/operators';

export enum KEY_CODE {
  ESCAPE = 27,
  P = 80
}

@Component({
  selector: 'fetch-data-component',
  templateUrl: './fetch-data.component.html'
})

//export class FetchDataComponent {
//  public forecasts: WeatherForecastModel[];

//  constructor(http: HttpClient) {
//    http.get<WeatherForecastModel[]>('http://localhost:5000/api/SampleData/WeatherForecasts').subscribe(result => {
//      this.forecasts = result;
//    }, error => console.error(error));
//  }
//}


export class FetchDataComponent implements OnDestroy, OnInit {
  dtOptions: DataTables.Settings = {};
  forecasts: WeatherForecastModel[] = [];
  // We use this trigger because fetching the list of forecasts can be quite long,
  // thus we ensure the data is fetched before rendering
  dtTrigger: Subject<WeatherForecastModel> = new Subject();

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5
    };
    this.http.get<WeatherForecastModel[]>('http://localhost:5000/api/SampleData/WeatherForecasts')
      //.map(this.extractData)
      .subscribe(forecasts => {
        this.forecasts = forecasts;
        // Calling the DT trigger to manually render the table
        this.dtTrigger.next();
      });
  }

  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }
  //private extractData(res: HttpResponse<WeatherForecastModel>) {
  //  const body = res.json();
  //  return body.data || {};

  //}


  @HostListener('window:keyup', ['$event'])
  keyEvent(event: KeyboardEvent) {
    console.log(event);


    if ((<HTMLElement>event.target).tagName == "BODY") {
      if (event.keyCode === KEY_CODE.ESCAPE ||
        (event.keyCode === KEY_CODE.P && event.ctrlKey === true))
      {
        this.sendToCSharp(event.key);
      }
    }
  }

  sendToCSharp(mykey: string): void {
    (async () => {
      await window['CefSharp'].BindObjectAsync("keyboardBoundAsync");
      let result = await window['keyboardBoundAsync'].sendKeyEvent2CSharp(mykey)
      alert("Return from C#: " + result);

    })();
  }

  exportToCSharp(): void {
    (async () => {

      await window['CefSharp'].BindObjectAsync("dataBoundAsync");

      alert(await window['dataBoundAsync'].helloWithPrintDialog());

      let result = await window['dataBoundAsync'].multiply(7, 3);
      alert(result);

      let json = JSON.stringify(this.forecasts)
      result = await window['dataBoundAsync'].jsonReceiver(json);
      if (1)
        alert("Success");
      else
        alert("Fail");

    })();
  }
}

