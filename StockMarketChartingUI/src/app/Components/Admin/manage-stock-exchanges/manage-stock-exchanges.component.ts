import { Component, OnInit } from '@angular/core';
import { StockexchangeService } from 'src/app/Services/stockexchange.service';
import { StockExchange } from 'src/app/Models/stock-exchange';
import { Company } from 'src/app/Models/company';

@Component({
  selector: 'app-manage-stock-exchanges',
  templateUrl: './manage-stock-exchanges.component.html',
  styleUrls: ['./manage-stock-exchanges.component.css']
})
export class ManageStockExchangesComponent implements OnInit {
  stock:StockExchange;
  selist:StockExchange[];
  complist:Company[];
  Sid:number;

  displaySe:boolean;
  displayComp:boolean;
  addSe:boolean;
  getSid:boolean;

  constructor(private service:StockexchangeService) { 
    this.setVars();
    this.stock = new StockExchange;
  }

  ngOnInit(): void {
  }

  public setVars():void{
    this.displayComp = false;
    this.displaySe = false;
    this.addSe = false;
    this.getSid = false;
  }

  public viewStockExchange():void{
    this.setVars();
    //get the list of stockExchanges and display
    this.service.viewSe().subscribe(res=>{
      this.selist = res;
      if(this.selist!=null&&this.selist.length>0){
        this.displaySe = true;
      }
      console.log(this.selist);
    });
  }

  public addSeData(){
    this.setVars();
    this.addSe = true;
  }

  public viewComps(){
    this.setVars();
    this.getSid = true;
  }

  public addNewStockExchange():void{
    //pass a stockexchange model to the service
    this.setVars();
    this.service.addSe(this.stock);
  }

  public viewAllCompanies():void{
    this.setVars();
    this.service.viewAllComp(this.Sid).subscribe(res=>{
      this.complist = res;
      if(this.complist!=null&&this.complist.length>0){
        this.displayComp= true;
      }
      console.log(this.complist);
    });
  }

}
