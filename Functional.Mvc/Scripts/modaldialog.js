function prepareModalDialog(dialogDivId) {
    $(document.body).append('<div class="modal fade" id="' + dialogDivId + '" role="dialog""></div>');
}

function clearModalDialog(dialogDivId) {

    var div = $('#' + dialogDivId);
    div.on('hidden.bs.modal', limpar(dialogDivId));
    div.modal("hide");
}

function setFormDataAjaxAttributes(dialogDivId, title, inputRetorno, callback) {
    var div = $("#" + dialogDivId);
    div.find("form").attr("data-ajax-update", "#" + dialogDivId);
    div.find("form").attr("data-ajax-complete", "onModalDialogSubmitted('" + dialogDivId + "', '" + title + "', '" + inputRetorno + "', " + callback + ")");
}

function onModalDialogSubmitted(dialogDivId, title, inputRetorno, callback) {

    var data = $('#' + inputRetorno).val();
    callback && callback(data);

    prepareBootstrapDialog(dialogDivId, title);

    var div = $("#" + dialogDivId);
    var result = div.find("div[data-dialog-close='true']");
    if (result.length == 0) {
        setFormDataAjaxAttributes(dialogDivId, title, inputRetorno, callback);
        return;
    }

    clearModalDialog(dialogDivId);
    var message = result.attr("data-dialog-result");
    if (message.length > 0) {
        alert(message);
    }
}

function openModalDialog(dialogDivId, title, inputRetorno, callback) {
    prepareBootstrapDialog(dialogDivId, title);
    var divModal = $("#" + dialogDivId);
    divModal.modal({
        show: true,
        backdrop: "static"
    });
    divModal.on('shown.bs.modal', mapearDropBack(dialogDivId));
    setFormDataAjaxAttributes(dialogDivId, title, inputRetorno, callback);
}

function prepareBootstrapDialog(dialogDivId, title) {
    var div = $("#" + dialogDivId);
    var form = $("#" + dialogDivId).find(':first').detach();

    var modalPopUp = '<!-- Modal -->';
    modalPopUp += '<div class="modal-dialog">';
    modalPopUp += '<!-- Modal content-->';
    modalPopUp += '<div class="modal-content">';
    modalPopUp += '<div class="modal-header">';
    modalPopUp += '<button type="button" class="close" data-dismiss="modal"';
    modalPopUp += "onclick=clearModalDialog('" + dialogDivId;
    modalPopUp += "')>&times;</button>";
    modalPopUp += '<h4 class="modal-title">' + title + '</h4>';
    modalPopUp += '</div>';
    modalPopUp += '<div class="modal-body"></div>';
    modalPopUp += '</div></div>';

    div.append(modalPopUp);
    div = $('#' + dialogDivId).find('.modal-body');
    div.append(form);
}

function mapearDropBack(dialogDivId) {
    $('.modal-backdrop').each(function () {
        if ($(this).attr("id") == null) {
            $(this).attr("id", dialogDivId);
        }
    });
}

function limpar(dialogDivId) {
    $('#' + dialogDivId).remove();
    $('#' + dialogDivId).remove();
}

function tratamentoCallBack(data) {

    console.log('Entrou no CallBack...');
    console.log(data);
}