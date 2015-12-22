function prepareModalDialog(dialogDivId) {
    ///<summary>
    /// Monta a div reservada para o conteúdo a ser exibido no popUp
    ///</summary>
    ///<param name="dialogDivId">O Id da div a ser criada.</param>

    $(document.body).append('<div class="modal fade" id="' + dialogDivId + '" role="dialog""></div>');
}

function clearModalDialog(dialogDivId) {
    ///<summary>
    /// Limpa a div do modal
    ///</summary>
    ///<param name="dialogDivId">O Id da div a ser removida.</param>

    var div = $('#' + dialogDivId);
    div.on('hidden.bs.modal', limparModalEDropBack(dialogDivId));
    div.modal("hide");
}

function setFormDataAjaxAttributes(dialogDivId, title, callback) {
    ///<summary>
    /// Adiciona atributos ajax à div reservada ao modal
    ///</summary>
    /// <param name="dialogDivId">A div do modal que deve receber os atributos Ajax</param>
    /// <param name="title">O título da div</param>
    /// <param name="inputRetorno">O input de retorno de dados em Json após o postback</param>
    /// <param name="callback">Uma função de callback para manipulação dos dados retornados</param>

    var div = $("#" + dialogDivId);
    div.find("form").attr("data-ajax-update", "#" + dialogDivId);
    div.find("form").attr("data-ajax-complete", "onModalDialogSubmitted('" + dialogDivId + "', '" + title + "', " + callback + ")");
    $.validator.unobtrusive.parse(div.find('form'));
}

function onModalDialogSubmitted(dialogDivId, title, callback) {
    ///<summary>
    /// Função executada após a resposta do servidor ao submit do form dentro da div de modal.
    ///</summary>
    /// <param name="dialogDivId">A div do modal que deve receber os atributos Ajax</param>
    /// <param name="title">O título da div</param>
    /// <param name="inputRetorno">O input de retorno de dados em Json após o postback</param>
    /// <param name="callback">Uma função de callback para manipulação dos dados retornados</param>

    var data = $('input[ajax-callback-result]').val();

    prepareBootstrapDialog(dialogDivId, title);

    var div = $("#" + dialogDivId);
    var result = div.find("div[data-dialog-close='true']");
    if (result.length === 0) {
        setFormDataAjaxAttributes(dialogDivId, title, callback);
        data = addCallbackData(data, 'reloadPage', false);
        callback && callback(data);
        return;
    }

    clearModalDialog(dialogDivId);
    var message = result.attr("data-dialog-result");
    if (message.length > 0) {
        alert(message);
    }
    callback && callback(data);
}

function openModalDialog(dialogDivId, title, callback) {
    ///<summary>
    /// Abre a modal na tela
    ///</summary>
    /// <param name="dialogDivId">A id da div div onde a modal deve ser aberta</param>
    /// <param name="title">O título da modal</param>
    /// <param name="inputRetorno">O input de retorno de dados em Json após o postback</param>
    /// <param name="callback">Uma função de callback para manipulação dos dados retornados</param>

    prepareBootstrapDialog(dialogDivId, title);
    var divModal = $("#" + dialogDivId);
    divModal.modal({
        show: true,
        backdrop: "static"
    });
    divModal.on('shown.bs.modal', mapearDropBack(dialogDivId));
    setFormDataAjaxAttributes(dialogDivId, title, callback);
}

function prepareBootstrapDialog(dialogDivId, title) {
    ///<summary>
    /// Prepara o esqueleto de uma modal bootstrap
    ///</summary>
    /// <param name="dialogDivId">o id da div onde a modal deve ser montada</param>
    /// <param name="title">O título da modal</param>

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
    /// <summary>
    /// Mapeia os dropbacks das modais.
    /// Necessário, para quando efetuar o fechamento da modal, fechar o dropback correspondente
    ///</summary>
    ///<param name="dialogDivId">O Id da div onde a modal foi montada</param>

    $('.modal-backdrop').each(function () {
        if ($(this).attr("id") == null) {
            $(this).attr("id", dialogDivId);
        }
    });
}

function limparModalEDropBack(dialogDivId) {
    /// <summary>
    /// Limpa a modal else seu dropback
    /// </summary>
    /// <param name="dialogDivId">O Id da div a ser removida</param>
    $('#' + dialogDivId).remove();
    $('#' + dialogDivId).remove();
}

function addCallbackData(data, propName, value) {
    if (data == null) {
        data = {};
    }

    data[propName] = value;
    return data;
}