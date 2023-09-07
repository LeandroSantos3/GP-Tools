import { ActivityComponent } from './components/activity/activity.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WorkerprofileComponent } from './components/WorkerProfile/workerprofile/workerprofile.component';
import { GanttComponent } from './components/gantt/gantt.module';
import { LoginComponent } from './components/login/login.component';
import { CategoryComponent } from './components/category/category.component';
import { CategoryStateComponent } from './components/category-state/category-state.component';
import { ActivityToWorkerProfileComponent } from './components/activity-to-worker-profile/activity-to-worker-profile.component';

const routes: Routes = [
  {
    path: 'workerprofile',
    children: [
      {
        path: '',
        component: WorkerprofileComponent,
      },
      {
        path: 'profile/:id',
        component: WorkerprofileComponent,
       // outlet: 'modal',
      },
    ]
  },
  {
    path: 'ActivityCategory',
    children: [
      {
        path: '',
        component: CategoryComponent,
      },
      {
        path: ':id', 
        component: CategoryComponent,
      },
    ]
  },
  {
    path: 'ActivityCategoryState',
    children: [
      {
        path: '',
        component: CategoryStateComponent,
      },
      {
        path: ':id', 
        component: CategoryStateComponent,
      },
      {
        path: 'all/:id', 
        component: CategoryStateComponent,
      },
      {
        path: 'del/:id', 
        component: CategoryStateComponent,
      },
      {
        path: 'ActivityCategoryStateByCategoryId/:id', 
        component: CategoryStateComponent,
      },
    ]
  },
  {
    path: 'ActivityWorkerProfile', //**FOCO */
    children: [
      {
        path: '',
        component: ActivityToWorkerProfileComponent,
      },
      {
        path: ':id', 
        component: ActivityToWorkerProfileComponent,
      },
      {
        path: 'allt/:id', 
        component: ActivityToWorkerProfileComponent,
      },
      {
        path: 'del/:id', 
        component: ActivityToWorkerProfileComponent,
      },
    ]
  },
  {
    path: '', //**FOCO */
    redirectTo: "login", pathMatch: 'full' 
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'Activity',    //**FOCO */
    children: [
      {
        path: '',
        component: ActivityComponent,
      },
      {
        path: ':id', 
        component: ActivityComponent,
      },
      {
        path: 'all/:id', 
        component: ActivityComponent,
      },
    ]
  },
  {
    path: 'gptools',
    component: GanttComponent
  },
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
