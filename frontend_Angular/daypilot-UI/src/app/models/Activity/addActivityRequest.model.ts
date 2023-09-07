
export interface addActivityRequest 
{   
    createdBy: number;
    name: string;
    description: string,
    startDate: Date;
    endDate: Date;
    totalHours: number,
    parentId: number | null,
    parent: number | null,
    activityCategoryId: number,
    activityCategoryStateId: number,
}