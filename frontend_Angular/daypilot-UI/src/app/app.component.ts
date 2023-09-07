// import { Component } from '@angular/core';

// @Component({
//   selector: 'app-root',
//   templateUrl: './app.component.html',
//   styleUrls: ['./app.component.css']
// })
// export class AppComponent {
//   //title = 'daypilot-UI';

//   userType: string | null=null;
//   //sessionStorage: any;

//   //chamar a variavel no login que faz a verigficaçao se o user esta logado	
//   //sessionAtivo = Boolean(sessionStorage.getItem('logged'));

//   constructor() {
//     // Obtenha o userType do localStorage ao iniciar o componente
//     this.userType = localStorage.getItem('userType');
//     sessionStorage.getItem('logged');
//   }
// }


import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  userType: string | null = null;

  constructor() {
    this.userType = localStorage.getItem('userType');
  }
}
