import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-name-editor',
  templateUrl: './name-editor.component.html',
  styleUrls: ['./name-editor.component.css']
})
export class NameEditorComponent {
  
  FirstName=  new FormControl('');
  LastName= new FormControl('');
  Username= new FormControl('');
  Password= new FormControl('');
  Email= new FormControl('');
  

  json;
  constructor(private http: HttpClient) {
    // this.http.post("http://service_2/api/users", this.User).toPromise().then(data => { console.log(data)});
  }

  createAccount() {
    //post
    let User = {
      FirstName: this.FirstName,
      LastName: this.LastName,
      Username: this.Username,
      Password: this.Password,
      Email: this.Email
    }
    this.http.post("http://service_2/api/users", User).toPromise().then((data:any) => { 
      console.log(data);
      this.json = data.json;
    });
  }
}
