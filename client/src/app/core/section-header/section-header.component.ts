import { Component } from '@angular/core';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-section-header',
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.scss']
})
export class SectionHeaderComponent {

  // Note: BreadcrumbService is public, so we can access it within the HTML template.  
  constructor(public breadcrumbService: BreadcrumbService) {}
}
