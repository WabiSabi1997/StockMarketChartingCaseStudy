import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-barchart',
  templateUrl: './barchart.component.html',
  styleUrls: ['./barchart.component.css']
})
export class BarchartComponent implements OnInit {

  constructor() { 
    if(JSON.parse(localStorage.getItem('compCount'))==2)
    { console.log("MADE 2 COMPANIES IF");
    this.barChartData.push({ data: JSON.parse(localStorage.getItem('y_axis2')), label: 'Company 2' });
  }
}

  ngOnInit(): void {
  }

  barChartOptions: ChartOptions = {
    responsive: true,
  };
  barChartLabels: Label[] =JSON.parse(localStorage.getItem('x_axis'));
  barChartType: ChartType = 'bar';
  barChartLegend = true;
  barChartPlugins = [];

  barChartData: ChartDataSets[] = [
    { data: JSON.parse(localStorage.getItem('y_axis')), label: 'Company 1' }
   // { data: JSON.parse(localStorage.getItem('y_axis2')), label: 'Company 2' }
  ];

}
