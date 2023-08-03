//const name = sessionStorage.getItem('name');
$(document).ready(function () {
    

    this.showProfile = function () {
        var data = localStorage.getItem("ProfileData");
        var jsonData = JSON.parse(data);
    }
    

    this.getprofile = function () {
        $.ajax({
            type: "GET",
            url: "/api/Profile",
            success: function (responce) {
                //handle success message
                /*debugger;*/

                
                localStorage.setItem("ProfileData", JSON.stringify(responce));
                window.location.href = "/Users/Profile";
            },
            error: function (error) {
                //handle error
                console.log("Error fetching players data:", error);
            }
        });
    }
});