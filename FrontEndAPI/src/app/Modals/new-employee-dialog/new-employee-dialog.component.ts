import { Component, OnInit, Inject } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { MatSnackBar } from '@angular/material/snack-bar';

import { MAT_DATE_FORMATS } from '@angular/material/core';
import * as moment from 'moment';

import { Department } from 'src/app/Interfaces/department';
import { DepartmentService } from 'src/app/Services/department.service';
import { Employee } from 'src/app/Interfaces/employee';
import { EmployeeService } from 'src/app/Services/employee.service';

export const MY_DATE_FORMATS={
  parse:{
    dateInpunt: 'DD/MM/YYYY',
  },
  display:{
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY'
  }
}

@Component({
  selector: 'app-new-employee-dialog',
  templateUrl: './new-employee-dialog.component.html',
  styleUrls: ['./new-employee-dialog.component.css'],
  providers: [{
    provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS
  }]
})
export class NewEmployeeDialogComponent implements OnInit {

  employeeForm: FormGroup;
  actionTitle: string = "New";
  actionBtn: string = "Save";
  departmentList: Department[] = [];

  constructor(
    private referencesDialog:MatDialogRef<NewEmployeeDialogComponent>,
    private fb:FormBuilder,
    private _snackBar: MatSnackBar,
    private _departmentService: DepartmentService,
    private _employeeService: EmployeeService,
    @Inject (MAT_DIALOG_DATA) public employeeData:Employee    // Save information
  ){
    this.employeeForm = this.fb.group({
      employeeName: ['', Validators.required],
      departmentId: ['', Validators.required],
      salary: ['', Validators.required],
      contractDate: ['', Validators.required],
    })

    this._departmentService.getList().subscribe({
      next:(data)=>{
        this.departmentList = data;
      },error:(e)=>{}
    })
  }

  showAlert(msg: string, action: string) {
    this._snackBar.open(msg, action,{
      horizontalPosition: "end",
      verticalPosition: "top",
      duration: 3000
    });
  }

  newEmployee(){    
    // console.log(this.employeeForm.value)

    const model: Employee = {
      employeeId: 0,
      employeeName: this.employeeForm.value.employeeName,
      departmentId: this.employeeForm.value.departmentId,
      salary: this.employeeForm.value.salary,
      contractDate: moment(this.employeeForm.value.contractDate).format("DD/MM/YYYY")
    }

    if (this.employeeData == null) {    // If CREATED
      this._employeeService.addEmployee(model).subscribe({
        next:(data)=>{
          this.showAlert("Employee was created successfully", "Ready");
          this.referencesDialog.close("created");
        },error:(e)=>{
          this.showAlert("Employee could not be created", "Error");
        }
      })  
    }else{    // If EDITED
      this._employeeService.updateEmployee(this.employeeData.employeeId, model).subscribe({        
        next:(data)=>{          
          this.showAlert("Employee was edited successfully", "Ready");
          this.referencesDialog.close("edited");
        },error:(e)=>{          
          this.showAlert("Employee could not be edited", "Error");
        }
      })  
    }    
  }

  ngOnInit(): void {
    if (this.employeeData) {
      this.employeeForm.patchValue({
        employeeName: this.employeeData.employeeName,
        departmentId:this.employeeData.departmentId,
        salary: this.employeeData.salary,
        contractDate: moment(this.employeeData.contractDate, 'DD/MM/YYYY')
      })

      this.actionTitle = "Edit"
      this.actionBtn = "Update"
    }    
  }
}
