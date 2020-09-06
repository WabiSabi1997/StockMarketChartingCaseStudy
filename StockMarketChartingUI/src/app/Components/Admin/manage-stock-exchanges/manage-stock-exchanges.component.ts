import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manage-stock-exchanges',
  templateUrl: './manage-stock-exchanges.component.html',
  styleUrls: ['./manage-stock-exchanges.component.css']
})
export class ManageStockExchangesComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public viewStockExchange():void{
      //get the list of stockExchanges and display
  }

  public addNewStockExchange():void{
    //pass a stockexchange model to the service
  }

}
