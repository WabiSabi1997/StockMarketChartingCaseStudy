import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/Services/company.service';

@Component({
  selector: 'app-deletecompany',
  templateUrl: './deletecompany.component.html',
  styleUrls: ['./deletecompany.component.css']
})
export class DeletecompanyComponent implements OnInit {
  compId:number;
  constructor(private service:CompanyService) { }

  ngOnInit(): void {
  }

  public Delete(){
    this.service.DeleteComp(this.compId);
  }


}
