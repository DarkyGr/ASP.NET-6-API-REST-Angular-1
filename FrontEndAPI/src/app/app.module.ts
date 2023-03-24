import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';

// Angular Components
import {MatButtonModule} from '@angular/material/button';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatNativeDateModule} from '@angular/material/core';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {MatSelectModule} from '@angular/material/select';
import {MomentDateModule} from '@angular/material-moment-adapter';

// For Alerts of material
import {MatSnackBarModule} from '@angular/material/snack-bar';

// For Icons of material
import {MatIconModule} from '@angular/material/icon';

// Modals
import {MatDialogModule} from '@angular/material/dialog';

// Grids
import {MatGridListModule} from '@angular/material/grid-list';
import { NewEmployeeDialogComponent } from './Modals/new-employee-dialog/new-employee-dialog.component';
import { DeleteEmployeeDialogComponent } from './Modals/delete-employee-dialog/delete-employee-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NewEmployeeDialogComponent,
    DeleteEmployeeDialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatButtonModule,
    MatPaginatorModule,
    MatTableModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    MomentDateModule,
    MatSnackBarModule,
    MatIconModule,
    MatDialogModule,
    MatGridListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
