import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HeroesComponent } from './heroes/heroes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeroDetailComponent } from './hero-detail/hero-detail.component';
import { HeroEditComponent } from './hero-edit/hero-edit.component';
import { HeroCreateComponent } from './hero-create/hero-create.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth/auth.guard';
import { ManageAccountComponent } from './manage.account/manage.account.component';
import { HomeComponent } from './home/home.component';
import { SendEmailComponent } from './send-email/send-email.component';

const routes: Routes = [
  {path:'home', component:HomeComponent},
  { path: 'heroes', component: HeroesComponent },
  { path: 'dashboard', component: DashboardComponent },
  //{ path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'detail/:id', component: HeroDetailComponent, canActivate:[AuthGuard] },
  { path: 'create', component: HeroCreateComponent ,canActivate:[AuthGuard]},
  { path: 'edit/:id', component: HeroEditComponent ,canActivate:[AuthGuard]},
  { path: 'register', component: RegisterComponent},
  { path: 'login', component:LoginComponent},
  { path: 'manage-account',component:ManageAccountComponent, canActivate:[AuthGuard]},
  { path: 'sendemail', component: SendEmailComponent, canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
