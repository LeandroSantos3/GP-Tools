import { putWorkerProfileRequest } from '../models/WorkerProfile/putWorkerProfileRequest.model';
import { addWorkerProfileRequest } from 'src/app/models/WorkerProfile/addWorkerProfileRequest.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Workerprofile } from '../models/WorkerProfile/workerprofile.model';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class WorkerprofileService {

  //URL base da API
  baseApiUrl: string = environment.baseApiUrl;

  //tenho que injetar um client HTTP para me comunicar com a API
  constructor(private http: HttpClient) { }

  getAllWorkerProfiles(): Observable<Workerprofile[]> {

    return this.http.get<Workerprofile[]>(this.baseApiUrl + '/asAdmin');

  }

  postWorkerProfile(addWorkerProfileRequest: addWorkerProfileRequest): Observable<Workerprofile> {

    return this.http.post<Workerprofile>(this.baseApiUrl + '/WorkerProfile', addWorkerProfileRequest);

  }
  
  getWorkerProfile(id:string): Observable<Workerprofile> {

    return this.http.get<Workerprofile>(this.baseApiUrl + '/'+ id);

  }
  
  putWorkerProfile(id: number, putWorkerProfileRequest:putWorkerProfileRequest): Observable<Workerprofile>{
    
    return this.http.put<Workerprofile>(this.baseApiUrl + '/profile/' + id, putWorkerProfileRequest)    
  }

  deleteWorkerProfile(id: string, workerProfile: Workerprofile): Observable<Workerprofile> {
    return this.http.put<Workerprofile>(this.baseApiUrl + '/Activate/' + id, workerProfile);
  }
  

}
