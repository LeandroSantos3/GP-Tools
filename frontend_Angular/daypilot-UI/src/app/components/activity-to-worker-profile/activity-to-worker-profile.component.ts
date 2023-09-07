import { putActivityRequest } from './../../models/Activity/putActivityRequest.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ActivityWorkerProfileService } from './../../services/activity-worker-profile.service';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivityToWorkerProfile } from 'src/app/models/ActivityWorkerProfile/ActivityToWorker.model';
import { ActivityToWorkerProfileRequest } from 'src/app/models/ActivityWorkerProfile/ActivityToWorkerProfileRequest.model';
import { Activity } from 'src/app/models/Activity/Activity.model';
import { Workerprofile } from './../../models/WorkerProfile/workerprofile.model';
import { ActivityService } from 'src/app/services/activity.service';
import { WorkerprofileService } from 'src/app/services/workerprofile.service';
import { putActivityToWorkerProfileRequest } from 'src/app/models/ActivityWorkerProfile/putActivityToWorkerProfileRequest.model';


import * as bootstrap from 'bootstrap';
import { FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-activity-to-worker-profile',
  templateUrl: './activity-to-worker-profile.component.html',
  styleUrls: ['./activity-to-worker-profile.component.css']
})
export class ActivityToWorkerProfileComponent implements OnInit {
  

  //instanciando o ActivityWorkerProfile
  activityWorkerProfiles: ActivityToWorkerProfile[] = [];

  // instanciando o ActivityWorkerProfile
  addActivityWorkerProfileRequest: ActivityToWorkerProfileRequest = {
    activityId: 0,
    workerProfileId: 0,
    createdBy: 0,
    totalHours: 0
  };

  putActivityWorkerProfileRequest: putActivityToWorkerProfileRequest = {
    id: 0,
    activityId: 0,
    workerProfileId: 0,
    createdBy: 0,
    totalHours: 0,
    updateBy: 0
  };


  //instanciando as Activity para dropdown
  activities: Activity [] = [] ;

  //instanciar o workerprofile para dropdown
  workerprofiles: Workerprofile[] = [];

  //instanciar o form
  addActivityWorkerForm!: FormGroup;
  //instanciar o form
 // putActivityWorkerForm!: FormGroup;

  // ! = não nulo
  //metodo para pegar os campos do form
  get activityId(){
    return this.addActivityWorkerForm.get('activityId')!;
  }
  get workerProfileId(){
    return this.addActivityWorkerForm.get('workerProfileId')!;
  }
  
  get createdBy(){
    return this.addActivityWorkerForm.get('createdBy')!;
  }

  get totalHours(){
    return this.addActivityWorkerForm.get('totalHours')!;
  }

  @ViewChild('ConfDel') ConfDel!: ElementRef;

  constructor(private activityToWorkerProfileService: ActivityWorkerProfileService, private route: ActivatedRoute,
    private activityService: ActivityService, private workerprofileService: WorkerprofileService, private router: Router  ) { }
  
  ngOnInit(): void {

    this.initializeForm();
    //this.initializePutForm();
  
    this.getAllActivityWorkerProfile();

    //chamando o service WorkerProfile
    this.workerprofileService.getAllWorkerProfiles().subscribe(
      (data) => {
        this.workerprofiles = data;
      },
      (error) => {
        console.log(error);
      }
    );

    // chamando o service Activity
    this.activityService.getAllActivity().subscribe(
      (data) => {
        this.activities = data;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  initializeForm() {
    this.addActivityWorkerForm = new FormGroup({
      activityId: new FormGroup('',[Validators.required]),
      workerProfileId: new FormGroup('',[Validators.required]),
      totalHours: new FormGroup('',[Validators.required]),
      createdBy: new FormGroup('',[Validators.required])
    });
  }


  async openModalDel(categoryId: number) {
    if (true) {
      this.router.navigate(['/ActivityWorkerProfile/del/', categoryId]);
      await this.getAllActivityWorkerProfile(); // Aguarda a conclusão da chamada assíncrona
  
      await new Promise(resolve => setTimeout(resolve, 200));
      
      const modalElement = document.getElementById('ConfDel');
      if (modalElement) {
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
      }
    }
  }

  
  
  // metodo Get do service
  getAllActivityWorkerProfile(){

    this.activityToWorkerProfileService.getAllActivityWorkerProfile()
    .subscribe({
      next: activityWorkerProfiles => {  
        console.log("-------" +activityWorkerProfiles);  
        this.activityWorkerProfiles = activityWorkerProfiles;
      },
      error:(response) =>{
        console.log(response);
      }
    })
  }

  postActivityWorkerProfile() {
    // Validar o formulário
    if (this.addActivityWorkerForm.invalid) {
      console.log('erro no formulário');
      return;
    }
  
    this.activityToWorkerProfileService.postActivityWorkerProfile(this.addActivityWorkerProfileRequest)
      .subscribe(
        (response: any) => {
         // console.log(response);
          // Lógica de alerta
          if (response.code === 200) {
            // Exibir mensagem de sucesso
            alert('Perfil de Trabalhador associado com sucesso!');
  
            // Chamar o método para carregar os dados na tela
            this.getAllActivityWorkerProfile();
            // Criar um método para limpar o formulário
            this.addActivityWorkerForm.reset();
          }
        },
        (error) => {
          // Verificar status da resposta HTTP
          if (error.status !== 200) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            alert('Erro ao associar perfil de trabalhador!');
          }
        }
      );
  }
  
    //metodo get para pegar o id
    getActivityWorkerProfile() {
      this.route.paramMap.subscribe({
        next: (params) => {
          const id = params.get('id');
          
          if (id) 
          {
            this.activityToWorkerProfileService.getActivityWorkerProfile(id).subscribe({
              next: (response) => {             
                this.putActivityWorkerProfileRequest = response;
                console.log(this.putActivityWorkerProfileRequest.id);
              }
            });
          }
        }
      });
    }
  
    //metodo put para atualizar o id
    putActivityWorkerProfile() {
      
      this.activityToWorkerProfileService.putActivityWorkerProfile(
        this.putActivityWorkerProfileRequest.id, this.putActivityWorkerProfileRequest)
        .subscribe(
          (response: any) => {    if (response.code === 200) {
              // Exibir mensagem de sucesso
              alert('Atividade editada com successo!');            
    
              // Chamar o método para carregar os dados na tela
              this.getAllActivityWorkerProfile();            
            }
          },
          (error) => {
            // Verificar status da resposta HTTP
            if (error.status !== 200) {
              // Exibir informações do erro no console
              console.log('Descrição do erro:', error.status);
              alert('Erro ao atualizar categoria!');
            }
          }
        );
    }

    deleteActivityWorkerProfile(id:string){

      this.activityToWorkerProfileService.deleteActivityWorkerProfile(id)
      .subscribe({
        next: (response) => {
          
          //logica de alert
          alert('Categoria eliminada (soft Delete) com sucesso!');
          this.getAllActivityWorkerProfile();
        },
        error: (error) => {
          // Verificar status da resposta HTTP
          if (error.status === 500) {
           // Exibir informações do erro no console
           console.log('Descrição do erro:', error.status);
           // Tratar o erro com base nas informações recebidas
           alert('Falha ao eliminar a categoria, FK em outra tabela!');           
           return;
          }else (error.status !== 200 && error.status !== 500) 
             // Exibir informações do erro no console
             console.log('Descrição do erro:', error.status);
             // Tratar o erro com base nas informações recebidas
             alert('Falha ao eliminar a categoria!');     
       }
     });
    }


}