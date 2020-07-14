import { AuthResponseDto } from '../dtos/auth-response-dto';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../services/auth.service';
import { Component, OnInit, AfterViewInit, ElementRef } from '@angular/core';
import { faUser, faLock } from '@fortawesome/free-solid-svg-icons'
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, AfterViewInit {

  constructor(private elementRef: ElementRef,
              public authService: AuthService,
              private toastr:ToastrService,
              private router:Router) { }
  ngAfterViewInit(): void {
    this.elementRef.nativeElement.ownerDocument.body.style.backgroundColor = '#1a3d58';
  }

  ngOnInit(): void {
    this.authService.loginUser = {
      email: null,
      password: null
    };
    this.authService.authResponse = {
      message: null,
      isSuccess: null,
      errors: null,
      token: null,
      tokenExpireDate: null
    };
  }

  faUser = faUser;
  faLock = faLock;

  onSubmit(){
    this.authService.login().subscribe(result =>{
        this.authService.authResponse = result as AuthResponseDto;
        if(this.authService.authResponse.isSuccess){
          localStorage.setItem('token', this.authService.authResponse.token);  
          this.router.navigate(["/"]);   
        }
        else{
          this.toastr.error(this.authService.authResponse.message, "Login");
        }
      },
      err => {
        this.toastr.error(err.error.message, "Login");
      }
    )
  }

}
