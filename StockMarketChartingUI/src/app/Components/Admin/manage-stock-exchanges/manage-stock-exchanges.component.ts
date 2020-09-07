import { Component, OnInit } from '@angular/core';
import { StockexchangeService } from 'src/app/Services/stockexchange.service';

@Component({
  selector: 'app-manage-stock-exchanges',
  templateUrl: './manage-stock-exchanges.component.html',
  styleUrls: ['./manage-stock-exchanges.component.css']
})
export class ManageStockExchangesComponent implements OnInit {

  constructor(private service:StockexchangeService) { }

  ngOnInit(): void {
  }

  public viewStockExchange():void{
      //get the list of stockExchanges and display

  }

  public addNewStockExchange():void{
    //pass a stockexchange model to the service
  }

}
