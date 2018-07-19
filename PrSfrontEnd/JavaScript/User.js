"option strict"


function list(){
    $.getJSON('http://localhost:58587/Users/List')
    .done(function(response){
        displayAll(response.Data);
    });
}

function displayAll(users){
    var tbody = document.getElementById("tbody");
    tbody.innerHTML = '';
    for(var user of users){
        var row ='';
        row+= "<tr>";
        row+="<td>" + user.Id + "</td>";
        row+="<td>" + user.UserName + "</td>";
        row+="<td> ********</td>";
        row+="<td>" + user.Fname + "</td>";
        row+="<td>" + user.Lname + "</td>";
        row+="<td>" + user.Phone + "</td>";
        row+="<td>" + user.Email + "</td>";
        row+="<td>" + user.IsAdmin + "</td>";
        row+="<td>" + user.IsReviewer + "</td>";
        row+="<td>" + user.IsActive + "</td>";
        row+="</tr>";
        tbody.innerHTML +=row;

    }
}

function Search(){
    var Id = document.getElementById("Id").value;
    $.getJSON('http://localhost:58587/Users/Find/' + Id)
    .done(function(response){
        display(response.Data);
    });
}

function display(user){
    var tbody = document.getElementById("tbody");
    tbody.innerHTML = '';
        var row ='';
        row+= "<tr>";
        row+="<td>" + user.Id + "</td>";
        row+="<td>" + user.UserName + "</td>";
        row+="<td> ********</td>";
        row+="<td>" + user.Fname + "</td>";
        row+="<td>" + user.Lname + "</td>";
        row+="<td>" + user.Phone + "</td>";
        row+="<td>" + user.Email + "</td>";
        row+="<td>" + user.IsAdmin + "</td>";
        row+="<td>" + user.IsReviewer + "</td>";
        row+="<td>" + user.IsActive + "</td>";
        row+="</tr>";
        tbody.innerHTML +=row;

    
}

function create(){
    var User = {
        Id:0,
        UserName: document.getElementById("fUsername").value,
        Password: document.getElementById("fPassword").value,
        Fname: document.getElementById("fFname").value,
        Lname: document.getElementById("fLname").value,
        Phone: document.getElementById("fPhone").value,
        Email: document.getElementById("fEmail").value,
        IsAdmin : false,
        IsActive: true,
        IsReviewer: false

    }

    $.post("http://localhost:58587/Users/Create" , User)
        .done(function(Resp){
            console.log(Resp)
            alert("Account Created.")
        });

}

