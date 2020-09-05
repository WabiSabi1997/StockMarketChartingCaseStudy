import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './Components/Account/sign-in/sign-in.component';
import { SignUpComponent } from './Components/Account/sign-up/sign-up.component';
import { AdminLandingPageComponent } from './Components/Admin/admin-landing-page/admin-landing-page.component';
import { AddCompanyComponent } from './Components/Admin/add-company/add-company.component';
import { UserLandingPageComponent } from './Components/User/user-landing-page/user-landing-page.component';
import { DisplayIPOComponent } from './Components/User/display-ipo/display-ipo.component';
import { LogInComponent } from './Components/Account/log-in/log-in.component';
import { UploadExcelComponent } from './Components/Admin/upload-excel/upload-excel.component';
import { ManageCompaniesComponent } from './Components/Admin/manage-companies/manage-companies.component';
import { ManageStockExchangesComponent } from './Components/Admin/manage-stock-exchanges/manage-stock-exchanges.component';
import { UpdateIPODetailsComponent } from './Components/Admin/update-ipodetails/update-ipodetails.component';
import { LandingPageComponent } from './Components/Account/landing-page/landing-page.component';
import { CompareCompaniesComponent } from './Components/User/compare-companies/compare-companies.component';
import { CompareSectorsComponent } from './Components/User/compare-sectors/compare-sectors.component';

const routes: Routes = [
{path:'', redirectTo:'account', pathMatch:'full'},
/*  ,
 {path:'signin',component:SignInComponent},
 
 {path:'signup',component:SignUpComponent},
 
 */
{path:'account', component:LandingPageComponent, children: [
  {path:'signin', component:SignInComponent},
  {path:'signup', component:SignUpComponent}
]}, 
/*
  {path:'login', component:LogInComponent},
  {path:'signin', component:SignInComponent},
  {path:'signup', component:SignUpComponent},
*/
  {path:'admin',component:AdminLandingPageComponent, children: [
    {path:'updateIPO', component:UpdateIPODetailsComponent},
    {path:'uploadExcel',component:UploadExcelComponent},
    {path:'manageCompany',component:ManageCompaniesComponent},
    {path:'manageExchange',component:ManageStockExchangesComponent},
    
  ]},
  {path:'user',component:UserLandingPageComponent, children: [
    {path:'displayIPO', component:DisplayIPOComponent},
    {path:'compareCompanies',component:CompareCompaniesComponent},
    {path:'compareSectors',component:CompareSectorsComponent}
  ]}
  //{path:'',redirectTo:'signin',pathMatch:'full'}  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
