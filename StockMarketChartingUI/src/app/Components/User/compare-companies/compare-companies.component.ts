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
  comp_list:Company[];
  se_list:StockExchange[];
  id:number;
  from:Date;
  to:Date;
  constructor(private cservice: CompanyService , private seservice: StockexchangeService,private http: HttpClient) 
  {
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
        
        localStorage.setItem('x_list',JSON.stringify(this.x_list));
        localStorage.setItem('y_list',JSON.stringify(this.y_list));

      },(err)=> {console.log(err)}
      
      );
 

  }
 

}
