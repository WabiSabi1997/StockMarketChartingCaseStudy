import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './Components/Account/sign-in/sign-in.component';
import { SignUpComponent } from './Components/Account/sign-up/sign-up.component';
import {AccountLandingPageComponent} from './Components/Account/account-landing-page/account-landing-page.component'

const routes: Routes = [
  {path:'', redirectTo:'account/login', pathMatch:'full'},
  {path:'account', component:AccountLandingPageComponent, children: [
  {path:'login', component:SignInComponent},
  {path:'signup', component:SignUpComponent}]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
