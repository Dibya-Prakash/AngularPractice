import { Component, OnInit } from '@angular/core';
import { Employee } from '../../../models/employee.model';
import { EmployeesService } from '../../../services/employees.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent implements OnInit {
  
  employees: Employee[]=[];
  constructor(private employeesService: EmployeesService){ }


  ngOnInit(): void {
this.employeesService.getAllEmployees()
.subscribe({
next:(employees: any)=>{this.employees=employees;
},
error: (response: any) =>{
  console.log(response);
}
})
  }
}
