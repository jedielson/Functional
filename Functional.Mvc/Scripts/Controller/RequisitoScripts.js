function loadGridRequisitos(projetoId) {
    $.ajax({
        url: '/Requisito/CarregaGrid',
        data: {
            projetoid: projetoId
        },
        success: function (data) {
            console.log('Entrou no success...');
            carregaGridRequisitos(data);
        },
        error: function (data) {
            console.error('Ocorreu um erro ao carregar o grid de requisitos');
            console.error(data);
        }
    });
}

function onCreateModalResult(data) {

    if (data != null && (data.reloadPage == null || data.reloadPage === false)) {
        return;
    }

    carregaGridRequisitos(data);
}

function carregaGridRequisitos(data) {

    if (data === '') {
        console.error('Não foi possível atualizar o grid.');
        console.error(data);
        return;
    }

    $("#grid-requisitos").html(data);
}