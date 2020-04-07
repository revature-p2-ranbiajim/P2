import { Component } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  constructor(private formBuilder: FormBuilder, private httpClient: HttpClient) { }

  SERVER_URL = "http://service_2/api/user";
  uploadForm: FormGroup;  
  ngOnInit() {
    this.uploadForm = this.formBuilder.group({
      profile: ['']
    });
  }
  onFileSelect(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.uploadForm.get('profile').setValue(file);
    }
  }
  onSubmit() {
    const formData = new FormData();
    formData.append('file', this.uploadForm.get('profile').value);

    this.httpClient.post<any>(this.SERVER_URL, formData).subscribe(
      (res) => console.log(res),
      (err) => console.log(err)
    );
  }
}