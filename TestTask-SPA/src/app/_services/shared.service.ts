import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../_models/Order';

@Injectable()
export class SharedService {
readonly APIUrl = 'http://localhost:5000/api/'
constructor(private http: HttpClient) { }

getOrders():Observable<Order[]>{
    return this.http.get<Order[]>(this.APIUrl+'orders');
}
getOrder(id:any):Observable<Order> {
    return this.http.get<Order>(this.APIUrl + 'orders' +id);
}
addOrder(val:Order) {
    return this.http.post(this.APIUrl+'orders/add', val);
}

editOrder(id:any, val:Order) {
    return this.http.put(this.APIUrl+'orders/'+ id +'/edit', val);
}

deleteOrder(id:number){
    return this.http.delete<Order>(this.APIUrl + 'orders/' + id);
}

register(val: any){
    return this.http.post(this.APIUrl +'auth/register', val);
}

login(val: any){
    return this.http.post(this.APIUrl + "auth/login", val);
}
}
