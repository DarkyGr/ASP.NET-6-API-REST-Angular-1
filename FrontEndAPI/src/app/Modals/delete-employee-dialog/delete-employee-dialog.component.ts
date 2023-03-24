import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { Employee } from 'src/app/Interfaces/employee';

@Component({
  selector: 'app-delete-employee-dialog',
  templateUrl: './delete-employee-dialog.component.html',
  styleUrls: ['./delete-employee-dialog.component.css']
})
export class DeleteEmployeeDialogComponent implements OnInit {

  constructor(
    private referencesDialog:MatDialogRef<DeleteEmployeeDialogComponent>,
    @Inject (MAT_DIALOG_DATA) public employeeData:Employee    // Save information
  ){

  }

  ngOnInit(): void {}

  deleteConfirmed(){
    if (this.employeeData) {
      this.referencesDialog.close("deleted")
    }
  }
}
