import { ActivityComponent } from './../activity/activity.component';
import { ChangeDetectorRef, Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminNavbarComponent } from '../admin-navbar/admin-navbar.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  logged:boolean = false;

  constructor(private router: Router, private cdr: ChangeDetectorRef) {}

  public loginForm: FormGroup = new FormGroup({
    username: new FormControl(),
    password: new FormControl()
  });


login() 
  {

    const { username, password } = this.loginForm.value;

    if (username == 'admin' && password == '1234') {
       console.log('Login bem-sucedido! ADMIN');

       this.logged=true;       

          //variavel de sessão
          localStorage.setItem('userType','admin');
            //redecionar para pagina Admin
            if(this.logged==true){

            sessionStorage.setItem('logged', this.logged.toString()); //guardar a varivel em string
            this.router.navigate(['/gptools']);
            }
            else{
              alert("Credenciais erradas");
              this.router.navigate(['/login']);
            }
          }
          
          else if (username == 'dev' && password == '1234') {
      console.log('Login bem-sucedido! DEV');
      this.logged=true;       

      //variavel de sessão
      localStorage.setItem('userType','dev');
        //redecionar para pagina Admin
        if(this.logged==true){

         sessionStorage.setItem('logged', this.logged.toString()); //guardar a varivel em string
          this.router.navigate(['/gptools']);
        }
        else{
          alert("ERRADO");
          this.router.navigate(['/login']);
        } // Espera 3 segundos (3000 milissegundos) antes de redirecionar
      }
    else{
      alert('Nome de usuário ou senha inválidos.');
    }
  }
}
