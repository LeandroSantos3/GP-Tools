import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-navbar',
  templateUrl: './admin-navbar.component.html',
  styleUrls: ['./admin-navbar.component.css']
})
export class AdminNavbarComponent implements OnInit {
  static isPageRefreshed: boolean;
  show(): AdminNavbarComponent {
    throw new Error('Method not implemented.');
  }

  public userType:string | null = null;

  sessionAtivo = Boolean(sessionStorage.getItem('logged')); //igualar a variavel ao que vem do login
  
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
