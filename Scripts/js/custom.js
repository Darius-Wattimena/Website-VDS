$("changePage").click(function () {
    $.ajax({
        url: this.href,
        cache: false,
        success: startRefresh
    });
    return false;
});

function startRefresh() {
    $.get('', function (data) {
        $(document.body).html(data);
    });
}
