import { Component, OnInit } from '@angular/core';
import { Employee } from '../../../models/employee.model';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeesService } from '../../../services/employees.service';

@Component({
  selector: 'app-delete-employee',
  templateUrl: './delete-employee.component.html',
  styleUrl: './delete-employee.component.css'
})
export class DeleteEmployeeComponent implements OnInit {
  
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

DeleteEmployee(){
  this.employeeService.DeleteEmployee(this.employeeDetails.id)
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
