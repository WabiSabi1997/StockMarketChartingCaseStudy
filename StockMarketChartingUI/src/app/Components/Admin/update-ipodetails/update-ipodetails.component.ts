import { Component, OnInit } from '@angular/core';
import { IPODetail } from 'src/app/Models/ipodetail';
import { IPOService } from 'src/app/Services/ipo.service';


@Component({
  selector: 'app-update-ipodetails',
  templateUrl: './update-ipodetails.component.html',
  styleUrls: ['./update-ipodetails.component.css']
})
export class UpdateIPODetailsComponent implements OnInit {
  item:IPODetail;
  ipoId:number;

  constructor(private service:IPOService) {
    this.item = new IPODetail();
  }

  ngOnInit(): void {
  }

  public Update(){
    this.service.updateIPO(this.ipoId,this.item).subscribe(res=>{
      console.log(res);
    },(err)=>{
      console.log(err);
    });
  }
}
