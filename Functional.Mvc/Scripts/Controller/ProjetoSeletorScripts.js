$(function () {

    $('#DropDownListProjetos').change(function () {
        var tela = $('#HiddenTelaSelectProjeto').val();
        var projetoId = $('#DropDownListProjetos').val();

        if (tela === '' || projetoId === '') {
            console.error('O valor da tela, ou do projeto id é inválido.');
            return;
        }

        if (tela === 'Requisitos') {
            loadGridRequisitos(projetoId);
            return;
        }

        if (tela === 'CasosDeUso') {
            loadIndexCasosDeUso(projetoId);
            return;
        }

        console.error('Erro ao executar ação de escolha do projeto. A tela informada não existe');

        
    });

});