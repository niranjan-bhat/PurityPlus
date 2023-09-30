import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductDTO } from 'src/app/models/dto';
import { CartService } from 'src/app/services/cart.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  constructor(private route: ActivatedRoute, private productService: ProductService, private cartService: CartService) { }
  product: ProductDTO;

  productId: string;
  rating!: number;
  requiredQuantity: number = 1;
  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      // Get the 'Id' from the route parameter
      this.productId = params.get('Id'); // '+' is used to convert the string to a number
      // Now 'productId' contains the Id passed in the route

    });

    this.productService.getProductById(this.productId).then((result) => {
      this.product = (result.data);
    }).catch().finally();
  }

  getActualPrice(): number {
    return this.product.discountedPrice ?? this.product.price;
  }

  OnAddToCartClick() {
    this.cartService.addToCart(this.product, this.requiredQuantity);
  }
  OnBuyNowClick() { }
}
