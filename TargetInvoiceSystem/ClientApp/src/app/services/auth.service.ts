import { Router } from '@angular/router';
import { UserDto } from './../dtos/user-dto';
import { JwtHelperService } from '@auth0/angular-jwt';
import { RegisterDto } from './../dtos/register-dto';
import { LoginDto } from './../dtos/login-dto';
import { AuthResponseDto } from './../dtos/auth-response-dto';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,
              private router: Router) {}

  authResponse: AuthResponseDto;
  loginUser: LoginDto;
  registerUser: RegisterDto;
  user: UserDto;
  private registerApiUrl: string = 'http://localhost:57974/Api/Auth/Register';
  private loginApiUrl: string = 'http://localhost:57974/Api/Auth/Login';


  register(){
    return this.http.post(this.registerApiUrl, this.registerUser);
  }

  login(){
    return this.http.post(this.loginApiUrl, this.loginUser);
  }

  logout(){
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  isLoggedIn(){
    let jwtHelper = new JwtHelperService();
    let token = localStorage.getItem('token');
    if(token){
      let decodedToken = jwtHelper.decodeToken(token);
      this.user = {
        userId: decodedToken["UserId"],
        userName: decodedToken["UserName"],
        userRole: decodedToken["UserRole"]
      }
      
      return !jwtHelper.isTokenExpired(token);
    }

    return false;
  }

  isAdmin(){
    if(this.isLoggedIn()){
      if(this.user.userRole == "Admin")
        return true;
    }

    return false;
  }

}
