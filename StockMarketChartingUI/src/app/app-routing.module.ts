import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import { SignInComponent } from './Components/Account/sign-in/sign-in.component';
import { SignUpComponent } from './Components/Account/sign-up/sign-up.component';
//import {AccountLandingPageComponent} from './Components/Account/account-landing-page/account-landing-page.component'
import { AdminLandingPageComponent } from './Components/Admin/admin-landing-page/admin-landing-page.component';
import { AddCompanyComponent } from './Components/Admin/add-company/add-company.component';
import { UserLandingPageComponent } from './Components/User/user-landing-page/user-landing-page.component';
import { DisplayIPOComponent } from './Components/User/display-ipo/display-ipo.component';
import { LogInComponent } from './Components/Account/log-in/log-in.component';
import { LandingComponent } from './Components/Account/landing/landing.component';

const routes: Routes = [
  {path:'', redirectTo:'account/login', pathMatch:'full'},

  {path:'account', component:LandingComponent, children: [
    {path:'login', component:LogInComponent},
    {path:'signup', component:SignUpComponent}
  ]},  
/*   {path:'', redirectTo:'login', pathMatch:'full'},
  {path:'login', component:LogInComponent},
  {path:'signup', component:SignUpComponent}, */

//{path:'', redirectTo:'account', pathMatch:'full'},
/*  {path:'login',component:LogInComponent},
 {path:'',redirectTo:'login',pathMatch:'partial'},
 {path:'signup',component:SignUpComponent}, */

/* {path:'account', component:AccountLandingPageComponent, children: [
  {path:'login', component:SignInComponent},
  {path:'signup', component:SignUpComponent}]
  }, */

  {path:'admin',component:AdminLandingPageComponent, children: [
    {path:'add-company', component:AddCompanyComponent}
  ]},
  {path:'user',component:UserLandingPageComponent, children: [
    {path:'display-ipo', component:DisplayIPOComponent}
  ] }  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
