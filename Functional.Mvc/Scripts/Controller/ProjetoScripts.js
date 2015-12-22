function modalPopUpNovoSuccess(data) {

    if (data != null && data.reloadPage != null && data.reloadPage  === false) {
        return;
    }

    $.get('/Projeto/Index').done(function (data) {
    
        document.open();
        document.write(data);
        document.close();

    }).fail(function () {
    
    });
}