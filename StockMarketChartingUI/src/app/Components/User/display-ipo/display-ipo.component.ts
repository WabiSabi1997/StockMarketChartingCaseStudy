import { Component, OnInit } from '@angular/core';
import {IPOService} from 'src/app/Services/ipo.service'
import { IPODetail } from 'src/app/Models/ipodetail';
@Component({
  selector: 'app-display-ipo',
  templateUrl: './display-ipo.component.html',
  styleUrls: ['./display-ipo.component.css']
})
export class DisplayIPOComponent implements OnInit {
list:IPODetail[]
  constructor(private service: IPOService) {
    
   // this.item=new IPODetail[]; not sure how to initialise
   }

  ngOnInit(): void {
  }

  public displayIPOs()
  { console.log("In display IPOs")
    this.service.viewIPO().subscribe(res => {
      console.log(res)
      this.list=res;
      console.log(res);
    },(err)=>{console.log(err)});
  }

}
