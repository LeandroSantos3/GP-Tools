

export interface ActivityToWorkerProfile {

    id: number;
    activityId: number;
    workerProfileId: number;
    createdBy: number;
    createdDate: Date;
    totalHours: number;
    updateBy: number;
    updatedDate: Date;
    isAssociated: boolean;
}