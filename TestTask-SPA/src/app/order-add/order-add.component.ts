import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from '../_models/Order';
import { SharedService } from '../_services/shared.service';

@Component({
  selector: 'app-order-add',
  templateUrl: './order-add.component.html',
  styleUrls: ['./order-add.component.css']
})
export class OrderAddComponent implements OnInit {
  model: any = {};
  req: any = {};
  constructor(private router: Router, private sharedService: SharedService) { }

  ngOnInit() {
  }

  back() {
    this.router.navigate(['/orders']);
  }

  addOrder() {
      this.sharedService.addOrder(this.model).subscribe((data:any) => {
        this.req = data; 
        this.router.navigate(['/orders']);   
      }, error => {
        console.log(error);
      });
  }

}
