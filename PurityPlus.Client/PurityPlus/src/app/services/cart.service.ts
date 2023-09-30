import { Injectable } from '@angular/core';
import { ProductDTO } from '../models/dto';
import { BehaviorSubject, Observable } from 'rxjs';

export interface CartItem {
  product: ProductDTO,
  quantity: number
}

@Injectable({
  providedIn: 'root'
})
export class CartService {

  cart: CartItem[] = [];
  public cartSubject = new BehaviorSubject<CartItem[]>(this.cart);
  constructor() { }

  addToCart(product: ProductDTO, quantity: number) {
    const existingItem = this.cart.find((item) => item.product.productId === product.productId);

    if (existingItem) {
      existingItem.quantity += quantity;
    } else {
      this.cart.push({ product, quantity });
    }

    // Notify subscribers that the cart has been changed
    this.cartSubject.next([...this.cart]);
  }

  removeFromCart(product: ProductDTO,) {
    this.cart = this.cart.filter(item => item.product.productId != product.productId);
    this.cartSubject.next([...this.cart]);
  }

  getCartItems(): Observable<CartItem[]> {
    return this.cartSubject.asObservable();
  }
  clearCart() {
    this.cart = [];
    this.cartSubject.next([...this.cart]);
  }
  getTotalCartValue(){
    return this.cart.reduce((total, item) => total + (item.product.discountedPrice??item.product.price) * item.quantity, 0);
  }
}
