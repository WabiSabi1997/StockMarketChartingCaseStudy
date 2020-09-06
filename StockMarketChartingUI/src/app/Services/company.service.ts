import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { Company } from '../Models/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  url:"https://localhost:44326/companyservice";
  constructor(private http:HttpClient) { }

  public AddComp(item:Company){
    console.log("Inside CompanyService AddComp method");
    console.log(item);
    var res = this.http.post(this.url,item);
    console.log(res);
    return res;
  }
}
