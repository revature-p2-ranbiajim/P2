import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-name-editor',
  templateUrl: './name-editor.component.html',
  styleUrls: ['./name-editor.component.css']
})
export class NameEditorComponent {
  FirstName = new FormControl('');
  LastName = new FormControl('');
  Username = new FormControl('');
  Password = new FormControl('');
  Email = new FormControl('');
  name = new FormControl('');

  createAccount() {
    // this.FirstName.setValue('fn');
    // this.LastName.setValue('ln');
    // this.Username.setValue('un');
    // this.Password.setValue('pw');
    // this.Email.setValue('em');
    // this.name.setValue('Nancy');
    //post
  }
}
