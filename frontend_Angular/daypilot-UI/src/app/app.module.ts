import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { WorkerprofileComponent } from './components/WorkerProfile/workerprofile/workerprofile.component';

import { ActivityComponent } from './components/activity/activity.component';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GanttModule } from './components/gantt/gantt.module';
import { AdminNavbarComponent } from './components/admin-navbar/admin-navbar.component';
import { DevNavbarComponent } from './components/dev-navbar/dev-navbar.component';
import { CategoryComponent } from './components/category/category.component';
import { CategoryStateComponent } from './components/category-state/category-state.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ActivityToWorkerProfileComponent } from './components/activity-to-worker-profile/activity-to-worker-profile.component';
import { MatDialogModule } from '@angular/material/dialog';





@NgModule({
  declarations: [
    AppComponent,
    WorkerprofileComponent,
    ActivityComponent,
    LoginComponent,
    AdminNavbarComponent,
    DevNavbarComponent,
    CategoryComponent,
    CategoryStateComponent,
    ActivityToWorkerProfileComponent, 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    GanttModule, // <-- importado o modulo aqui    
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-top-right',
      progressBar: true,
    }),
    MatDialogModule,
    FormsModule,
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
