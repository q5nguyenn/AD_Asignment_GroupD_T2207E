$("#formRegister").submit(function (e) { 
    e.preventDefault();
    var data = {
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        Email: $("#Email").val(),
        Password: $("#Password").val()
    }
    console.log(data);
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "/accounts/register",
        data: JSON.stringify(data),
        success: function (response) {
            console.log(response);
            if(response == "success") {
                alert("Dang ky thanh cong");
                window.location.replace("/accounts/login");
            }
        }
    });
});