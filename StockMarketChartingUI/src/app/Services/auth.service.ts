import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Token } from '../token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
url:string='http://localhost:44326/authservice/'
  constructor(private service:HttpClient) { }
  public Validate(uname:string,pwd:string):Observable<Token>
  {
    return this.service.get<Token>(this.url+uname+'/'+pwd);
  }
}
