import { Workerprofile } from './../../models/WorkerProfile/workerprofile.model';

import { putCategoryRequest } from '../../models/ActivityCategory/putCategoryRequest.model';
import { addCategory } from '../../models/ActivityCategory/addCategory.model';
import { Component, ElementRef, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { Category } from 'src/app/models/ActivityCategory/Category.model';
import { CategoryService } from 'src/app/services/category.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Delete } from 'src/app/models/Delete.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { WorkerprofileService } from 'src/app/services/workerprofile.service';
import { ToastrService } from 'ngx-toastr';



import * as bootstrap from 'bootstrap';




@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {

  //instanciar o form
  addCategoryForm!: FormGroup;
  //instanciar o form
  putCategoryForm!: FormGroup;
  
  //instanciando category
  categories: Category [] = [] ;
  //instanciar as Category para dropdown
  workerprofiles: Workerprofile[] = [];  
   
  addCategory: addCategory = {

    id: 0,
    name: '',
    createdBy: 0,    
  };

  putCategoryRequest: putCategoryRequest = {
    id: 0,
    name: '',
    createdBy: 0,
    createdDate: new Date(),
    updateBy: 0,
    
  };

  delete: Delete = {
    id: 0,
  };
  
  // ! = não nulo
    //metodo para pegar os campos do form
  get name(){
    return this.addCategoryForm.get('name')!;
  }

  get createdBy(){
    return this.addCategoryForm.get('createdBy')!;
  }

  get namePut(){
    return this.putCategoryForm.get('namePut')!;
  }

  get createdByPut(){
    return this.putCategoryForm.get('createdByPut')!;
  }
  get updatedByPut(){
    return this.putCategoryForm.get('updatedByPut')!;
  }

  get createdDatePut(){
    return this.putCategoryForm.get('createdDatePut')!;
  }


 @ViewChild('btEditModal') btEditModal!: ElementRef;
 @ViewChild('ConfDel') ConfDel!: ElementRef;
 

  constructor(private categoryService: CategoryService, private route: ActivatedRoute,
      private workerprofileService: WorkerprofileService, private toastr: ToastrService,
      private router: Router) {}
  

  ngOnInit(): void {

    //chamar o metodo para inicializar o form
    this.initializeForm();
    this.initializePutForm();

    //chamar o metodo para carregar as categorias
    this.getAllCategories();

    //chamar o metodo do outro service apra alimentar o dropdown
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
    this.router.navigate(['/ActivityCategory/', categoryId]);
    await this.getCategory(); // Aguarda a conclusão da chamada assíncrona

    await new Promise(resolve => setTimeout(resolve, 1000));
    
    const modalElement = document.getElementById('btEdit');
    if (modalElement) {
      const modal = new bootstrap.Modal(modalElement);
      modal.show();
    }
  }
}

async openModalDel(categoryId: number) {
  if (true) {
    this.router.navigate(['/ActivityCategory/', categoryId]);
    await this.getCategory(); // Aguarda a conclusão da chamada assíncrona

    await new Promise(resolve => setTimeout(resolve, 200));
    
    const modalElement = document.getElementById('ConfDel');
    if (modalElement) {
      const modal = new bootstrap.Modal(modalElement);
      modal.show();
    }
  }
}

  //metodo para inicializar o form
  //verificar os campos
  initializeForm() {
    this.addCategoryForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      createdBy: new FormControl('', [Validators.required])
    });
  }
  
  initializePutForm() {
    this.putCategoryForm = new FormGroup({
      id: new FormControl(''), 
      namePut: new FormControl('', [Validators.required]),
      createdByPut: new FormControl('', [Validators.required]),
      //createdDatePut: new FormControl('', [Validators.required]),
      updateByPut: new FormControl('', [Validators.required])
    });
  }

//metodo GET
  getAllCategories(){

    this.categoryService.getAllCategories()
    .subscribe({
      next: categories => {     
        console.log(categories);  
        this.categories = categories;
        //this.dtTrigger.next(null);   
      },
      error:(response) =>{
        console.log(response);
      }
    })
  }


  //metodo POST
  postCategory() {

    //validar o form
    if(this.addCategoryForm.invalid){

    console.log('erro no formulario');
    return;
    }

    this.categoryService.postCategory(this.addCategory)
      .subscribe(
        (response: any) => {
         console.log(response);
          // Lógica de alerta
          if (response.code === 200) {
            // Exibir mensagem de sucesso
          alert('Categoria criada com sucesso!');            
          //this.toastr.success('Activity created with success!', 'Success!');       

          // Chamar o método para carregar os dados na tela
          this.getAllCategories(); 
          //criar um metodo para limpar o form
          this.addCategoryForm.reset();
        }          
        },
        (error) => {
          // Verificar status da resposta HTTP
          if (error.status !== 200) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            alert('Erro ao criar categoria!');
            
          }
        }
      );
  }

//metodo GET por ID para alimentar PUT
  getCategory() {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        
        if (id) 
        {
          this.categoryService.getCategory(id).subscribe({
            next: (response) => {             
              this.putCategoryRequest = response;
              console.log("----" + this.putCategoryRequest);
            }
          });
        }
      }
    });
  }

  //metodo PUT
  putCategory() {

    if(this.putCategoryForm.invalid){

      console.log('erro no form');
      alert('Erro ao abrir os formulário de inserção!');
      return;
    }

    this.categoryService.putCategory(this.putCategoryRequest.id, this.putCategoryRequest)
      .subscribe(
        (response: any) => {
          if (response.code === 200) {
            // Exibir mensagem de sucesso
            alert('Atividade editada com successo!');            
  
            // Chamar o método para carregar os dados na tela
            this.getAllCategories();            
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
  
  deleteCategory(id: string) { 

    this.categoryService.deleteCategory(id)
      .subscribe({
        next: (response) => {

          console.log('----->Foi?');
          //this.toastr.success('Categoria excluída com sucesso!');
          alert('Categoria excluída com sucesso!');  
          //this.toastr.success('Categoria excluída com sucesso!');
            this.getAllCategories();
        },
        error: (error) => {
           // Verificar status da resposta HTTP
           if (error.status === 500) {
            // Exibir informações do erro no console
            console.log('Descrição do erro:', error.status);
            // Tratar o erro com base nas informações recebidas
            //this.toastr.error('Falha ao eliminar a categoria, FK em outra tabela!');
            alert('Falha ao eliminar a categoria, FK em outra tabela!');           
            return;
           }else (error.status !== 200 && error.status !== 500) 
              // Exibir informações do erro no console
              console.log('Descrição do erro:', error.status);
              // Tratar o erro com base nas informações recebidas
              //this.toastr.error('Falha ao eliminar a categoria!');
              alert('Falha ao eliminar a categoria!');     
        }
      });
  } 
}

