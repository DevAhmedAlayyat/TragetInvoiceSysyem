import { AuthService } from './auth.service';
import { CanActivate, Router } from '@angular/router';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private authService:AuthService,
              private router:Router) { }

  canActivate(){
    let user = this.authService.user;
    if(user && user.userRole == "Admin"){
      return true;
    }

    this.router.navigate(['/access-denied']);
    return false;
  }
}
