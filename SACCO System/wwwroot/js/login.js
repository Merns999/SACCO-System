var login = {
    init: function () {
        try {
            var ViewModel = function () {

                this.FirstName = ko.observable();
                this.Email = ko.observable();
                this.Password = ko.observable();
                this.RePassword = ko.observable();
                this.hasError = ko.observable(false);
                this.errorMessage = ko.observable();



                this.validate = function () {
                    var self = this;
                    
                    if (self.Email() == null) {
                        this.showErrorMessage("Validation Failed", "Email can not be empty");
                        return false;
                    }
                    else if (self.Password() == null) {
                        this.showErrorMessage("Validation Failed", "Your Passwords do not match");
                        return false;
                    }

                }
                this.showErrorMessage = function (title, message) {
                    try {
                        this.hasError(true);
                        //this.errorMessage(title + ':' + message);
                        this.showOkAlertBox(title, message, "red", null);

                    }
                    catch (err) {
                        this.showOkAlertBox(title, err.message, "red", null);
                    }
                }
                this.showOkAlertBox = function (title, message, color, onOkCallbackMethod) {
                    $.confirm({
                        icon: 'icon-exclamation',
                        type: color,
                        useBootstrap: false,
                        width: 'auto',

                        typeAnimated: true,
                        title: title,
                        content: message,
                        buttons: {
                            confirm: {
                                btnClass: 'btn-green',
                                text: 'Ok',//yes button
                                action: function () {
                                    if (onOkCallbackMethod)
                                        onOkCallbackMethod();
                                }
                            },
                        }
                    });
                }

                if (this.AccType() == "Savings") {
                    this.RegisterSavings = function () {
                        var self = this;
                        if (self.validate() == false) {
                            return;
                        }

                        this.hasError(false);

                        self.data = {
                            FirstName: self.FirstName(),
                            PhoneNo: self.PhoneNo(),
                            Email: self.Email(),
                            LastName: self.LastName(),
                            IdNo: self.IdNo(),
                            DateOB: self.DateOB(),
                        };

                        $.ajax({
                            type: "POST",
                            url: "/Register/Savings",
                            dataType: "json",
                            contentType: "application/json; charset=UTF-8",
                            data: JSON.stringify(self.data),

                        }).done(function (data) {
                            try {
                                authenticationHelper.navigateToPath("/Users/Login");

                            }
                            catch (err) {
                                self.showErrorMessage('Error', err.message);
                            }
                        }).fail(function (err) {
                            try {
                                self.hasError(true);
                                var jdata = jQuery.parseJSON(err.responseText);
                                self.showErrorMessage('Failed', jdata.Message);
                            } catch (err) {
                                self.showErrorMessage('Error', err.message);
                            }
                        });
                    }
                }


            }
        } catch (error) {

        }
    }
}
$(document).ready(function () {
    debugger
    login.init();
});