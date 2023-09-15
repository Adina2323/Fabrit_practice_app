import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';  // <-- NgModel lives here
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeroesComponent } from './heroes/heroes.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeroSearchComponent } from './hero-search/hero-search.component';
import { HeaderComponent } from './header/header.component';
import { HeroEditComponent } from './hero-edit/hero-edit.component';
import { HeroCreateComponent } from './hero-create/hero-create.component';
import { UploadComponent } from './upload/upload.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './auth/auth.guard';
import { ManageAccountComponent } from './manage.account/manage.account.component';
import { JwtAtuthenticationInterceptor } from './interceptors/jwt-authetication-interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { HomeComponent } from './home/home.component';
import { SendEmailComponent } from './send-email/send-email.component';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

export function emailGetter() {
  return localStorage.getItem("email");
}

@NgModule({
  declarations: [
    AppComponent,
    HeroesComponent,
    HeroDetailComponent,
    MessagesComponent,
    DashboardComponent,
    HeroSearchComponent,
    HeaderComponent,
    HeroEditComponent,
    HeroCreateComponent,
    UploadComponent,
    LoginComponent,
    RegisterComponent,
    ManageAccountComponent,
    HomeComponent,
    SendEmailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44380"],
        disallowedRoutes: []
      }
    }),
    BrowserAnimationsModule,
    MatSelectModule,
    MatOptionModule,
    MatCheckboxModule
  ],
  providers: [AuthGuard,
    { provide: HTTP_INTERCEPTORS, useClass: JwtAtuthenticationInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
