import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import { IPODetail } from '../Models/ipodetail';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class IPOService {
  url:string="https://localhost:44326/ipodetails";
  constructor(private http:HttpClient){}
  
    public viewIPO():Observable<IPODetail[]>
    {
      console.log("Inside  method view IPO");
      var res=this.http.get<IPODetail[]>(this.url)
     // console.log(res)
      return res;
    }

    public viewIPObyId():void{}

    public updateIPO(id:number,item:IPODetail):void
    {
      
    }

  
}
