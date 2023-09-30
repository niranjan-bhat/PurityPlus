import { Component, OnInit } from '@angular/core';
import { CartItem, CartService } from 'src/app/services/cart.service';

interface shippingMethod{
  name:string,
  charge:number
}

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  cartItems: CartItem[];
  cartValue:number;
  shippingOptions :  shippingMethod[] = [{name:"Standard Shipping",charge:50},{name:"Express Shipping",charge:100},]
  selectedShippingOption:any;
  constructor(private cartService: CartService) {

  }
  ngOnInit(): void {
    this.cartService.getCartItems().subscribe((data) => {
      this.cartItems = data;
    });

    this.cartValue = this.getCartValue();
  }

  getProductPrice(item:CartItem){

    return item.product.discountedPrice ?? item.product.price;
  }
  getTotalProductPrice(item:CartItem){
    return (item.product.discountedPrice ?? item.product.price)*item.quantity;
  }

  getCartValue(){
   return this.cartService.getTotalCartValue();
  }

  getGrandTotal(){
    if (typeof this.selectedShippingOption === 'undefined') {
      return this.cartValue + 0;
    } else {
      return this.cartValue + this.selectedShippingOption.charge;
    }
  }
}
