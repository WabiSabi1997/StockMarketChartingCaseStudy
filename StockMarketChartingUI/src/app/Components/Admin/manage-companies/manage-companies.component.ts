import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/Services/company.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Company } from 'src/app/Models/company';

@Component({
  selector: 'app-manage-companies',
  templateUrl: './manage-companies.component.html',
  styleUrls: ['./manage-companies.component.css']
})
export class ManageCompaniesComponent implements OnInit {
  dispComp:boolean;
  list:Company[];
  constructor(private service:CompanyService, private router:Router) { 
    this.dispComp = false;
  }

  ngOnInit(): void {
  }

  public ViewComp(){
    
    return this.service.ViewComp().subscribe(res=>{
      console.log(res);
      this.list=res;
      this.dispComp=true;
    },(err)=>{
      console.log(err);
    });
  }

  public dispOff()
  {
    this.dispComp=false;
  }
/* 
  public AddComp(){
    this.router.navigateByUrl('addcompany');
  }

  public UpdateComp(){
    this.router.navigateByUrl('updatecompany');
  }

  public DeleteComp(){
    this.router.navigateByUrl('deletecompany');
  }
  
 */
}
