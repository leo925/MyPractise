
;
$(function () {

    function ajaxFormSubmit() {

        var form = $(this);
        var options = {
            url: form.attr("action"),
            type: form.attr("method"),
            data:form.serialize()
        };

        $.ajax(options).done(function (data) {
            var target = $(form.attr("data-leo-target"));
            target.html(data);
        });
        return false;

    };

    var createAutocomplete = function () {
       
    };


    $("form[data-leo-ajax='true']").submit(ajaxFormSubmit);

});