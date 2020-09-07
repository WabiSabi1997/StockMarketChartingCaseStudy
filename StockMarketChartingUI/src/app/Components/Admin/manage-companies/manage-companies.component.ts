import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/Services/company.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-manage-companies',
  templateUrl: './manage-companies.component.html',
  styleUrls: ['./manage-companies.component.css']
})
export class ManageCompaniesComponent implements OnInit {
  dispComp:boolean;
  constructor(private service:CompanyService, private router:Router) { 
    this.dispComp = false;
  }

  ngOnInit(): void {
  }

  public ViewComp(){
    return this.service.ViewComp().subscribe(res=>{
      console.log(res);
    },(err)=>{
      console.log(err);
    });
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
