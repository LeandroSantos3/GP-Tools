import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ActivityToWorkerProfile } from '../models/ActivityWorkerProfile/ActivityToWorker.model';
import { ActivityToWorkerProfileRequest } from '../models/ActivityWorkerProfile/ActivityToWorkerProfileRequest.model';
import { putActivityToWorkerProfileRequest } from '../models/ActivityWorkerProfile/putActivityToWorkerProfileRequest.model';

@Injectable({
  providedIn: 'root'
})
export class ActivityWorkerProfileService {

  
  baseApiUrl: string = environment.baseApiUrl;
  
  constructor(private http: HttpClient) { }

  //criar metodo GET
  getAllActivityWorkerProfile(): Observable<ActivityToWorkerProfile[]>{

    return this.http.get<ActivityToWorkerProfile[]>(this.baseApiUrl + '/ActivityWorkerProfile');
  }

  //criar metodo POST
  postActivityWorkerProfile(activityWorkerProfileRequest: ActivityToWorkerProfileRequest): 
    Observable<ActivityToWorkerProfile>{
      
      return this.http.post<ActivityToWorkerProfile>(this.baseApiUrl + '/ActivityWorkerProfile', activityWorkerProfileRequest);
  }

  //criar metodo GET com parametro
  getActivityWorkerProfile(id:string): Observable<ActivityToWorkerProfile> {

    return this.http.get<ActivityToWorkerProfile>(this.baseApiUrl + '/ActivityWorkerProfile/'+ id);

  }
  
  //criar metodo PUT, com parametro e objeto modelo
  putActivityWorkerProfile(id: number, putActivityRequest: putActivityToWorkerProfileRequest): 
    Observable<ActivityToWorkerProfile>{
    
    return this.http.put<ActivityToWorkerProfile>(this.baseApiUrl + '/ActivityWorkerProfile/allt/' + id, putActivityRequest)    
  }

  //criar metodo DELETE
  deleteActivityWorkerProfile(id: string): Observable<ActivityToWorkerProfile> {
    return this.http.delete<ActivityToWorkerProfile>(this.baseApiUrl + '/ActivityWorkerProfile/del/'+ id);
  }

}
