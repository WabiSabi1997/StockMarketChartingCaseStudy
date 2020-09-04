import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {
uname:string;
pass:string;
  constructor() { }

  ngOnInit(): void {
  }
   
  public LogIn()
  {
    console.log(this.uname+" "+this.pass);
  }

}
