define([
    'jquery'
], function ($) {
    // P1
    $(function () {
        $("#map").click(function () {
            // Code
        });
    });

    // P2
    return function () {
        this.showMsg = function () {
            alert('Public method showMsg!');
        }
    }
});