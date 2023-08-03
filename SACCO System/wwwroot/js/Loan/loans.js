var loans = {
    init: function () {
        var ViewModel = function () {
            var self = this;
            self.IdNo = ko.observable();
            self.Amount = ko.observable();
            self.GuarantorId = ko.observable();
            self.Email = ko.observable();
            self.LoanType = ko.observable(["LONG_TERM", "SHORT_TERM"]);
            self.loanTypeSelected = ko.observable(); 
            self.AnnualIn = ko.observable();
            self.Principle = ko.observable();
            self.LoanPeriod = ko.observable();
            

            self.agreeToTerms = ko.observable(false);

            this.checkLockStatus = function () {
                debugger;
                $.ajax({
                    type: "GET",
                    url: "/api/Loans/GetLoanApplicationStatus/" + self.IdNo(),//controller to get the status
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
            this.getLoanApplicationStatus = function () {
                debugger;
                $.ajax({
                    type: "GET",
                    url: "/api/Loans/GetLoanApplicationStatus/" + self.IdNo(),//controller to get the status
                    data: JSON.stringify(data),
                    contentType: "application/json",
                    success: function (responce) {
                        //handle success message
                        return responce.LoanApplicationStatus;
                    },
                    error: function (error) {
                        //handle error
                        return false;
                    }
                });

            }
            this.CheckGuarantor = function (Gid) {
                debugger;
                $.ajax({
                    type: "GET",
                    url: "api/Loans/GetLoanGuarantors/" + Gid,//controller to get the status
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

            this.RequestLoan = function () {
                var self = this;
                if (self.agreeToTerms() == false) {
                    debugger;
                    return;
                }
                if (self.checkLockStatus() == false) {
                    return;
                }
                if (self.getLoanApplicationStatus() == false) {
                    return;
                }
                if (self.CheckGuarantor(self.GuarantorId()) == false) {
                    return;
                }
                else {
                    self.data = { 
                        MemberId: self.IdNo(),
                        GuarantorId: self.GuarantorId(),
                        TypeOfLoan: self.LoanType(),
                        AnnualIncome: self.AnnualIn(),
                        LoanPeriod: self.LoanPeriod(),
                        LoanPrinciple: self.Principle(),
                        ApplicationStatus : self.getLoanApplicationStatus()
                    };

                    $.ajax({
                        type: "POST",
                        url: "/api/Loans/MakeLoanApplication",//controller to add the record into the loans table
                        data: JSON.stringify(data),
                        contentType: "application/json",
                        success: function (responce) {
                            //handle success message
                            
                        },
                        error: function (error) {
                            //handle error
                            
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
