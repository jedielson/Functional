function modalPopUpNovoSuccess(data) {

    if (data != null && data.reloadPage != null && data.reloadPage  === false) {
        return;
    }

    document.open();
    document.write(data);
    document.close();
}