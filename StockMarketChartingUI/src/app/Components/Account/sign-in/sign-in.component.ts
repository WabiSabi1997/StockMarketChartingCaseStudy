import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  uname:string;
  pass:string;

  constructor(private service:AuthService,private router:Router)
  {
    localStorage.clear();
  }

  ngOnInit(): void {
  }

  public SignIn()
  {
  /*   this.service.Validate(this.uname,this.pass).subscribe(res=>{
      if(res.utype=="Admin")
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
    }); */
    
  }

}
