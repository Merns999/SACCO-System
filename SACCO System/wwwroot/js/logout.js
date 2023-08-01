var logout = {
    init: function () {
        try {
            this.logout = function () {
                debugger;
                sessionStorage.removeItem('name');
                window.location.href = "/Users/Login";
            }
        } catch (error) {
            //ToDo: Implement catch
        }
    }
}
$(document).ready(function () {
    logout.init();
}); 