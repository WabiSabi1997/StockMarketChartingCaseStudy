import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/Models/company';
import { CompanyService } from 'src/app/Services/company.service'

@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html',
  styleUrls: ['./add-company.component.css']
})
export class AddCompanyComponent implements OnInit {
  item:Company;
  constructor(private service: CompanyService) { 
    this.item = new Company();
  }

  ngOnInit(): void {
  }
  public Add(){
    this.item.stockExchangeIds = [1];
    console.log(this.item,"Inside Component Add function");
    this.service.AddComp(this.item);//.subscribe(res=>{
    //  console.log(res)
    //},(err)=>{console.log(err)});
  }
}
