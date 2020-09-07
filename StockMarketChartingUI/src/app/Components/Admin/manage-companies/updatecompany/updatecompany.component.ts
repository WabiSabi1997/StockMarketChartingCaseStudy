import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/Models/company';
import { CompanyService } from 'src/app/Services/company.service';

@Component({
  selector: 'app-updatecompany',
  templateUrl: './updatecompany.component.html',
  styleUrls: ['./updatecompany.component.css']
})
export class UpdatecompanyComponent implements OnInit {
  compId:number;
  item:Company;

  constructor(private service:CompanyService) { 
    this.item = new Company();
  }

  ngOnInit(): void {
  }

  public Update():void{
    this.service.UpdateComp(this.compId,this.item).subscribe(res=>{
      console.log(res);
    },(err)=>{
      console.log(err);
    }) 
  }

}
