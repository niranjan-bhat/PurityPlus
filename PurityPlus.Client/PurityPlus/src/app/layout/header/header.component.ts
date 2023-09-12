import { Component, OnInit } from '@angular/core';
import { MegaMenuItem } from 'primeng/api';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  items: MegaMenuItem[] | undefined;

  ngOnInit() {
    this.items = [
      {
        label: 'Shop',
        items: [
          [
            {

              items: [{ label: 'Face Makeup' }, { label: 'Skincare' }, { label: 'Bodycare' }, { label: 'Tools $ Brushes' }]
            },
          ]
        ]
      },
      {
        label: 'Collections',
        items: [
          [
            {

              items: [{ label: 'Summer Vibes' }, { label: 'Holiday Glam' }, { label: 'Natural Beauty' }]
            },
          ]
        ]
      },
      {
        label: 'All Products',
        items: [
          [
            {
              label: 'Face Makeup',
              items: [{ label: 'Foundation' }, { label: 'Blush' }, { label: 'Concealer' }]
            },
            {
              label: 'Eye Makeup',
              items: [{ label: 'Eyeshadow' }, { label: 'Mascara' }, { label: 'Eyeliner' }]
            }
          ],
          [
            {
              label: 'Moisturizers',
              items: [{ label: 'Day Creams' }, { label: 'Night Creams' }, { label: 'Serum' }]
            },
            {
              label: 'Cleansers',
              items: [{ label: 'Facial Cleansers' }, { label: 'Exfoliants' }, { label: 'Toners' }]
            }
          ]
        ]
      },
    ];
  }
}