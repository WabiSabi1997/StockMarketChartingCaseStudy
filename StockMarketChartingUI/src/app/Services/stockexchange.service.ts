import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StockExchange } from 'src/app/Models/stock-exchange';

@Injectable({
  providedIn: 'root'
})
export class StockexchangeService {
  url:string = "https://localhost:44326/stockexchangeservice";

  constructor(private http:HttpClient) {
    // this.se = new StockExchange();
  }

  public viewSe():Observable<any>{
    console.log("Inside stockexchange service view se");
    return this.http.get<any>(this.url);
  }

  public addSe(stock:StockExchange){
    return this.http.post(this.url,stock);
  }

  public viewAllComp(Sid):Observable<any>{
    return this.http.get<any>(this.url+'/'+"getcompanies/"+Sid);
  }
  
}
