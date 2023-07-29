var Register = {
    init: function () {
        try {
            var ViewModel = function () {

                this.FirstName = ko.observable();;
                this.LastName = ko.observable();
                this.PhoneNo = ko.observable();
                this.Email = ko.observable();
                this.IdNo = ko.observable()
                this.DateOB = ko.observable();
                this.AccType = ko.observableArray["Savings", "Personal", "Business"];
                this.Password = ko.observable();
                this.RePassword = ko.observable();
                this.hasError = ko.observable(false);
                this.errorMessage = ko.observable();


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

                this.validate = function () {
                    var self = this;
                    if (self.FirstName() == null) {
                        this.showErrorMessage("Validation Failed", "First name can not be empty");
                        return false;
                    }
                    else if (self.LastName() == null) {
                        this.showErrorMessage("Validation Failed", "Last name can not be empty");
                        return false;
                    }
                    else if (self.Email() == null) {
                        this.showErrorMessage("Validation Failed", "Email can not be empty");
                        return false;
                    }
                    else if (self.PhoneNo() == null) {
                        this.showErrorMessage("Validation Failed", "Phone Number can not be empty");
                        return false;
                    }
                    else if (self.IdNo() == null) {
                        this.showErrorMessage("Validation Failed", "Id Number can not be empty");
                        return false;
                    }
                    else if (self.AccType() == null) {
                        this.showErrorMessage("Validation Failed", "You have to choose the type of account");
                        return false;
                    }
                    else if (self.DateOB() == null) {
                        this.showErrorMessage("Validation Failed", "Fill in your Date Of Birth");
                        return false;
                    }
                    else if (self.DateOB() == null) {
                        this.showErrorMessage("Validation Failed", "Fill in your Date Of Birth");
                        return false;
                    }
                    else if (self.Password() != self.RePassword()) {
                        this.showErrorMessage("Validation Failed", "Your Passwords do not match");
                        return false;
                    }

                }

                
                this.Register = function () {
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
        } catch (error) {

        }
    }
}