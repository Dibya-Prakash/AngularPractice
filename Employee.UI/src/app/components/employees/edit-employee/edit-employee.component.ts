import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeesService } from '../../../services/employees.service';
import { Employee } from '../../../models/employee.model';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.css'
})
export class EditEmployeeComponent implements OnInit {

  employeeDetails:Employee={
    id: '',
    name: '',
    email: '',
    phone: 0,
    salary: 0,
    department: ''
  };
  constructor(private route:ActivatedRoute, private employeeService: EmployeesService, private router: Router) {
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id=params.get('id');

        if(id){
          //call api
            this.employeeService.getEmployee(id).subscribe({
              next: (response) =>{
                  this.employeeDetails=response;
              }
        })
        }
  }
})
}

updateEmployee(){
  this.employeeService.updateEmployee(this.employeeDetails.id,this.employeeDetails)
  .subscribe({
    next: (response)=>{
      this.router.navigate(['employees']);  
    },
    error:(err: any) =>{
      console.log(err);
    }
  });
}
}

