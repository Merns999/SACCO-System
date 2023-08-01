var login = {
    init: function () {
        try {
            var ViewModel = function () {
                var self = this;

                self.FirstName = ko.observable();
                self.IdNo = ko.observable();
                self.Email = ko.observable();
                self.Password = ko.observable();
                self.hasError = ko.observable(false);
                self.errorMessage = ko.observable();



                this.validate = function () {
                    debugger;
                    if (self.IdNo() == null) {
                        this.showErrorMessage("Validation Failed", "ID can not be empty");
                        return false;
                    }
                    else if (self.Password() == null) {
                        this.showErrorMessage("Validation Failed", "Your Passwords cannot be ");
                        return false;
                    }

                }
                this.showErrorMessage = function (title, message) {
                    try {
                        this.hasError(true);
                        this.showOkAlertBox(title, message, "red", null);

                    }
                    catch (err) {
                        this.showOkAlertBox(title, err.message, "red", null);
                    }
                }
                this.showOkAlertBox = function (title, message, color, onOkCallbackMethod) {
                    alert(title + " : " + message);
                    debugger;
                    window.location.href = "/Users/Login";
                }

                
                this.LoginUser = function () {
                    var self = this;
                    debugger;
                    if (self.validate() == false) {
                        return;
                    }

                    this.hasError(false);

                    self.data = {
                        IdNo: self.IdNo()
                    };

                    //$.ajax({
                    //    type: "GET",
                    //    url: "",//controller to perform a get into the users table using the id given
                    //    dataType: "json",
                    //    contentType: "application/json; charset=UTF-8",
                    //    data: JSON.stringify(self.data),

                    //}).done(function (data) {
                    //    try {
                    //        if (data.password == self.password()) {
                    //debugger;
                    /*AuthHelper.navigateToPath("/Users/UserFront");*/
                    window.location.href = "/Users/UserFront";
                    //sessionStorage.setItem('name', data.FirstName);
                    //        }
                    //    }
                    //    catch (err) {
                    //        self.showErrorMessage('Error', err.message);
                    //    }
                    //}).fail(function (err) {
                    //    try {
                    //        self.hasError(true);
                    //        var jdata = jQuery.parseJSON(err.responseText);
                    //        self.showErrorMessage('Failed', jdata.Message);
                    //    } catch (err) {
                    //        self.showErrorMessage('Error', err.message);
                    //    }
                    //});
                }
            }
            ko.applyBindings(new ViewModel());
        }
        catch (error) {
            //ToDo: Implement catch
            self.showErrorMessage('Error', error);
        }
    }
}
$(document).ready(function () {
    debugger;
    login.init();
});