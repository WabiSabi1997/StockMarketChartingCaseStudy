import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
// import { HttpClientModule } from '@angular/common/http';
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

import { AuthInterceptor } from './auth-interceptor';
import {AuthService} from './Services/auth.service';
import {SignupService} from './Services/signup.service'
import { FormsModule} from '@angular/forms';
import { LogInComponent } from './Components/Account/log-in/log-in.component';
import { LandingPageComponent } from './Components/Account/landing-page/landing-page.component'
import { CompanyService } from './Services/company.service';
//import { ViewcompanyComponent } from './Components/Admin/manage-companies/viewcompany/viewcompany.component';
import { UpdatecompanyComponent } from './Components/Admin/manage-companies/updatecompany/updatecompany.component';
import { DeletecompanyComponent } from './Components/Admin/manage-companies/deletecompany/deletecompany.component';
import { AddcompanyComponent } from './Components/Admin/manage-companies/addcompany/addcompany.component';
import { IPOService } from './Services/ipo.service';
import { PiechartComponent } from './Components/Charting/piechart/piechart.component';
import { LineChartComponent } from './Components/Charting/linechart/linechart.component';
import { BarchartComponent } from './Components/Charting/barchart/barchart.component';
import { ChartsModule } from 'ng2-charts';

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
    LogInComponent,
    LandingPageComponent,
    UpdatecompanyComponent,
    DeletecompanyComponent,
    AddcompanyComponent,
    BarchartComponent,
    PiechartComponent,
    LineChartComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ChartsModule 
  ],
  providers: [ SignupService, AuthService, CompanyService,IPOService,
     { 
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
     } 
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }


