import { putCategoryRequest } from '../models/ActivityCategory/putCategoryRequest.model';
import { addCategory } from '../models/ActivityCategory/addCategory.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from '../models/ActivityCategory/Category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  
  baseApiUrl: string = environment.baseApiUrl;

  
  errorMessage: string | null=null;
  successMessage: string | null=null;

  //tenho que injetar um client HTTP para me comunicar com a API
  constructor(private http: HttpClient) { }

  //criar metodo capaz de chamar a web api
  getAllCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(this.baseApiUrl + '/ActivityCategory');
  }

  // getAllCategoriesPage(page:number,size:number): Observable<Category[]>{
  //   return this.http.get<Category[]>(this.baseApiUrl + '/ActivityCategory?page=${page}&size=${size}');
  // }

  postCategory(addCategory: addCategory): Observable<Category>{
    return this.http.post<Category>(this.baseApiUrl + '/ActivityCategory',addCategory);
  }

  getCategory(id:string): Observable<Category> {

    return this.http.get<Category>(this.baseApiUrl + "/ActivityCategory/"+ id);

  }
  
  putCategory(id: number, putCategoryRequest:putCategoryRequest): Observable<Category>{
    
    return this.http.put<Category>(this.baseApiUrl + '/ActivityCategory/' + id, putCategoryRequest)    
  }

  deleteCategory(id: string): Observable<Category> {
    return this.http.delete<Category>(this.baseApiUrl + '/ActivityCategory/' + id);
  }

  // showMessages() {
  //   // Limite de tempo para a mensagem de sucesso
  //   setTimeout(() => {
  //     this.successMessage = null;
  //   }, 5000); // 5 segundos (5000 milissegundos)
  
  //   // Limite de tempo para a mensagem de erro
  //   setTimeout(() => {
  //     this.errorMessage = null;
  //   }, 5000); // 5 segundos (5000 milissegundos)
  // }
  
  // closeModalAfterCompletion() {
  //   // Aguarde 5 segundos antes de fechar o modal
  //   setTimeout(() => {
  //     // Fechar o modal
  //     const modalElement = document.getElementById('ConfDel');
  //     if (modalElement) {
  //       modalElement.classList.remove('show');
  //       modalElement.style.display = 'none';
  //       const modalBackdrop = document.getElementsByClassName('modal-backdrop')[0];
  //       if (modalBackdrop) {
  //         modalBackdrop.parentNode?.removeChild(modalBackdrop);
  //       }
  //     }
  //   }, 5000); // 5 segundos (5000 milissegundos)
  // }
  

}
