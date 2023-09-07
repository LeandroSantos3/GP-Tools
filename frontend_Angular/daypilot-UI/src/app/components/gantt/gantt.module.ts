
import {DataService} from "./data.service";
import {FormsModule} from "@angular/forms";
import {BrowserModule} from "@angular/platform-browser";
import {NgModule} from "@angular/core";
import {GanttComponent} from "./gantt.component";
import {DayPilotModule} from "daypilot-pro-angular";
import {HttpClientModule} from "@angular/common/http";
import { AdminNavbarComponent } from "../../components/admin-navbar/admin-navbar.component";
import { DevNavbarComponent } from "../../components/dev-navbar/dev-navbar.component";

@NgModule({
  imports:      [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    DayPilotModule,
  ],
  declarations: [
    GanttComponent, // <-- declarado o componente aqui para ser importado no outro modulo
    
  ],
  exports:      [ GanttComponent],
  providers:    [ DataService ]
})
export class GanttModule { }
export { GanttComponent };

