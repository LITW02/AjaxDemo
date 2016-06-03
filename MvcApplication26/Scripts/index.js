$(function() {
    $("#myButton").on('click', function () {
        var min = $("#min").val();
        var max = $("#max").val();

        $.get("/home/getrandom", { min: min, max: max } , function (result) {
            $("#rand").text(result.Number);
            result.Nums.forEach(function(num) {
                $("ul").append("<li>" + num + "</li>");
            });
        });
    });

    $("#username").on('input', function() {
        var name = $(this).val();
        $.get('/home/checkusername', { username: name }, function(result) {
            $("#message").text(result.isGood ? "All good!" : "Sorry, try again");
            $("#sign-up").prop('disabled', !result.isGood);
        });
    });


    $("#reverse-button").on('click', function () {
        var textFromTextbox = $("#reverse-textbox").val();
        $.get("/home/reverse", { text: textFromTextbox }, function (result) {
            $("#reverse-text").text(result.reversed);
        });
    });


});