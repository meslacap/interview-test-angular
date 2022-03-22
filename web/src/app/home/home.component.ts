import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { stringify } from 'querystring';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public students: Student[];
  baseApi: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseApi = baseUrl;
    http.get<Student[]>(baseUrl + 'students').subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }

  deleteStudent(student: Student): void {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        studentID: student.studentID,
        firstName: student.firstName,
        lastName: student.lastName,
        email: student.email,
        major: student.major,
        average: student.average
      }
    };
    this.http.delete(this.baseApi + 'delete', options).subscribe(s => {
      console.log(s);
    });

    this.students = this.students.filter(s => s.studentID !== student.studentID);
  };
}

interface Student {
  studentID: number;
  firstName: string;
  lastName: string;
  email: string;
  major: string;
  average: number;
}
