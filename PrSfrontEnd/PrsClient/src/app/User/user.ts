export class User{
    Id: number;
    UserName: string;
    Password: string;
    Fname: string;
    Lname: string;
    Phone: string;
    Email: string;
    IsReviewer:  boolean;
    IsAdmin: boolean;
    Active: boolean;
    

    constructor(){
        this.Id = 0;
        this.IsReviewer = false;
        this.IsReviewer = false;
        this.Active = true;
    }
}