import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee, EmployeeData } from '../models/employeemodel'
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

  getEmployeeById(employeeid: string) {
    const params = new HttpParams().set('ID', employeeid);
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      ID: employeeid
    }
    return this.http.get<Employee>(ROOT_URL + '/Employees/' + employeeid)

  }

  addEmployee(emp: Employee) {

    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      FirstName: emp.firstName,
      LastName: emp.lastName,
      "EmployeeData": { Gender: emp.employeeData.gender, Email: emp.employeeData.email, Phone: emp.employeeData.phone }
    }
    console.log(ROOT_URL);

    return this.http.post<Employee>(ROOT_URL + '/Employees', body, { headers });

  }

  editEmployee(emp: Employee) {
    console.log(emp);
    const params = new HttpParams().set('ID', emp.employeeId);
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      FirstName: emp.firstName,
      LastName: emp.lastName,
      EmployeeId: emp.employeeId,
      "EmployeeData": { Gender: emp.employeeData.gender, Email: emp.employeeData.email, Phone: emp.employeeData.phone }
    }
    return this.http.put<Employee>(ROOT_URL + 'Employees/' + emp.employeeId, body, { headers, params })

  }

  deleteEmployee(emp: Employee) {
    const params = new HttpParams().set('ID', emp.employeeId);
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      FirstName: emp.firstName, LastName: emp.lastName//,
      //Email: emp.email, ID: emp.employeeId
    }
    return this.http.delete<Employee>(ROOT_URL + '/Employees/' + emp.employeeId)

  }

} 
