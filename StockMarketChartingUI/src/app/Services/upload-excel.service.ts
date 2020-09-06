import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UploadExcelService {

  constructor(private service:HttpClient) { }

  url:string='https://localhost:44326/uploadservice';
    postFile(fileInput: FormData)
    {
      return this.service.post(this.url+"/upload",fileInput);
    }
  }

