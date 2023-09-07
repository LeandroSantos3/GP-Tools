import { Category } from 'src/app/models/ActivityCategory/Category.model';

export interface Activity {
    id: number;
    createdBy: number;
    createdDate: Date;
    updatedBy: number;
    updateDate: Date;
    name: string;
    description: string,
    startDate: Date;
    endDate: Date;
    totalHours: number;
    parentId: number;
    parent: number;
    isActive: boolean;
    activityCategoryId: number;
    activityCategoryStateId: number;
    children?: Activity[];
}
