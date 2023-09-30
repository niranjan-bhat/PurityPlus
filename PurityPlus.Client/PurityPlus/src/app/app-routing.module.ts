import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { ProductCatalogComponent } from './pages/product/product-catalog/product-catalog.component';
import { ProductModule } from './pages/product/product.module';

const routes: Routes = [
  { path: "", redirectTo: "shop", pathMatch: "full" },
  { path: "shop", component: HomeComponent },
  { path: "products", loadChildren: () => import('./pages/product/product.module').then(m => m.ProductModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
