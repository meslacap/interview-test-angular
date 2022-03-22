import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
})
export class AddStudentComponent {
  baseApi: string;
  student: Student = 
    {
      studentID: 0,
      firstName: '',
      lastName: '',
      email: '',
      major: '',
      average: 0
    };

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseApi = baseUrl;
  }

  addStudent(): void {
    const body =
    {
      studentID: this.student.studentID,
      firstName: this.student.firstName,
      lastName: this.student.lastName,
      email: this.student.email,
      major: this.student.major,
      average: this.student.average
    }
    this.http.post<Student>(this.baseApi + 'add', body).subscribe(s => {
      console.log(s);
      this.router.navigate(['/']);
    });
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
