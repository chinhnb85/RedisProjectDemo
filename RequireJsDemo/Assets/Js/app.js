require.config({

    baseUrl: "Assets/Js",    
    paths: {        
        jquery: "Libs/jquery-2.0.3.min",
        bootstrap: "Libs/bootstrap.min",
        news: "Modules/News/main"
    },
    urlArgs: "1.0.3"
});


require(["jquery", "bootstrap", "news"],
    function ($, bs, news) {
    
    $(function () {
        var ls = new news();

        // Hiển thị popup trên tất cả các page
        $("#popup").show();

        // Hiển thị message
        ls.showMsg();
    });

    /**
     * Làm chẵn tiền tới đơn vị nghìn
     */
    function roundCurrency(amount) {
        return Math.round(amount / 1000) * 1000;
    }
});