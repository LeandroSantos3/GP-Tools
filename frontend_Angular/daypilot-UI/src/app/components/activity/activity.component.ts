3
import { Workerprofile } from './../../models/WorkerProfile/workerprofile.model';
import { putActivityRequest } from './../../models/Activity/putActivityRequest.model';
import { WorkerprofileService } from './../../services/workerprofile.service';
import { CategoryStateService } from 'src/app/services/category-state.service';
import { CategoryService } from 'src/app/services/category.service';
import { addActivityRequest } from './../../models/Activity/addActivityRequest.model';
import { Component, OnInit } from '@angular/core';
import { Activity } from 'src/app/models/Activity/Activity.model';
import { ActivityService } from 'src/app/services/activity.service';
import { Category } from 'src/app/models/ActivityCategory/Category.model';
import { CategoryState } from 'src/app/models/ActivityCategoryState/CategoryState.model';

import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-activity',
  templateUrl: './activity.component.html',
  styleUrls: ['./activity.component.css']
})
export class ActivityComponent implements OnInit {

  //instanciando 
  activities: Activity [] = [] ;

  //instanciar as Category para dropdown
  categories: Category[] = [];

  //instanciar o form
  addActivityForm!: FormGroup;
  //instanciar o form
  putActivityForm!: FormGroup;

  //instanciar o state para dropdown
  categoriesState: CategoryState[] = [];

  //instanciar o workerprofile para dropdown
  workerprofiles: Workerprofile[] = [];

  // instanciar o addActivityRequest
  addActivityRequest: addActivityRequest = {
    name: '',
    description: '',
    startDate: new Date(),
    endDate: new Date(),
    totalHours: 0,
    parentId: null,
    parent: null,
    activityCategoryId: 0,
    activityCategoryStateId: 0,
    createdBy: 0,
  };

  //instanciar o putActivityRequest
  putActivityRequest: putActivityRequest = {

    id: 0,
    createdBy: 0,
    updatedBy: 0,
    name: '',
    description: '',
    startDate: new Date(),
    endDate: new Date(),
    totalHours: 0,
    parentId: 0,
    activityCategoryId: 0,
    activityCategoryStateId: 0,    
  };

  get name() {
    return this.addActivityForm.get('name')!;
  }
  
  get description() {
    return this.addActivityForm.get('description')!;
  }
  
  get activityCategoryId() {
    return this.addActivityForm.get('activityCategoryId')!;
  }
  
  get activityCategoryStateId() {
    return this.addActivityForm.get('activityCategoryStateId')!;
  }
  
  get createdBy() {
    return this.addActivityForm.get('createdBy')!;
  }
  
  get startDate() {
    return this.addActivityForm.get('startDate')!;
  }
  
  get endDate() {
    return this.addActivityForm.get('endDate')!;
  }
  
  get totalHours() {
    return this.addActivityForm.get('totalHours')!;
  }
  
  get parentId() {
    return this.addActivityForm.get('parentId')!;
  }

  get id(){
    return this.putActivityForm.get('id')!;
  }

  get namePut() {
    return this.putActivityForm.get('namePut')!;
  }
  get descriptionPut() {
    return this.putActivityForm.get('descriptionPut')!;
  }

  get activityCategoryIdPut() {
    return this.putActivityForm.get('activityCategoryIdPut')!;
  }

  get activityCategoryStateIdPut() {
    return this.putActivityForm.get('activityCategoryStateIdPut')!;
  }

  get createdByPut() {
    return this.putActivityForm.get('createdByPut')!;
  }

  get startDatePut() {
    return this.putActivityForm.get('startDatePut')!;
  }

  get endDatePut() {
    return this.putActivityForm.get('endDatePut')!;
  }

  get totalHoursPut() {
    return this.putActivityForm.get('totalHoursPut')!;
  }

  get parentIdPut() {
    return this.putActivityForm.get('parentIdPut')!;
  }

  get updatedByPut() {
    return this.putActivityForm.get('updatedByPut')!;
  }

    
  constructor(private activityService: ActivityService,private route: ActivatedRoute, 
    private categoryService: CategoryService,private categoryStateServie: CategoryStateService, 
    private workerprofileService: WorkerprofileService, private toastr: ToastrService, private router: Router){}

