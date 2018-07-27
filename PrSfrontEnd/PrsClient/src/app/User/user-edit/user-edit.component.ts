import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../app/user.service';
import { User } from '../user';
import {JsonResponse} from '../JsonResponse';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';


@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  user : User = new User;

  constructor(private UserSvc: UserService, private route: ActivatedRoute) { }

  ngOnInit() {
    let Id = this.route.snapshot.params.Id
    this.UserSvc.getuser(Id)
    .subscribe(resp =>{
      this.user = resp.Data;
    })
  }
  }

}
