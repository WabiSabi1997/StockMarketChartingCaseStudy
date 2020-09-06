import { Component, OnInit } from '@angular/core';
import {UploadExcelService} from 'src/app/Services/upload-excel.service'
@Component({
  selector: 'app-upload-excel',
  templateUrl: './upload-excel.component.html',
  styleUrls: ['./upload-excel.component.css']
})
export class UploadExcelComponent implements OnInit {
  fileToUpload: File = null;
  constructor(private service:UploadExcelService) { }

  ngOnInit(): void {
  }
  handleFileInput(files: FileList) {
    this.fileToUpload = files.item(0);
}
/* uploadFileToActivity() {
  this.service.postFile(this.fileToUpload).subscribe(data => {
    // do something, if upload success
    }, error => {
      console.log(error);
    });
}*/

}
