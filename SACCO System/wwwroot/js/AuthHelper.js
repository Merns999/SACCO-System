var AuthHelper = {
    navigateToPath: function (url) {
        debugger;
        if (navigator.userAgent.match(/MSIE\s(?!9.0)/)) {
            var referLink = document.createElement("a");
            referLink.href = url;
            document.body.appendChild(referLink);
            referLink.click();
        }     //all other browsers
        else {
            window.location.replace(url);
        }
    }
    }