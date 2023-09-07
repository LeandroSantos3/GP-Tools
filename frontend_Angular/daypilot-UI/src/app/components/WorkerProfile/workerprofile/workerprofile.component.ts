import { putWorkerProfileRequest } from '../../../models/WorkerProfile/putWorkerProfileRequest.model';
import { WorkerprofileService } from './../../../services/workerprofile.service';
import { Workerprofile } from './../../../models/WorkerProfile/workerprofile.model';
import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';
import { addWorkerProfileRequest } from 'src/app/models/WorkerProfile/addWorkerProfileRequest.model';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Delete } from 'src/app/models/Delete.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-workerprofile',
  templateUrl: './workerprofile.component.html',
  styleUrls: ['./workerprofile.component.css']
})
export class WorkerprofileComponent implements OnInit {

  //instanciando 
  workerprofiles: Workerprofile[] = [];

  addWorkerProfileRequest: addWorkerProfileRequest = {
    name: '',
    code: 0,
    createdBy: 0,
  };

  putWorkerProfileRequest: putWorkerProfileRequest = {
    id: 0,
    name: '',
    code: 0,
  };

  delete: Workerprofile = {
    id: 0,
    name: '',
    code: 0,
    createdBy: 0,
    createdDate: new Date,
    updateBy: 0,
    updatedDate: new Date,
    isActive: false
  };

  i: number=0;

  addWorkerForm!: FormGroup;
  putWorkerForm!: FormGroup;

  get name(){
    return this.addWorkerForm.get('name')!;
  }

  get createdBy(){
    return this.addWorkerForm.get('createdBy')!;
  }

  get code(){
    return this.addWorkerForm.get('code')!;
  }

  get namePut(){
    return this.putWorkerForm.get('namePut')!;
  }
  get codePut(){
    return this.putWorkerForm.get('codePut')!;
  }

  // userType: string | null = null;
  // sessionAtivo = Boolean(sessionStorage.getItem('logged'));

  constructor(private workerprofileService: WorkerprofileService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.initializeForm();
    this.initializeFormPut(); 
    this.getAllWorkerProfile();
    
  
  }

