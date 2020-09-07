import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StockexchangeService {
  url:string = "https://localhost:44326/stockexchangeservice";
  constructor(private http:HttpClient) { }

  public viewAll(){
    
  }
}
