import { StockComponent } from './admin/stock/stock.component';
import { AccessDeniedComponent } from './access-denied/access-denied.component';
import { AdminComponent } from './admin/admin.component';
import { AdminGuard } from './services/admin-guard.service';
import { AuthGuard } from './services/auth-guard.service';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { NgModule, AfterViewInit, ElementRef } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path:'', redirectTo:'/home', pathMatch:'full'},
  {path:'home', component: HomeComponent},
  {path:'login', component: LoginComponent},
  {path:'register', component: RegisterComponent},  
  {path:'admin', component: AdminComponent},//, canActivate: [AuthGuard, AdminGuard]},
  {path:'access-denied', component: AccessDeniedComponent},  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule  {}
