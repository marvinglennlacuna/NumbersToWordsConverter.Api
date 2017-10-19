$(document).ready(function () {
    $('form').submit(function () {
        $("#words").text("Processing...");
        $.ajax({
            url: 'api/Converter/Process',
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                Name: $('#name').val(),
                Numbers: $('#numbers').val()
            }),
            success: function (result) {
                $("#output").text("Output");
                $("#rname").text(result.Name);
                $("#words").text(result.Words);
            },
            error: function (result) {
                $("#output").text();
                $("#rname").text();
                $("#words").text();

                var errMesasgeObject = $.parseJSON(result.responseText);
                $("#words").text("Convertion Failed. Error Result: " + errMesasgeObject.Message);
            }
        });
        return false;
    });
});