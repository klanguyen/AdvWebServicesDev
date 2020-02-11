﻿// Turn off ESLint (Windows): Tools - Options - Text Editor - Javascript - Linting
$(function () {
    getEvents(1);

    function getEvents(page) {
        $.getJSON({
            url: "../api/event/page" + page,
            success: function (response, textStatus, jqXhr) {
                // console.log(response);
                showTableBody(response.events);
                showPagingInfo(response.pagingInfo);
                initButtons();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                // log the error to the console
                console.log("The following error occured: " + textStatus, errorThrown);
            }
        });
    }

    // event listeners for first/next/prev/last buttons
    $('#next, #prev, #first, #last').on('click', function () {
        getEvents($(this).data('page'));
    });

    function showTableBody(e) {
        var html = "";
        for (i = 0; i < e.length; i++) {
            var f = e[i].flag ? "fas" : "far";
            html += "<tr>";
            html += "<td class=\"text-center\">";
            html += "<i data-id=\"" + e[i].id + "\" data-checked=\"" + e[i].flag + "\" class=\"" + f + " fa-flag fa-lg flag\" />";
            html += "</td>";
            html += "<td>" + e[i].ts.split("T")[0] + "</td>";
            html += "<td>" + e[i].ts.split("T")[1] + "</td>";
            html += "<td>" + e[i].loc + "</td>";
            html += "</tr> ";
        }
        $('tbody').html(html);
    }

    function showPagingInfo(p) {
        $('#start').html(p.eventRangeStart);
        $('#end').html(p.eventRangeEnd);
        $('#total').html(p.totalEvents);
        $('#first').data('page', 1);
        $('#next').data('page', p.nextPage);
        $('#prev').data('page', p.previousPage);
        $('#last').data('page', p.totalPages);
    }

    function initButtons() {
        // disable prev/first buttons when on first page
        $('#first, #prev').prop('disabled', $('#start').html() == "1");
        // disable next/last buttons when on last page
        $('#last, #next').prop('disabled', $('#end').html() == $('#total').html());
    }
});