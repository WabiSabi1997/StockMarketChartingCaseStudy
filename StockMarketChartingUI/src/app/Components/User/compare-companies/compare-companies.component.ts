import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Company } from 'src/app/Models/company';
import { CompanyService } from 'src/app/Services/company.service'
import {StockExchange}  from 'src/app/Models/stock-exchange'
import { StockexchangeService } from 'src/app/Services/stockexchange.service'
@Component({
  selector: 'app-compare-companies',
  templateUrl: './compare-companies.component.html',
  styleUrls: ['./compare-companies.component.css']
})
export class CompareCompaniesComponent implements OnInit {
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
      },(err)=> console.log(err));
 

  }
 

}
