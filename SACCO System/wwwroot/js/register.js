var register = {
    init: function () {
        /*debugger;*/
        try {
            var ViewModel = function () {
                var self = this;

                self.FirstName = ko.observable();
                self.LastName = ko.observable();
                self.PhoneNo = ko.observable();
                self.Email = ko.observable();
                self.IdNo = ko.observable();
                self.DateOB = ko.observable();
                self.AccType = ko.observableArray(['SAVINGS', 'INVESTMENT', 'LOAN']);
                self.account = ko.observable();
                self.Password = ko.observable();
                self.RePassword = ko.observable();
                self.hasError = ko.observable(false);
                self.errorMessage = ko.observable();

                var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
                var passwordPattern = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;


                this.showErrorMessage = function (title, message) {
                    try {
                        debugger;
                        this.hasError(true);
                        //this.errorMessage(title + ':' + message);
                        this.showAlertBox(title, message, "red", null);

                    }
                    catch (err) { 
                        this.showAlertBox(title, err.message, "red", null);
                    }
                }
                this.showAlertBox = function (title, message, color, onOkCallbackMethod) {
                    alert(title + " : " + message);
                    debugger;
                    window.location.href = "/Users/register";
                }
                this.showConfirmBox = function (title, message, color, onOkCallbackMethod) {
                    debugger;
                    var ans = confirm(title + " : " + message);
                    if (ans) {
                        debugger;
                        window.location.href = "/Users/Userfront";
                    }
                }
                this.validate = function () {
                    var self = this;
                    var pass = self.Password();
                    if (self.FirstName() == null) {
                        self.showErrorMessage("Validation Failed", "First name can not be empty");
                        return false;
                    }
                    else if (self.LastName() == null) {
                        self.showErrorMessage("Validation Failed", "Last name can not be empty");
                        return false;
                    }
                    else if (self.Email() == null) {
                        self.showErrorMessage("Validation Failed", "Email can not be empty");
                        return false;
                    }
                    //else if (emailPattern.test(self.Email)) {
                    //    self.showErrorMessage("Validation Failed", "Email is not in the correct format");
                    //    return false;
                    //}
                    else if (self.PhoneNo() == null) {
                        self.showErrorMessage("Validation Failed", "Phone Number can not be empty");
                        return false;
                    }
                    else if (self.IdNo() == null) {
                        self.showErrorMessage("Validation Failed", "Id Number can not be empty");
                        return false;
                    }
                    else if (self.AccType() == null) {
                        self.showErrorMessage("Validation Failed", "You have to choose the type of account");
                        return false;
                    }
                    else if (self.DateOB() == null) {
                        self.showErrorMessage("Validation Failed", "Fill in your Date Of Birth");
                        return false;
                    }
                    else if (self.Password() != self.RePassword()) {
                        self.showErrorMessage("Validation Failed", "Your Passwords do not match");
                        return false;
                    }
                    else if (!passwordPattern.test(pass)) {
                        self.showErrorMessage("Validation Failed", "Your Passwords do not meet the criteria");
                        return false;
                    }

                }

                
                this.RegisterUser = function () {
                    var self = this;
                    debugger;
                    if (self.validate() == false) {
                        return;
                    }
                    let acc = self.AccType();
                    debugger;
                    if (self.account() == "SAVINGS") {
                        this.hasError(false);
                        debugger;
                        self.data = {
                            FirstName: self.FirstName(),
                            LastName: self.LastName(),
                            PhoneNo: self.PhoneNo(),
                            IdNo: self.IdNo(),
                            Email: self.Email(),
                            DateOB: self.DateOB(),
                            Password: self.Password()
                        };

                        //$.ajax({
                        //    type: "POST",
                        //    url: "/Register/Savings",//where the controller url goes
                        //    dataType: "json",
                        //    contentType: "application/json; charset=UTF-8",
                        //    data: JSON.stringify(self.data),

                        //}).done(function (data) {
                        //    try {
                        //debugger;
                        //        AuthHelper.navigateToPath("/Users/Login");
                        window.location.href = "/Users/Userfront";
                        sessionStorage.setItem('name', self.FirstName());
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
                    if (self.account() == "INVESTMENT") {
                        this.hasError(false);
                        debugger;
                        self.data = {
                            FirstName: self.FirstName(),
                            LastName: self.LastName(),
                            PhoneNo: self.PhoneNo(),
                            IdNo: self.IdNo(),
                            Email: self.Email(),
                            DateOB: self.DateOB(),
                        };

                        //$.ajax({
                        //    type: "POST",
                        //    url: "/Register/Investment",//where the controller url goes
                        //    dataType: "json",
                        //    contentType: "application/json; charset=UTF-8",
                        //    data: JSON.stringify(self.data),

                        //}).done(function (data) {
                        //    try {
                        //        AuthHelper.navigateToPath("/Users/Login");
                        window.location.href = "/Users/Userfront";
                        sessionStorage.setItem('name', self.FirstName());

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
                    if (self.account() == "LOAN") {
                        this.hasError(false);
                        debugger;

                        self.data = {
                            FirstName: self.FirstName(),
                            LastName: self.LastName(),
                            PhoneNo: self.PhoneNo(),
                            IdNo: self.IdNo(),
                            Email: self.Email(),
                            DateOB: self.DateOB(),
                        };

                        //$.ajax({
                        //    type: "POST",
                        //    url: "/Register/Loan",//where the controller url goes
                        //    dataType: "json",
                        //    contentType: "application/json; charset=UTF-8",
                        //    data: JSON.stringify(self.data),

                        //}).done(function (data) {
                        //    try {
                        //        debugger;
                        //        AuthHelper.navigateToPath("/Users/Login");
                        window.location.href = "/Users/Userfront";
                        sessionStorage.setItem('name', self.FirstName());
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
            }
            ko.applyBindings(new ViewModel());
        }
        catch (error) {
            ///ToDo:Implement catch
            self.showErrorMessage("Registration Failed", error);
        }
    }
}

$(document).ready(function () {
    //debugger;
    register.init();
});