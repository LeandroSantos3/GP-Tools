
export interface ActivityChild {
    
    id: number;
    name: string;
    startDate: Date;
    endDate: Date;
    parentId?: number;
    children?: ActivityChild[];
}