
export interface putCategoryState {
   
    id: number;
    name: string;
    isLocked: boolean;
    createdBy: number;
    createdDate: Date;
    updateBy: number;
    activityCategoryId: number | null;
}