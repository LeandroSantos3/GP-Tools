
import { putActivityRequest } from './../models/Activity/putActivityRequest.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { addActivityRequest } from '../models/Activity/addActivityRequest.model';
import { Activity } from '../models/Activity/Activity.model';

@Injectable({
  providedIn: 'root'
})
export class ActivityService { 
  
  //criar uma variavel para armazenar a url da API
  //environment é um objeto que contem as variaveis de ambiente
  //vindo do arquivo environment.ts
  baseApiUrl: string = environment.baseApiUrl;

  //tenho que injetar um client HTTP para me comunicar com a API
  //já injetado no app.module.ts
  //injetar o HttpClient no construtor
  constructor(private http: HttpClient) { }

  //criar metodo GET
  //Observable é um tipo de objeto que permite que eu me inscreva para receber notificações
  //quando algo acontecer
  getAllActivity(): Observable<Activity[]>{

    return this.http.get<Activity[]>(this.baseApiUrl + '/Activity/all'); 
    //ultimo parametro é a url da API
  }

  //criar metodo POST
  postActivity(addActivityRequest: addActivityRequest): Observable<Activity> {

    return this.http.post<Activity>(this.baseApiUrl + '/Activity', addActivityRequest);
    // parametro padrao para post é a url da API e o objeto que quero enviar

  }

  //criar metodo GET com parametro
  getActivity(id:string): Observable<Activity> {

    return this.http.get<Activity>(this.baseApiUrl + '/Activity/'+ id);

  }
  
  //criar metodo PUT, com parametro e objeto modelo
  putActivity(id: number, putActivityRequest: putActivityRequest): Observable<Activity>{
    
    return this.http.put<Activity>(this.baseApiUrl + '/Activity/' + id, putActivityRequest)
    // parametro padrao para put é a url da API e o objeto que quero enviar
    // o id é o id do objeto que quero alterar
    // o putActivityRequest é o objeto que quero enviar para alterar o objeto
    
    //o id é obtedio por meio do parametro da função e tratado pelo HTTPClient
  }

  //criar metodo DELETE
  deleteActivity(id: string): Observable<Activity> {
    return this.http.delete<Activity>(this.baseApiUrl + '/Activity/'+ id);
  }


}
