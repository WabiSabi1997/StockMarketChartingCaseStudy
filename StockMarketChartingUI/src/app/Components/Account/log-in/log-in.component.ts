import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
uname:string;
pass:string;
  constructor(private service:AuthService) { }

  ngOnInit(): void {
  }
   
  public LogIn()
  {
    console.log(this.uname+" "+this.pass);
    this.service.Validate(this.uname,this.pass).subscribe(res=>{
      console.log(res);
    },(err)=>{console.log(err);})
  }

}
