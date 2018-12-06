
import { Component, OnDestroy, OnInit } from '@angular/core';

import { HttpClient, HttpResponse } from '@angular/common/http';

import { WeatherForecastModel } from '../_interfaces/weatherforecastmodel';
import { Subject } from 'rxjs';

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
      pageLength: 2
    };
    this.http.get('http://localhost:5000/api/SampleData/WeatherForecasts')
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
}

