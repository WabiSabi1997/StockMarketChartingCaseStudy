import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions } from 'chart.js';
import { Color, Label } from 'ng2-charts';

@Component({
  selector: 'app-linechart',
  templateUrl: './linechart.component.html',
  styleUrls: ['./linechart.component.css']
})

export class LineChartComponent {
public xlist:string[]=[];
public ylist:number[]=[];

 constructor()
 {
  if(JSON.parse(localStorage.getItem('compCount'))==2)
  { console.log("MADE 2 COMPANIES IF");
  this.lineChartData.push({ data: JSON.parse(localStorage.getItem('y_axis2')), label: 'Company 2' });
 }
}

   

    lineChartData: ChartDataSets[] = [
      { data:JSON.parse(localStorage.getItem('y_axis')), label: 'Company 1' } // JSON.parse(localStorage.getItem('y_axis')), label: 'Company 1' },
    ];
  
    lineChartLabels: Label[] =JSON.parse(localStorage.getItem('x_axis')); //JSON.parse(localStorage.getItem('x_axis'));
  
    lineChartOptions = {
      responsive: true,
    };
  
    lineChartColors: Color[] = [
      {
        borderColor: 'black',
        backgroundColor: 'rgba(255,255,0,0.28)',
      },
    ];
  
    lineChartLegend = true;
    lineChartPlugins = [];
    lineChartType = 'line';
  
}