import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
uname:string;
pass:string;
  constructor(private service:AuthService,private router:Router) {
    localStorage.clear();
   }

  ngOnInit(): void {
  }
   
  public LogIn()
  {
    console.log(this.uname+" "+this.pass);
    this.service.Validate(this.uname,this.pass).subscribe(res=>{
      console.log(res);

      if(res.utype==1)
      {
        localStorage.setItem('token',res.token)
        console.log(res)
        this.router.navigateByUrl('admin');
      }
      else if(res.token==""||res.token==null)
      {
        console.log('Invalid Id');
      }
      else
      {
      localStorage.setItem('token',res.token)
      console.log(res)
      this.router.navigateByUrl('user');
      } 

    },(err)=>{console.log(err);})
  }

}
