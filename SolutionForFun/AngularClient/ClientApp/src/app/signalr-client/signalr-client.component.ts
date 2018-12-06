import { Component, OnInit } from '@angular/core';
import { SignalRService } from '../services/signal-r.service';
import { ChartModel } from '../_interfaces/chartmodel';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'signalr-client',
  templateUrl: './signalr-client.component.html',
  styleUrls: ['./signalr-client.component.css']
})
  
export class SignalRComponent implements OnInit {
  public chartOptions: any = {
    scaleShowVerticalLines: true,
    responsive: true,
    scales: {
      yAxes: [{
        ticks: {
          beginAtZero: true
        }
      }]
    }
  };
  public chartLabels: string[] = ['Real time data for the chart'];
  public chartType: string = 'bar';
  public chartLegend: boolean = true;
  public colors: any[] = [{ backgroundColor: '#5491DA' }, { backgroundColor: '#E74C3C' }, { backgroundColor: '#82E0AA' }, { backgroundColor: '#E5E7E9' }]

  constructor(public signalRService: SignalRService, private http: HttpClient) { }

  ngOnInit() {
    this.signalRService.startConnection();
    this.signalRService.addListener();
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get('http://localhost:5000/api/chart')
      .subscribe(res => {
        console.log(res);
      })
  }
}
