import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employeemodel'
import { ROOT_URL } from '../models/configmodel'
import { Observable } from 'rxjs';
@Injectable()
export class EmployeeDataService {
  employees: Observable<Employee[]>;
  newemployee: Employee;
  constructor(private http: HttpClient) {

  }

  getEmployee() {
    return this.http.get<Employee[]>(ROOT_URL + 'Employees');
  }
  AddEmployee(emp: Employee) {

    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      Fname: emp.firstname, Lname: emp.lastname, Email: emp.email, gender: emp.gender
    }
    console.log(ROOT_URL);

    return this.http.post<Employee>(ROOT_URL + '/Employees', body, { headers });

  }

  ///  
  EditEmployee(emp: Employee) {
    console.log(emp);
    const params = new HttpParams().set('ID', emp.employeeid);
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      Fname: emp.firstname, Lname: emp.lastname, Email: emp.email, ID: emp.employeeid
      , gender: emp.gender
    }
    return this.http.put<Employee>(ROOT_URL + 'Employees/' + emp.employeeid, body, { headers, params })

  }
  DeleteEmployee(emp: Employee) {
    const params = new HttpParams().set('ID', emp.employeeid);
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      Fname: emp.firstname, Lname: emp.lastname, Email: emp.email, ID: emp.employeeid
    }
    return this.http.delete<Employee>(ROOT_URL + '/Employees/' + emp.employeeid)

  }

} 