  initializeForm() {
    this.addWorkerForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      createdBy: new FormControl('', [Validators.required]),
      code: new FormControl('', [Validators.required]),
    });
  }

  initializeFormPut() {
    this.putWorkerForm = new FormGroup({
      namePut: new FormControl('', [Validators.required]),     
      codePut: new FormControl('', [Validators.required]),
    });
  }

  getAllWorkerProfile() {
    this.workerprofileService.getAllWorkerProfiles()
    .subscribe({
      next: workerprofiles => {
        this.workerprofiles = workerprofiles;

        console.log(this.putWorkerProfileRequest);
        
      },
      error: (response) => {
        console.log(response);
      }
    });
  }


  postWorkerProfile() {
    // Validar o formulário
    if (this.addWorkerForm.invalid) {
      console.log('Erro no formulário');
      return;
    }
  
    this.workerprofileService.postWorkerProfile(this.addWorkerProfileRequest)
      .subscribe(
        (response: any) => {
          console.log(response);
          if (response.code === 200) {
            // Exibir mensagem de sucesso
            alert('Perfil de trabalhador criado com sucesso!');
  
            // Chamar o método para carregar os dados na tela
            this.getAllWorkerProfile();
  
            // Limpar o formulário
            this.addWorkerForm.reset();
          }
        },
        (error) => {
          // Verificar status da resposta HTTP
          if (error.status !== 200) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            alert('Erro ao criar perfil de trabalhador!');
          }
        }
      );
  }
  


  //metodo funciona, mas o log vem sempre repetido
  //tipo mostra o log do pedido anterior 1x e o atual 3x - 1 pedido e 2x repetiçao
  getWorkerProfile() {
    this.i=0;
    console.log("where we go, its Mario");
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if (id) {
          this.workerprofileService.getWorkerProfile(id).subscribe({
            next: (response) => {
              this.i++;
              console.log("RESPOSTA GET--------> "+this.i, response);
              this.putWorkerProfileRequest = response;
            }
          });
        }
      }
    });
  }
  

  // putWorkerProfile() {

  //   if(this.putWorkerForm.invalid){

  //     console.log('erro no form');
  //     alert('Erro ao abrir os formulário de inserção!');
  //     return;
  //   }
    
  //   this.workerprofileService.putWorkerProfile(
  //     this.putWorkerProfileRequest.id, this.putWorkerProfileRequest).subscribe({
  //       next: (workerprofile) =>{
  //       }
  //     })
  // }

  putWorkerProfile() {
    // Validar o formulário
    if (this.putWorkerForm.invalid) {
      console.log('Erro no formulário');
      alert('Erro ao abrir o formulário de atualização!');
      return;
    }
  
    this.workerprofileService.putWorkerProfile(this.putWorkerProfileRequest.id, this.putWorkerProfileRequest)
      .subscribe(
        (response: any) => {
          console.log(response);
          if (response.code === 200) {
            // Exibir mensagem de sucesso
            alert('Perfil de trabalhador atualizado com sucesso!');
  
            // Chamar o método para carregar os dados na tela
            this.getAllWorkerProfile();
          }
        },
        (error) => {
          // Verificar status da resposta HTTP
          if (error.status !== 200) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            alert('Erro ao atualizar perfil de trabalhador!');
          }
        }
      );
  }
  

  // deleteWorkerProfile(id:string){
  //   this.workerprofileService.deleteWorkerProfile(id, this.delete)
  //   .subscribe({
  //     next: (response) =>{
  //       // Lógica para alterar o estado do objeto

  //     // Chamar o alert após alterar o estado
  //     alert('Estado do objeto alterado com sucesso');
  //     console.log('Estado do objeto alterado com sucesso');
      
  //   },
  //     error: (error) => {
  //       // Lidar com erros
  //       }
  //   })
  // }

  // deleteWorkerProfile(id: string) {
  //   this.workerprofileService.deleteWorkerProfile(id, this.delete)
  //     .subscribe({
  //       next: (response) => {
  //         // Lógica para alterar o estado do objeto
         
  //         alert('Estado do objeto alterado com sucesso');
  //         console.log('Estado do objeto alterado com sucesso');
  //         this.getAllWorkerProfile();
  //         // Chamar o alert após alterar o estado
         
  //       },
  //       (error) => {
  //         // Verificar status da resposta HTTP
  //         if (error.status === 500) {
  //           // Exibir informações do erro no console
  //           console.log('Descrição do erro:', error.status);
  //           // Tratar o erro com base nas informações recebidas
  //           alert('Falha ao excluir perfil de trabalhador: FK em outra tabela!');
  //         } else if (error.status !== 200 && error.status !== 500) {
  //           // Exibir informações do erro no console
  //           console.log('Descrição do erro:', error.status);
  //           // Tratar o erro com base nas informações recebidas
  //           alert('Falha ao excluir perfil de trabalhador!');
  //         }
  //       }
  //     );
  // }

  deleteWorkerProfile(id: string) {
    this.workerprofileService.deleteWorkerProfile(id, this.delete)
      .subscribe(
        (response) => {
          // Lógica para alterar o estado do objeto
          
          // Exibir mensagem de sucesso
          alert('Estado do objeto alterado com sucesso');
          console.log('Estado do objeto alterado com sucesso');
          
          // Chamar o método para carregar os dados na tela
          this.getAllWorkerProfile();
        },
        (error) => {
          // Verificar status da resposta HTTP
          if (error.status === 500) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            // Tratar o erro com base nas informações recebidas
            alert('Falha ao excluir perfil de trabalhador: FK em outra tabela!');
          } else if (error.status !== 200 && error.status !== 500) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            // Tratar o erro com base nas informações recebidas
            alert('Falha ao excluir perfil de trabalhador!');
          }
        }
      );
  }
  
  


}

