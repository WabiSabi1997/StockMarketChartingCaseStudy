import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { User } from '../Models/user';

@Injectable({
  providedIn: 'root'
})
export class SignupService {

  path:string="http://localhost:8000/authservice"
  constructor(private http:HttpClient){}

  public AddUser(item:User)
  {
    return this.http.post(this.path,item)
  }

}
