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
  /*  constructor()
{
      this.xlist=JSON.parse(localStorage.getItem('x_axis'));
      console.log(this.xlist);
      this.ylist=JSON.parse(localStorage.getItem('y_axis'));
      console.log(this.ylist);

}
    buttonclick()
    {
     // console.log("LOCAL STORAGE",localStorage);
      //console.log("X",localStorage.getItem('x_axis'))
      //console.log("X",localStorage.getItem('y_axis'))
      this.xlist=JSON.parse(localStorage.getItem('x_axis'));
      this.ylist=JSON.parse(localStorage.getItem('y_axis'));
      console.log(this.xlist);
      console.log(this.ylist);
    
      console.log("Y axis labels",this.lineChartData);
      console.log("X axis data",this.lineChartLabels);
    }
    */

   

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