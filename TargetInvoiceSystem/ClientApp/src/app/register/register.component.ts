import { AuthResponseDto } from '../dtos/auth-response-dto';
import { AuthService } from '../services/auth.service';
import { Component, OnInit, AfterViewInit, ElementRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, AfterViewInit {

  constructor(private element:ElementRef,
              public authService:AuthService,
              private toastr:ToastrService,
              private router:Router){}

  ngOnInit(): void {
    this.authService.registerUser = {
      email: null,
      password: null,
      confirmPassword: null
    };
  }

  ngAfterViewInit(): void {
    this.element.nativeElement.ownerDocument.body.style.backgroundColor='#1a3d58';
  }

  onSubmit(){
    this.authService.register().subscribe(result=>{
        this.authService.authResponse = result as AuthResponseDto;
        if(this.authService.authResponse.isSuccess){
          this.toastr.success(this.authService.authResponse.message, "Register");
          this.router.navigate(['/login']);
        }
      },
      err =>{
        if(err)
          this.toastr.error("User not created successfuly!", "Register");
        console.error(err);
      }
    )
  }

}
