import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../app/user.service';
import { User } from '../user';
import {JsonResponse} from '../JsonResponse';
import { HttpClientModule, HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {
  user: User = new User();

  create(): void{
    this.UserSvc.create(this.user)
    .subscribe(resp=> {
      console.log(resp);
    });
  }

  constructor(private UserSvc: UserService) { }

  ngOnInit() {
  }

}
