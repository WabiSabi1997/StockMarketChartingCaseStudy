import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { Company } from '../Models/company';
import { Observable } from 'rxjs';
import { StockPrice } from '../Models/stock-price';
@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  url:string = "https://localhost:44326/companyservice";
  constructor(private http:HttpClient) { }

  public AddComp(item:Company):Observable<any>
  {
    console.log("Inside CompanyService AddComp method");
    console.log(item);
    //console.log(this.http.get(this.url));
    var res = this.http.post(this.url,item);
    return res;
  }

  public ViewComp():Observable<Company[]>
  {
    console.log("Inside CompanyService ViewComp method, This is Rishabh");
    return this.http.get<Company[]>(this.url)
  }

  public UpdateComp(compId:number,item:Company):Observable<any>{
    item.companyId = compId;
    item.stockExchangeIds = [1];
    console.log(item);
    return this.http.put<any>(this.url+'/update/'+compId,item);
  }

  public DeleteComp(id:number):Observable<any>{
    return this.http.delete<any>(this.url+'/delete/'+id);
  }

  public getStockPrices(id:number,from:Date,to:Date):Observable<any>
  {
    console.log("Inside CompanyService getStockPrices method");
    var res=this.http.get<any>(this.url+"/getstockprice/"+id+"/"+from+"/"+to);
    return res;
  }
}
