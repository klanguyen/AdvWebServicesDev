$(function () {
    initButtons();

    $('#first, #previous, #next, #last').on('click', function () {
        location.href = "page" + $(this).data('page');
    });

    function initButtons() {
        //disable first and previous buttons on 1st page
        $('#first, #previous').prop('disabled', $('#start').html() == "1");
        //disable next and last buttons of the last page
        $('#next, #last').prop('disabled', $('#end').html() == $('#total').html());
    }
})