import { Component, OnInit } from '@angular/core';
import {User} from './../../../Models/user';
import { SignupService } from 'src/app/Services/signup.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  item:User;
  constructor(private service:SignupService) {
    this.item=new User();
   }

  ngOnInit(): void {
  }

  public SignUp()
  {
     console.log(this.item);

    this.service.AddUser(this.item).subscribe(res =>
      {console.log(res)}, (err)=>{console.log(err)})
    
  }

}
