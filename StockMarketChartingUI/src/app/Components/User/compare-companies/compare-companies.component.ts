import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Company } from 'src/app/Models/company';
import { CompanyService } from 'src/app/Services/company.service'
import {StockExchange}  from 'src/app/Models/stock-exchange'
import { StockexchangeService } from 'src/app/Services/stockexchange.service'
import { formatDate } from '@angular/common';
@Component({
  selector: 'app-compare-companies',
  templateUrl: './compare-companies.component.html',
  styleUrls: ['./compare-companies.component.css']
})
export class CompareCompaniesComponent implements OnInit {
  x_list:string[]=[];
  y_list:Number[]=[];
  x_list2:string[]=[];
  y_list2:Number[]=[];
  comp_list:Company[];
  se_list:StockExchange[];
  id:number;
  id2:number;
  from:Date;
  to:Date;
  display:boolean=false;
  display2:boolean=false;
  addingAnother:boolean=false;
  constructor(private cservice: CompanyService , private seservice: StockexchangeService,private http: HttpClient) 
  { 
     //this is to remove the storage from earlier
     localStorage.removeItem('x_axis');
     localStorage.removeItem('y_axis');
     localStorage.removeItem('x_axis2');
     localStorage.removeItem('y_axis2');
    this.cservice.ViewComp().subscribe(res=> 
     {this.comp_list=res
      console.log(res)
     });

     this.seservice.viewSe().subscribe(res2=>
      {this.se_list=res2
        console.log(res2)
      });


   }

  ngOnInit(): void {
  }
  public StockPrices()
  {
    console.log("Inside stock price call with",this.id,this.to,this.from);
    this.cservice.getStockPrices(this.id,this.from,this.to).subscribe(res=>
      { console.log(res)
        let i = 0;
        for(let item of res){
          this.x_list[i] = formatDate(item.item2,'dd-MM-yyyy','en-US');
          this.y_list[i] = item.item1;
          i++;
        }
        console.log(this.x_list);
        console.log(this.y_list);
        
        localStorage.setItem('x_axis',JSON.stringify(this.x_list));
        localStorage.setItem('y_axis',JSON.stringify(this.y_list));

      },(err)=> {console.log(err)}
      
      );
      
      if(!this.addingAnother)
      this.display=true;
  }

  public addAnother()
  { 
    this.addingAnother=true;
    this.StockPrices();
    this.display2=true;
    /* window.location.reload();
    alert("Add details of the other company"); */
  }

  public StockPrices2()
  {
    console.log("Inside stock price call with",this.id2,this.to,this.from);
    //from to date and periodicity for second company would remain the same
    this.cservice.getStockPrices(this.id,this.from,this.to).subscribe(res=>
      { console.log(res)
        let i = 0;
        for(let item of res){
          this.x_list2[i] = formatDate(item.item2,'dd-MM-yyyy','en-US');
          this.y_list2[i] = item.item1;
          i++;
        }
        console.log("2nd x list ",this.x_list2);
        console.log("2nd y list",this.y_list2);
        
        localStorage.setItem('x_axis2',JSON.stringify(this.x_list2));
        
        localStorage.setItem('y_axis2',JSON.stringify(this.y_list2));

      },(err)=> {console.log(err)}
      
      );
 
      this.display=true;
  }
 

}
