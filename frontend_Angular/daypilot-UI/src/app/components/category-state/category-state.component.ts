import { Workerprofile } from './../../models/WorkerProfile/workerprofile.model';
import { WorkerprofileService } from './../../services/workerprofile.service';
import { putCategoryState } from './../../models/ActivityCategoryState/putCategoryState.model';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { CategoryState } from 'src/app/models/ActivityCategoryState/CategoryState.model';
import { addCategoryState } from 'src/app/models/ActivityCategoryState/addCategoryState.model';
import { Category } from 'src/app/models/ActivityCategory/Category.model';
import { CategoryStateService } from 'src/app/services/category-state.service';
import { CategoryService } from 'src/app/services/category.service';
import { Delete } from 'src/app/models/Delete.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import * as bootstrap from 'bootstrap';

@Component({
  selector: 'app-category-state',
  templateUrl: './category-state.component.html',
  styleUrls: ['./category-state.component.css']
})
export class CategoryStateComponent implements OnInit {
  
  //instanciando 
  categoriesState: CategoryState [] = [] ;

  //instanciar as Category para dropdown
  categories: Category[] = [];

  //instanciar o workerprofile para dropdown
  workerprofiles: Workerprofile [] = [];

  addCategoryState: addCategoryState = {
    name: '',
    createdBy: 0,
    isLocked: false,
    activityCategoryId: 0,
  };

  putCategorieState: putCategoryState={
    id: 0,
    name: '',
    isLocked: false,
    createdBy: 0,
    createdDate: new Date(),
    updateBy: 0,
    activityCategoryId: null
  };
  
  delete: Delete ={
    id: 0,
  }

   //instanciar o form
   addStateForm!: FormGroup;
   //instanciar o form
   putStateForm!: FormGroup;
  
  // ! = não nulo
    //metodo para pegar os campos do form
    get name(){
      return this.addStateForm.get('name')!;
    }
  
    get createdBy(){
      return this.addStateForm.get('createdBy')!;
    }

    get activityCategoryId(){
      return this.addStateForm.get('activityCategoryId')!;
    }

    //metodo para pegar os campos do form PUT~
    get namePut(){
      return this.putStateForm.get('namePut')!;
    }

    get createdByPut(){
      return this.putStateForm.get('createdByPut')!;
    }

    get activityCategoryIdPut(){
      return this.putStateForm.get('activityCategoryIdPut')!;
    }

    get isLockedPut(){
      return this.putStateForm.get('isLockedPut')!;
    }

    get updateByPut(){
      return this.putStateForm.get('updateByPut')!;
    }

    @ViewChild('btEditModal') btEditModal!: ElementRef;
    @ViewChild('ConfDelState') ConfDel!: ElementRef;


  constructor(private categoryStateService: CategoryStateService, private route: ActivatedRoute,
    private categoryService: CategoryService, private workerprofileService: WorkerprofileService,
    private router: Router ){}

  ngOnInit(): void {

    this.initializeForm();
    this.initializePutForm();

    this.getAllCategoriesState();

    //chamar o metodo do outro service apra alimentar o dropdown
    this.categoryService.getAllCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.error(error);
      }
    );

    this.workerprofileService.getAllWorkerProfiles().subscribe(
      (data) => {
        this.workerprofiles = data;
      },
      (error) => {
        console.error(error);
      }
    );

  }

  async openModal(categoryId: number) {
    if (true) {
      this.router.navigate(['/ActivityCategoryState/all/', categoryId]);
      await this.getCategoryState(); // Aguarda a conclusão da chamada assíncrona
  
      await new Promise(resolve => setTimeout(resolve, 1000));
      
      const modalElement = document.getElementById('btEdit2');
      if (modalElement) {
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
      }
    }
  }

  async openModalDel(categoryId: number) {
    if (true) {
      this.router.navigate(['/ActivityCategoryState/all/', categoryId]);
      await this.getCategoryState(); // Aguarda a conclusão da chamada assíncrona
  
      await new Promise(resolve => setTimeout(resolve, 200));
      
      const modalElement = document.getElementById('ConfDelState');
      if (modalElement) {
        const modal = new bootstrap.Modal(modalElement);
        modal.show();
      }
    }
  }
  


   //metodo para inicializar o form
  //verificar os campos
  initializeForm() {
    this.addStateForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      createdBy: new FormControl('', [Validators.required]),
      activityCategoryId: new FormControl('', [Validators.required])
    });
  }
  
  initializePutForm() {
    this.putStateForm = new FormGroup({
      id: new FormControl(''), 
      namePut: new FormControl('', [Validators.required]),
      createdByPut: new FormControl('', [Validators.required]),
      activityCategoryIdPut: new FormControl('', [Validators.required]),
      isLockedPut: new FormControl('', [Validators.required]),
      updateByPut: new FormControl('', [Validators.required])
    });
  }

  getAllCategoriesState(){

    this.categoryStateService.getAllCategoriesState()
    .subscribe({
      next: categories => {     
        console.log(categories);  
        this.categoriesState = categories;
      },
      error:(response) =>{
        console.log(response);
      }
    })
  }

  // metodo POST
  postCategoryState() {
    // Pegar os valores do form
    if (this.addStateForm.invalid) {
      console.log("Formulário inválido");
      alert("Formulário inválido");
      return;
    }
    this.categoryStateService.postCategoryState(this.addCategoryState)
      .subscribe({
        next: (addCategoryState) => {
          console.log("estou aqui");
          // Lógica de verificação de campos
          alert("Novo estado adicionado com sucesso!");
  
          // Atualizar a lista de categorias
          this.getAllCategoriesState();
          // Limpar o form
          this.addStateForm.reset();
        },
        error: (error) => {
          if (error.status !== 200) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            alert('Erro ao criar novo estado de categoria!');
          }
        }
      });
  }
  

  getCategoryState() {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        
        if (id) 
        {
          this.categoryStateService.getCategoryState(id).subscribe({
            next: (response) => {             
              this.putCategorieState = response;
              console.log("+------"+this.putCategorieState.id);
            }
          });
        }
      }
    });
  }
  

  putCategoryState() {
    if (this.putStateForm.invalid) {
      console.log('erro no form');
      alert('Erro ao abrir os formulário de inserção!');
      return;
    }
  
    this.categoryStateService.putCategoryState(this.putCategorieState.id, this.putCategorieState)
      .subscribe(
        (response: any) => {
          if (response.code === 200) {
            // Exibir mensagem de sucesso
            alert('Estado da categoria atualizado com sucesso!');
  
            // Chamar o método para carregar os dados na tela
            this.getAllCategoriesState();
          }
        },
        (error) => {
          // Verificar status da resposta HTTP
          if (error.status !== 200) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            alert('Erro ao atualizar estado da categoria!');
          }
        }
      );
  }
  
 
  deleteCategoryState(id: string) {
    this.categoryStateService.deleteCategoryState(id)
      .subscribe({
        next: (response) => {
         alert("Estado de categoria excluído com sucesso!");

          // Atualizar a lista de categorias
          this.getAllCategoriesState();
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
