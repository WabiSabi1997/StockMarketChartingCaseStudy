import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './Components/Account/sign-in/sign-in.component';
import { SignUpComponent } from './Components/Account/sign-up/sign-up.component';
import {AccountLandingPageComponent} from './Components/Account/account-landing-page/account-landing-page.component'
import { AdminLandingPageComponent } from './Components/Admin/admin-landing-page/admin-landing-page.component';
import { AddCompanyComponent } from './Components/Admin/add-company/add-company.component';
import { UserLandingPageComponent } from './Components/User/user-landing-page/user-landing-page.component';
import { DisplayIPOComponent } from './Components/User/display-ipo/display-ipo.component';
import { LogInComponent } from './Components/Account/log-in/log-in.component';

const routes: Routes = [
//{path:'', redirectTo:'account', pathMatch:'full'},
 {path:'',redirectTo:'signin',pathMatch:'full'},
 {path:'signin',component:SignInComponent},
 
 {path:'signup',component:SignUpComponent},
 

{path:'account', component:AccountLandingPageComponent, children: [
  {path:'login', component:SignInComponent},
  {path:'signup', component:SignUpComponent}]
  },

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
