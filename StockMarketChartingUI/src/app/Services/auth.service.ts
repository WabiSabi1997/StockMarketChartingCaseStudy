import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Token } from '../token';
import { isNgTemplate } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
url:string='https://localhost:44326/authservice/';

item:Token;

  constructor(private service:HttpClient) { 
    this.item=new Token();
  }

  public Validate(uname:string,pwd:string): Observable<Token>
  {
    console.log("Inside validate method");
   return this.service.get<Token>(this.url+uname+'/'+pwd);
/*     this.item = this.service.get<Token>(this.url+uname+'/'+pwd);
    return this.item; */
/*    this.item.token="abcd";
   this.item.utype=1;
   return this.item */
  }
}
