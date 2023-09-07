
export interface putActivityRequest 
{   
    id: number;
    createdBy: number;
    updatedBy: number;
    name: string;
    description: string,
    startDate: Date;
    endDate: Date;
    totalHours: number,
    parentId: number | null,
    activityCategoryId: number,
    activityCategoryStateId: number,
}