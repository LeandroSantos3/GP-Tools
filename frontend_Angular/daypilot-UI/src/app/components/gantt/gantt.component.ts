
import { Activity } from 'src/app/models/Activity/Activity.model';
import {Component, ViewChild, AfterViewInit} from "@angular/core";
import {DayPilot, DayPilotGanttComponent} from "daypilot-pro-angular";
import {DataService} from "./data.service";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'gantt-component',
  template: `<daypilot-gantt [config]="config"  #gantt></daypilot-gantt>`,
  styles: [``]
})

export class GanttComponent implements AfterViewInit {

  uniqueTaskIds: Set<number> = new Set<number>();

  // variavel para detectar o tipo de user
  userType: string | null; 

  //instancia da classe Activity
  tarefas: Activity[] = [];
 
  @ViewChild("gantt")

  gantt!: DayPilotGanttComponent;

  config: any = 
  {
    cellWidthSpec: "Fixed",
    cellWidth: 200,
    timeHeaders: [{"groupBy":"Month"},{"groupBy":"Month","format":"d"}], //same ideia
    scale: "Month", //Day ; Month
    days: DayPilot.Date.today().daysInYear(), //inYear ; inMonth
    startDate: DayPilot.Date.today().firstDayOfMonth(),
    taskHeight: 40,
    treeEnable: true,
    rowHeaderHideIconEnabled: false, 
    rowHeaderHideIconWidth: 100,  
    
        
    onRowMoved: (args: any) => {
      let sourceId = args.source.id();
      let targetId = args.target.id();
      let position = args.position;
  
    console.log("Moved row with ID:", sourceId);
    console.log("Moved row to ID:", targetId);
    console.log("Moved row to position:", position);

    let params = {
      id: sourceId,
      parentId: targetId, 
      previousId: sourceId, 
      nextId: targetId,
    };

    console.log("parentid"+ params.parentId);
    console.log("previousid"+ params.previousId);
    console.log("nextid"+ params.nextId);
    console.log("Moved row with ID:", sourceId);
    console.log("Moved row to ID:", targetId);

    
    this.ds.moveRow(params).subscribe(
      (result: any) => {
        console.log("Move result:", result);
        this.gantt.control.message("Moved.");
        // Após o movimento ser concluído com sucesso no backend,
        // atualize os dados no Gantt conforme necessário
      },
      (error: any) => {
        console.error("Move error:", error);
        // Lidar com erros caso ocorra algum problema durante a movimentação
      }
    );
  },  

  // onTaskResized: (args:any) => {
  //   let params : MoveTaskParams = {
  //     id: args.task.id(),
  //     start: args.newStart.toString(),
  //     end: args.newEnd.toString()
  //   };
  //   this.ds.moveTask(params).subscribe(result => this.gantt.control.message("Resized."));
  // },
};

  constructor(private ds: DataService, private route: ActivatedRoute, private router: Router) {    
    // Recuperando o tipo de usuário do localStorage
    this.userType = localStorage.getItem('userType');    
  }

  
  ngAfterViewInit(): void {  
   
    this.ds.getTasks().subscribe(result => {
      const uniqueTaskIds = new Set<number>(); // Conjunto para armazenar os IDs exclusivos
     
      //começar a mapear as tarefas e os filhos
      //mapeamento este que será apresentado no gantt
      const mappedTasks = result.map(data => {
        const taskId = data.id; // Obter um ID exclusivo para a tarefa
  
        const children = result.filter(child => child.parentId === data.id).map(child => ({
          id: child.id, // Obter um ID exclusivo para o filho da tarefa
          text: child.name,
          start: new DayPilot.Date(child.startDate),
          end: new DayPilot.Date(child.endDate),
          // ...mapeie outras propriedades necessárias para as tarefas filhas
          // como o percentual de conclusão
         percentComplete: 50
        }));
  
        return {
          id: taskId, // Usar o ID exclusivo da tarefa
          text: data.name,
          start: new DayPilot.Date(data.startDate),
          end: new DayPilot.Date(data.endDate),
          parentId: data.parentId ? data.parentId: null, // Usar o ID exclusivo do pai, se existir
          children: children.length > 0 ? children : null,

          //barColor: this.getTaskColor(data) 
        };
      }).filter(task => !task.parentId); // Remover as tarefas filhas do array principal
  
      // Atribuir os dados mapeados a config.tasks
      this.config.tasks = mappedTasks;
  
      console.log(mappedTasks);
    });
  }
 
  getChild(){

    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        
        if (id) 
        {
          this.ds.getChild(id).subscribe({
            next: (response) => {             
              this.tarefas = response;
            }
          });
        }
      }
    });
  }
}


