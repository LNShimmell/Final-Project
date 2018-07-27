import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from  './User/user';
import {JsonResponse} from './User/JsonResponse';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url = "http://localhost:58587/Users/";
  
  list(): Observable<JsonResponse>{
    return this.http.get(this.url+"list") as Observable<JsonResponse>;
  }
  getuser(id: number): Observable<JsonResponse>{
    return this.http.get(this.url+"find/" + id) as Observable<JsonResponse>;
  }
  create(user: User) :Observable<JsonResponse>{
    return this.http.post(this.url+"create", User) as Observable<JsonResponse>;

  }
  edit(user: User) :Observable<JsonResponse>{
    return this.http.post(this.url+ "/edit", user) as Observable<JsonResponse>;
  }
  remove(user: User) :Observable<JsonResponse>{
    return this.http.post(this.url+ "/delete", user.Id) as Observable<JsonResponse>;
  }



  constructor(private http: HttpClient) { }
}
