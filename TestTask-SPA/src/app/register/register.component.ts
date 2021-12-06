import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from '../_services/shared.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any ={};
  constructor(private sharedService: SharedService, private router: Router) { }

  ngOnInit() {
  }

  register(){
    this.sharedService.register(this.model).subscribe(next =>{
      console.log('Registration successful');
      this.router.navigate(['/auth/login']);
    }, error => {
      console.log(error);
    });
  }
  back(){
    this.router.navigate(['/auth/login'])
  }

}
