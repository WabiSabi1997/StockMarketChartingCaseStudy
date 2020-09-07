import { Component, OnInit } from '@angular/core';
import {IPOService} from 'src/app/Services/ipo.service'
import { IPODetail } from 'src/app/Models/ipodetail';
import { Router } from '@angular/router';
@Component({
  selector: 'app-display-ipo',
  templateUrl: './display-ipo.component.html',
  styleUrls: ['./display-ipo.component.css']
})
export class DisplayIPOComponent implements OnInit {
ipo_list:IPODetail[];
display:boolean=false;
 /*    IPODetailID:number;
    PricePerShare:number;
    TotalNumOfShares:number;
    OpenDate:string;
    OpenTime:string;
    Remarks:string;
    CompanyId:number;
    StockExchangeId:number; */

  constructor(private service: IPOService, private router:Router) {
    console.log("In display IPOs")
    this.service.viewIPO().subscribe(res => {
      this.ipo_list=res
      this.display=true
     // console.log(res);
    },(err)=>{console.log(err)});
   }

  ngOnInit(): void {
  }


}
