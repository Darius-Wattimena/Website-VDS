var url = '@Url.Action("AntwoordController", "Create")';
$('#Add-Antwoord').click(function () {
    $('#Place-Antwoord').load(url);
})