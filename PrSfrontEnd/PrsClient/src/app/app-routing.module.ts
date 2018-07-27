import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserCreateComponent } from '@user/user-create/user-create.component';
import { UserListComponent } from '@user/user-list/user-list.component';
import {UserDetailComponent} from '@user/user-detail/user-detail.component';
import { UserEditComponent } from '@user/user-edit/user-edit.component';
import { HomeComponent} from './home/home.component'
const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  {path: "user-create", component: UserCreateComponent},
  {path:"user-list", component: UserListComponent},
  {path: "user-details/:Id", component: UserDetailComponent},
  {path: "user-edit/:Id",component: UserEditComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponent = [ UserCreateComponent, UserListComponent, UserDetailComponent, UserEditComponent, HomeComponent]