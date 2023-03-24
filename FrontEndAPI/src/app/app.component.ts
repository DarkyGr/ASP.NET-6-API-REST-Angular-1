import {AfterViewInit, Component, ViewChild, OnInit} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';

import { Employee } from './Interfaces/employee';
import { EmployeeService } from './Services/employee.service';

import {MatDialog} from '@angular/material/dialog';

import { NewEmployeeDialogComponent } from './Modals/new-employee-dialog/new-employee-dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements AfterViewInit, OnInit {
  title = 'Front-End API';

  displayedColumns: string[] = ['Name', 'Department', 'Salary', 'ContractDate', 'Accions'];
  dataSource = new MatTableDataSource<Employee>();

  constructor(
    private _employeeServices: EmployeeService,
    public dialog: MatDialog){}

  ngOnInit(): void {
    this.showEmployees();
  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }  

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  showEmployees(){
    this._employeeServices.getList().subscribe({
      next:(dataResponse)=>{
        // console.log(dataResponse)
        this.dataSource.data = dataResponse;
      }, error:(e)=>{}
    })
  }

  newEmployeeDialog() {    
    this.dialog.open(NewEmployeeDialogComponent,{
      disableClose:true,
      width:"350px"
    }).afterClosed().subscribe(result => {
      if (result === "created") {
        this.showEmployees();
      }
    });    
  }

  editEmployeeDialog(employeeData: Employee) {
    console.log(employeeData)
    this.dialog.open(NewEmployeeDialogComponent,{
      disableClose:true,
      width:"350px",
      data: employeeData
    }).afterClosed().subscribe(result => {
      if (result === "edited") {
        this.showEmployees();
      }
    });    
  }
}