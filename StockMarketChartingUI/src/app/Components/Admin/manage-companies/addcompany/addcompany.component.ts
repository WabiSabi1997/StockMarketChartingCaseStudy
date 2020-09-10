import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/Models/company';
import { CompanyService } from 'src/app/Services/company.service';
import { StockExchange } from 'src/app/Models/stock-exchange';
import { StockexchangeService } from 'src/app/Services/stockexchange.service';

@Component({
  selector: 'app-addcompany',
  templateUrl: './addcompany.component.html',
  styleUrls: ['./addcompany.component.css']
})

export class AddcompanyComponent implements OnInit {
  item:Company;
  se_list:StockExchange[];
  constructor(private service: CompanyService, private seservice: StockexchangeService) { 
    this.item = new Company();
    
    this.seservice.viewSe().subscribe(res2=>
      {this.se_list=res2
        console.log(res2)
      });
  }

  ngOnInit(): void {
  }
  public Add(){
    this.item.stockExchangeIds = [1];
    console.log(this.item,"Inside Component Add function");
    this.service.AddComp(this.item).subscribe(res=>{
      console.log(res)
    },(err)=>{console.log(err)});
  }
}

