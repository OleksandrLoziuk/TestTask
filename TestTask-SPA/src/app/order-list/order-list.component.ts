import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Order } from '../_models/Order';
import { SharedService } from '../_services/shared.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {
  ordersList: any = [];
  constructor(private sharedService: SharedService, private router: Router) { }

  ngOnInit() {
    this.loadOrders();
  }

  OrderIdFilter: string="";
  OrderNameFilter: string = "";
  OrderListWithoutFilter: any = [];

  loadOrders() {
    this.sharedService.getOrders().subscribe((orders: Order[])=>{
      this.ordersList = orders;
      this.OrderListWithoutFilter = orders;
    }, (error: any) => {
      console.log(error);
    });
  }

  deleteOrder(ord: Order) {
    this.sharedService.deleteOrder(ord.id).subscribe(() => {
      this.ordersList.splice(this.ordersList.findIndex((c: { id: number; }) => c.id === ord.id), 1);
    }, error => {
      console.log(error);
    });
  }

  FilterFn(){
    var OrderIdFilter = this.OrderIdFilter;
    var OrderNameFilter = this.OrderNameFilter;

    this.ordersList = this.OrderListWithoutFilter.filter(function(el: any){
      return el.id.toString().toLowerCase().includes(
        OrderIdFilter.toString().trim().toLowerCase()
      )&&
      el.name.toString().toLowerCase().includes(
        OrderNameFilter.toString().trim().toLowerCase()
      )
    })
  }

  sortResult(prop: any, asc: any){
      this.ordersList = this.OrderListWithoutFilter.sort(function(a: any,b: any){
        if(asc){
          return(a[prop]>b[prop])?1 : ((a[prop]<b[prop])? -1 :0);
        }else{
          return(b[prop]>a[prop])?1 : ((b[prop]<a[prop])? -1 :0);
        }
      })
  }

  logout(){ 
    localStorage.removeItem('token');
    this.router.navigate(['/auth/login']);  
  }
}
