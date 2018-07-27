import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../app/user.service';
import { User } from '../user';
import {JsonResponse} from '../JsonResponse';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  

  user: User = new User();
  users: User[] = [];
  list(): void{
    this.UserSvc.list()
      .subscribe(resp => {
        console.log(resp);
      });


  }
  constructor(private UserSvc: UserService) { }

  ngOnInit() {
    
    this.UserSvc.list().subscribe(resp=> {
      this.users = resp.Data
    });
    
  }

}
