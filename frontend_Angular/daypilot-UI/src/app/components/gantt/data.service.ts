

import {Injectable} from "@angular/core";
import {NotFoundError, Observable, of} from "rxjs";
import {DayPilot} from "daypilot-pro-angular";
import {HttpClient} from "@angular/common/http";
import { Activity } from "src/app/models/Activity/Activity.model";
import { ActivityService } from "src/app/services/activity.service";
import { environment } from "src/environments/environment";

import { ActivityChild } from 'src/app/models/Activity/ActivityChild.model'; // Replace with the correct file path
import { MoveRowParams } from "./MoveRowParams.model";


@Injectable()
export class DataService {

  // URL base da API
  baseApiUrl: string =  environment.baseApiUrl;

  // instanciando a class
  tasks: Activity[] = []; 

  firstOfMonth(): DayPilot.Date {
    return DayPilot.Date.today().firstDayOfMonth();
  }

  constructor(private http : HttpClient){
  }

 getTasks(): Observable<Activity[]> {   

  return this.http.get<Activity[]>(this.baseApiUrl + '/Activity/all');
  
  }

  getChild(id:string): Observable<Activity[]> {
    
    return this.http.get<Activity[]>(this.baseApiUrl + '/child/' + id);  
  }


  //  moveRow(params: MoveRowParams): Observable<any> {
  //   console.log("1"+params.id);
  //   console.log("2"+params.previousId);
  //   console.log("3"+params.nextId);
  //   console.log("4"+params.parentId);
  //    return this.http.put<Activity>(this.baseApiUrl + '/Activity/row/' + params.id, params);
  //  }

  moveRow(params: MoveRowParams): Observable<any> {
    const { id, parentId, previousId, nextId } = params;
    const payload = { id, parentId, previousId, nextId };
    return this.http.put<Activity>(`${this.baseApiUrl}/Activity/row/${id}`, payload);
  }
  
  // moveTask(params: MoveRowParams): Observable<any> {
  //   const { id, parentId, previousId, nextId } = params;
  //   const payload = { id, parentId, previousId, nextId };
  //   return this.http.put<Activity>(`${this.baseApiUrl}/Activity/row/${id}`, payload);
  // }
  





}

