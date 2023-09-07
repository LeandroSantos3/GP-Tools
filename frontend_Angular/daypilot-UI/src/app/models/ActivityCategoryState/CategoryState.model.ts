
export interface CategoryState {
   
    id: number;
    name: string;
    isLocked: boolean;
    createdBy: number;
    createdDate: Date;
    updateBy: number;
    updatedDate: Date;
    activityCategoryId: number | null;
}