import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dev-navbar',
  templateUrl: './dev-navbar.component.html',
  styleUrls: ['./dev-navbar.component.css']
})
export class DevNavbarComponent implements OnInit{

  public userType:string | null = null;

  //chamar a variavel no login que faz a verigficaçao se o user esta logado
  sessionAtivo = Boolean(sessionStorage.getItem('logged'));

  constructor ( private router: Router){      
  }
  
  ngOnInit(): void {

    // Obtenha o userType do localStorage ao iniciar o componente
    this.userType = localStorage.getItem("userType");    
  }

  logout(){
    //tenho que limpar os dados da sessão antes   
    sessionStorage.clear();
    localStorage.clear();
    // resetar o valor da variavel logged
    this.sessionAtivo = false;
    
    this.router.navigateByUrl('/login');
  }

}
