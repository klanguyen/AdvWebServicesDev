$(function () {
    initButtons();

    $('#first, #previous, #next, #last').on('click', function () {
        location.href = "page" + $(this).data('page');
    });

    $('.flag').on('click', function () {
        if ($(this).data('checked')) {
            $(this).data('checked', false);
            $(this).removeClass('fas').addClass('far');
        } else {
            $(this).data('checked', true);
            $(this).removeClass('far').addClass('fas');
        }
    })

    function initButtons() {
        //disable first and previous buttons on 1st page
        $('#first, #previous').prop('disabled', $('#start').html() == "1");
        //disable next and last buttons of the last page
        $('#next, #last').prop('disabled', $('#end').html() == $('#total').html());
    }
})