  ngOnInit(): void {

    //this.onCategoryChange(); // chamando o metodo para carregar os dados na tela

    this.initializeForm();
   // this.addActivityForm.reset(); // chamando o metodo para inicializar o form
    this.initializeFormPut(); // chamando o metodo para inicializar o form
    //this.putActivityForm.reset(); // chamando o metodo para inicializar o form
    
    this.getAllActivity(); // chamando o metodo para carregar os dados na tela
    
    //chamar o metodo do outro service apra alimentar o dropdown
    //chamando o serice category
    this.categoryService.getAllCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.log(error);
      }
    );

    //chamando o serice categoryState
    this.categoryStateServie.getAllCategoriesState().subscribe(
      (data) => {
        this.categoriesState = data;
      },
      (error) => {
        console.log(error);
      }
    );  

    //chamando o serice workerprofile
    this.workerprofileService.getAllWorkerProfiles().subscribe(
      (data) => {
        this.workerprofiles = data;
      },
      (error) => {
        console.log(error);
      }
    );

      this.route.params.subscribe(params => {
        const id = params['id'];
        if (id) {
          this.categoryStateServie.getCategoriesStateByActivityId(id).subscribe(
            (data) => {
              this.categoriesState = data;
            },
            (error) => {
              console.log(error);
            }
          );
        }
      });
    }
    
  
  initializeForm() {
    this.addActivityForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      //description: new FormControl(''),
      activityCategoryId: new FormControl('', [Validators.required]),
      activityCategoryStateId: new FormControl('', [Validators.required]),
      createdBy: new FormControl('', [Validators.required]),
      startDate: new FormControl('', [Validators.required]),
      endDate: new FormControl('', [Validators.required]),
      totalHours: new FormControl('', [Validators.required]),
    });
  }

  initializeFormPut() {
    this.putActivityForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      namePut: new FormControl('', [Validators.required]),
      descriptionPut: new FormControl('', [Validators.required]),
      activityCategoryIdPut: new FormControl('', [Validators.required]),
      activityCategoryStateIdPut: new FormControl('', [Validators.required]),
      createdByPut: new FormControl('', [Validators.required]),
      startDatePut: new FormControl('', [Validators.required]),
      endDatePut: new FormControl('', [Validators.required]),
      totalHoursPut: new FormControl('', [Validators.required]),
      parentIdPut: new FormControl('', [Validators.required]),
      updatedByPut: new FormControl('', [Validators.required]),
    });
  }

  getAllActivity(){

    this.activityService.getAllActivity()
    .subscribe({
      next: activities => {     
        console.log(activities);  
        this.activities = activities;
      },
      error:(response) =>{
        console.log(response);
      }
    })
  }

  postActivity() {
    // Validar o formulário
    if (this.addActivityForm.invalid) {
      console.log('Erro no formulário');
      return;
    }
  
    this.activityService.postActivity(this.addActivityRequest)
      .subscribe(
        (response: any) => {
          console.log(response);
          // Lógica de alerta
          if (response.code === 200) {
            // Exibir mensagem de sucesso
            alert('Atividade criada com sucesso!');
            // Chamar o método para carregar os dados na tela
            this.getAllActivity();
            // Limpar o formulário
            this.addActivityForm.reset();
          }
        },
        (error) => {
          // Verificar status da resposta HTTP
          if (error.status !== 200) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            alert('Erro ao criar atividade!');
          }
        }
      );
  }
  

  //metodo GET para pegar o ID > HttpClient ira fazer a requisição
  //para o backend e retornar o objeto
  //o metodo subscribe ira pegar o objeto e atribuir a propriedade - putActivityRequest
  getActivity() {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        
        if (id) 
        {
          this.activityService.getActivity(id).subscribe({
            next: (response) => {             
              this.putActivityRequest = response;
            }
          });
        }
      }
    });
  }


  putActivity() {
    this.activityService.putActivity(this.putActivityRequest.id, this.putActivityRequest)
      .subscribe(
        (response: any) => {
          if (response.code === 200) {
            // Exibir mensagem de sucesso
            //this.toastr.success('Atividade editada com sucesso!', 'Success!');
            alert('Atividade editada com sucesso!');
            // Chamar o método para carregar os dados na tela após a edição
            this.getAllActivity();
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

  
  deleteActivity(id:string){

    this.activityService.deleteActivity(id)
    .subscribe({
      next: (response) => {
        //logica de alert
        //this.toastr.success('Atividade deletada com successo!', 'Success!');   
        alert('Atividade deletada com successo!');
        // Chamar o método para carregar os dados na tela
        this.getAllActivity();
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