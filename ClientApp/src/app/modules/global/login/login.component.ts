import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Sessions } from 'src/app/libraries/sessions';
import { AuthService, IUserLogin } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required])
  });

  constructor(private router : Router, private _authService : AuthService) { }

  ngOnInit(): void {
  }

  btnIniciarSesion_onClick() : void {
    
    let objUserLogin: IUserLogin = Object.assign({}, this.loginForm.value);
    
    this._authService.login(objUserLogin).subscribe(
      objResponse => {
        
        if (Sessions.start(objResponse)) {
          this.router.navigate(['/index']);
        } else {
          alert("El usuario y/o el password son incorrectos. Por favor verifique la informacíon");
        }

      }, objError => {
        alert("El usuario y/o el password son incorrectos. Por favor verifique la informacíon");
      });
  }

  btnBack(){
    Sessions.sessionDestroy();
    this.router.navigate(['/login']);
  }
}
