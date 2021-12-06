import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../_models/User';
import { SharedService } from '../_services/shared.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(private sharedService: SharedService, private router: Router) { }

  ngOnInit() {
  }

  login(){
    this.sharedService.login(this.model).subscribe(next => {
      console.log('Login successful');
      this.router.navigate(['/orders']);
    }, error => {
      console.log(error);
    });
  }
  goToRegister(){
    this.router.navigate(['/auth/register']);
  }

}
