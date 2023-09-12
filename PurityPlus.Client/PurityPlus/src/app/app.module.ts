import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MegaMenuModule } from 'primeng/megamenu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';
import { BadgeModule } from 'primeng/badge';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { HomeComponent } from './pages/home/home.component';
import { HeroComponent } from './components/hero/hero.component';
import { ButtonComponent } from './components/button/button.component';
import { BeautyEssentialsComponent } from './components/beauty-essentials/beauty-essentials.component';
import { ProductCatalogComponent } from './pages/product-catalog/product-catalog.component';
import { ProductCardComponent } from './components/product-card/product-card.component'; 
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    HeroComponent,
    ButtonComponent,
    BeautyEssentialsComponent,
    ProductCatalogComponent,
    ProductCardComponent
  ],
  imports: [
    BrowserModule, 
    BrowserAnimationsModule, 
    MegaMenuModule,
    AppRoutingModule,
    BadgeModule,
    OverlayPanelModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
