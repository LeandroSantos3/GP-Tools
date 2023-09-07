
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CategoryState } from '../models/ActivityCategoryState/CategoryState.model';
import { addCategoryState } from '../models/ActivityCategoryState/addCategoryState.model';
import { putCategoryState } from '../models/ActivityCategoryState/putCategoryState.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryStateService {

  baseApiUrl: string = environment.baseApiUrl;
  //tenho que injetar um client HTTP para me comunicar com a API
  constructor(private http: HttpClient) { }

  //criar metodo capaz de chamar a web api
  getAllCategoriesState(): Observable<CategoryState[]>{

    return this.http.get<CategoryState[]>(this.baseApiUrl + '/ActivityCategoryState');

  }

  postCategoryState(addCategoryState: addCategoryState): Observable<CategoryState>{
    return this.http.post<CategoryState>(this.baseApiUrl + '/ActivityCategoryState',addCategoryState);
  }

  getCategoryState(id:string): Observable<CategoryState> {

    return this.http.get<CategoryState>(this.baseApiUrl + "/ActivityCategoryState/"+ id);

  }
  
  putCategoryState(id: number, putCategoryRequest:putCategoryState): Observable<CategoryState>{
    
    return this.http.put<CategoryState>(this.baseApiUrl + '/ActivityCategoryState/all/' + id, putCategoryRequest)    
  }

  deleteCategoryState(id: string): Observable<CategoryState> {
    return this.http.delete<CategoryState>(this.baseApiUrl + '/ActivityCategoryState/del/' + id);
  }

  getCategoriesStateByActivityId(id: string): Observable<CategoryState[]> {
    return this.http.get<CategoryState[]>(this.baseApiUrl + '/ActivityCategoryStateByCategoryId/' + id);
  }
}
