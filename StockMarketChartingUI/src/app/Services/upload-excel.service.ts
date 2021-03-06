import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UploadExcelService {

  constructor(private service:HttpClient) { }

  url:string='https://apigatewaystockmarket.azurewebsites.net/uploadservice';
    postFile(fileInput: FormData):Observable<any>
    {
      return this.service.post<any>(this.url+"/upload",fileInput);
    }
  }

