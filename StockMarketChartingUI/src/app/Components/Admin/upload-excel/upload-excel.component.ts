import { Component, OnInit } from '@angular/core';
import {UploadExcelService} from 'src/app/Services/upload-excel.service'
@Component({
  selector: 'app-upload-excel',
  templateUrl: './upload-excel.component.html',
  styleUrls: ['./upload-excel.component.css']
})
export class UploadExcelComponent implements OnInit {
  fileToUpload: File = null;
  display:boolean=false;
  uploadSummary:[number,number,number];
  companiesNO:number;
  constructor(private service:UploadExcelService) { }
  
  ngOnInit(): void {
  }
  //the property below is to add multiple files together, will have to use for
 /*  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);} */

    onSelectedFile(e){this.fileToUpload = e.target.files[0];console.log(this.fileToUpload);}

UploadStockPriceExcel()
{
  console.log(this.fileToUpload);
  if(this.fileToUpload==null){alert( "File not selected, select again");}
  else{
    var formData = new FormData();
    formData.append("file1",this.fileToUpload);
    
    formData.forEach((value,key) => {
      console.log(key+" "+value)
    });

    this.service.postFile(formData).subscribe(res=>{
      console.log(res);
     // this.uploadSummary=res;
     // this.companiesNO=res[0]
      alert("File uploaded");
      window.location.reload();
    })
  }
}





}

