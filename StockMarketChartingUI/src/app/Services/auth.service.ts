import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Token } from '../token';
import { isNgTemplate } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
url:string='http://localhost:44326/authservice/'
item:Token;

  constructor(private service:HttpClient) { this.item=new Token();}


  public Validate(uname:string,pwd:string): Token//Observable<Token>
  {
   //return this.service.get<Token>(this.url+uname+'/'+pwd);
   this.item.token="abcd";
   this.item.utype=1;
   return this.item

   


  }
}
