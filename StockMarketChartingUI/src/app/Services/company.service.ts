import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { Company } from '../Models/company';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  url:"https://localhost:44326/companyservice";
  constructor(private http:HttpClient) { }

  public AddComp(item:Company):void
  {
    console.log("Inside CompanyService AddComp method");
    console.log(item);
    //console.log(this.http.get(this.url));
    var res = this.http.post(this.url,item);
    console.log(res);
    return ;
  }

  public ViewComp():Observable<Company[]>
  {
    console.log("Inside CompanyService ViewComp method, This is Rishabh");
    return this.http.get<Company[]>(this.url);
  }

  public UpdateComp(){

  }

  public DeleteComp(){

  }
}
