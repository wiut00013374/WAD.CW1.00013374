import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarListComponent } from './components/car-list/car-list.component';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { UserDetailComponent } from './components/user-detail/user-detail.component';

export const routes: Routes = [
  { path: 'cars', component: CarListComponent },
  { path: 'cars/add', component: CarDetailComponent },
  { path: 'cars/edit/:id', component: CarDetailComponent },
  { path: 'users', component: UserListComponent },
  { path: 'users/add', component: UserDetailComponent },
  { path: 'users/edit/:id', component: UserDetailComponent },
  { path: '', redirectTo: '/cars', pathMatch: 'full' },
  { path: '**', redirectTo: '/cars' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
