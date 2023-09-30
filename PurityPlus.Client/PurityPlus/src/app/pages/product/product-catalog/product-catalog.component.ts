import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductDTO } from 'src/app/models/dto';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-catalog',
  templateUrl: './product-catalog.component.html',
  styleUrls: ['./product-catalog.component.scss']
})
export class ProductCatalogComponent implements OnInit {
  cosmeticProducts: any = [];
  /**
   *
   */
  constructor(private productService: ProductService, private routerService: Router) {

  }

  ngOnInit(): void {
    this.productService.getAllProducts().then((result) => {
      this.cosmeticProducts = result.data.data;
      console.table(result.data.data);
    })
  }

  OnProductClick($event: ProductDTO) {
    this.routerService.navigate(['/products/product-detail',$event.productId]);
  }

}


