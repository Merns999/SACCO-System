var loans = {
    init: function () {
        var ViewModel = function () {
            var self = this;
            self.IdNo = ko.observable();
            self.Amount = ko.observable();
            self.agreeToTerms = ko.observable(false);

            this.checkstatus = function () {
                
                debugger;
                $.ajax({
                    type: "GET",
                    url: "",//controller to get the status
                    data: JSON.stringify(data),
                    contentType: "application/json",
                    success: function (responce) {
                        //handle success message
                        return true;
                    },
                    error: function (error) {
                        //handle error
                        return false;
                    }
                });
                
            }

            this.applyLoan = function () {
                var self = this;
                if (self.agreeToTerms() == false) {
                    debugger;
                    return;
                }
                if (self.checkstatus() == false) {
                    return;
                } else {
                    self.data = {
                        IdNo: self.IdNo(),
                        amount: self.Amount()
                    };
                    $.ajax({
                        type: "POST",
                        url: "",//controller to add the record into the loans table
                        data: JSON.stringify(data),
                        contentType: "application/json",
                        success: function (responce) {
                            //handle success message
                            return true;
                        },
                        error: function (error) {
                            //handle error
                            return false;
                        }
                    });
                }
            }
        }
        ko.applyBindings(new ViewModel());
    }
}
$(document).ready(function () {
    debugger;
    loans.init();
});
