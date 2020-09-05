import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { Company } from '../Models/company';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  url:"http://localhost:44326/companyservice";
  constructor(private http:HttpClient) { }

  public AddComp(item:Company){
    return this.http.post(this.url,item);
  }
}
