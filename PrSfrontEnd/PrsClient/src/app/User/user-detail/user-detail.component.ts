import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../app/user.service'
import { User } from '../user';
import {JsonResponse} from '../JsonResponse';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';


@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
 
  user: User = new User;
  title: string = 'User Details'
  
 
  

 

  constructor(private UserSvc: UserService, private route: ActivatedRoute ) { 
  
   
  } 

  ngOnInit() {
    let Id = this.route.snapshot.params.Id
    this.UserSvc.getuser(Id)
    .subscribe(resp =>{
      this.user = resp.Data;
    })
  }

}
