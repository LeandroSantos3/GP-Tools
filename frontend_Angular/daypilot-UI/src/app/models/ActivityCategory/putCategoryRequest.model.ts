import { putWorkerProfileRequest } from '../WorkerProfile/putWorkerProfileRequest.model';

export interface putCategoryRequest{
    
    id:number;
    name: string;
    createdBy: number;
    createdDate: Date;
    updateBy: number;
}
