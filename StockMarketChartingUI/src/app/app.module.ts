import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {SignUpComponent} from './Components/Account/sign-up/sign-up.component';
import { SignInComponent } from './Components/Account/sign-in/sign-in.component';

import { UploadExcelComponent } from './Components/Admin/upload-excel/upload-excel.component';
import { ManageCompaniesComponent } from './Components/Admin/manage-companies/manage-companies.component';
import { UploadSummaryComponent } from './Components/Admin/upload-summary/upload-summary.component';
import { UpdateIPODetailsComponent } from './Components/Admin/update-ipodetails/update-ipodetails.component';
import { AddCompanyComponent } from './Components/Admin/add-company/add-company.component';
import { ManageStockExchangesComponent } from './Components/Admin/manage-stock-exchanges/manage-stock-exchanges.component';
import {AdminLandingPageComponent} from './Components/Admin/admin-landing-page/admin-landing-page.component';

import { UserLandingPageComponent } from './Components/User/user-landing-page/user-landing-page.component';
import { CompareCompaniesComponent } from './Components/User/compare-companies/compare-companies.component';
import { CompareSectorsComponent } from './Components/User/compare-sectors/compare-sectors.component';
import { DisplayIPOComponent } from './Components/User/display-ipo/display-ipo.component';
import { AccountLandingPageComponent } from './Components/Account/account-landing-page/account-landing-page.component';

@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    SignInComponent,
    AdminLandingPageComponent,
    UserLandingPageComponent,
    UploadExcelComponent,
    ManageCompaniesComponent,
    UploadSummaryComponent,
    ManageStockExchangesComponent,
    UpdateIPODetailsComponent,
    AddCompanyComponent,
    CompareCompaniesComponent,
    CompareSectorsComponent,
    DisplayIPOComponent,
    AccountLandingPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
