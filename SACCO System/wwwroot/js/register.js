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
                self.AccType = ko.observableArray(["SAVINGS", "CURRENT", "INVESTMENT","LOAN"]);
                self.Password = ko.observable();
                self.RePassword = ko.observable();
                self.hasError = ko.observable(false);
                self.errorMessage = ko.observable();


                this.showErrorMessage = function (title, message) {
                    try {
                        debugger;
                        this.hasError(true);
                        //this.errorMessage(title + ':' + message);
                        this.showOkAlertBox(title, message, "red", null);

                    }
                    catch (err) { 
                        this.showOkAlertBox(title, err.message, "red", null);
                    }
                }
                this.showOkAlertBox = function (title, message, color, onOkCallbackMethod) {
                    debugger;
                    var ans = confirm(title + " : " + message);
                    if (ans) {
                        authenticationHelper.navigateToPath("/Users/Login");
                    }
                }
                //this.showOkAlertBox = function (title, message, onOkCallbackMethod) {
                //    debugger;
                //    var confirmDialog = document.createElement('div');
                //    confirmDialog.classList.add('confirm-dialog');
                //    confirmDialog.innerHTML = `<div class="confirm-dialog-content">
                //                                      <h3 class="confirm-dialog-title">${title}</h3>
                //                                      <p class="confirm-dialog-message">${message}</p>
                //                                      <div class="confirm-dialog-buttons">
                //                                        <button class="confirm-dialog-button btn-green" onclick="onOkCallbackMethod()">Ok</button>
                //                                        <button class="confirm-dialog-button btn-default" onclick="confirmDialog.remove()">Cancel</button>
                //                                      </div>
                //                                    </div>
                //                                  `;

                //    document.body.appendChild(confirmDialog);
                //    confirmDialog.addEventListener('click', function (event) {
                //        if (event.target.classList.contains('confirm-dialog-button')) {
                //            confirmDialog.remove();
                //        }
                //    });
                //}

                //showOkAlertBox('Are you sure?', 'This action cannot be undone.', function () {
                //    // Do something when the user clicks "Ok".
                //    authenticationHelper.navigateToPath("/Users/Login");
                //});

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

                
                this.RegisterUser = function () {
                    var self = this;
                    debugger;
                    if (self.validate() == false) {
                        return;
                    }
                    if (self.AccType() == "SAVINGS") {
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

                        $.ajax({
                            type: "POST",
                            url: "/Register/Savings",//where the controller url goes
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
                    if (self.AccType() == "INVESTMENT") {
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

                        $.ajax({
                            type: "POST",
                            url: "/Register/Investment",//where the controller url goes
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
                    if (self.AccType() == "LOAN") {
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

                        $.ajax({
                            type: "POST",
                            url: "/Register/Loan",//where the controller url goes
                            dataType: "json",
                            contentType: "application/json; charset=UTF-8",
                            data: JSON.stringify(self.data),

                        }).done(function (data) {
                            try {
                                debugger;
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
            ko.applyBindings(new ViewModel());
        } catch (error) {

        }
    }
}

$(document).ready(function () {
    debugger;
    register.init();
});