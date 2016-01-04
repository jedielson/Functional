function loadIndexCasosDeUso(projetoId) {
    $.ajax({
        url: '/CasoDeUso/CarregaWorkArea',
        type: 'GET',
        data: {
            projetoId: projetoId
        },
        success: function (data) {
            carregaIndex(data);
        },
        error: function (data) {
            console.error('Ocorreu um erro ao carregar o Index de casos de uso');
            console.error(data);
        }
    });
}

function carregaIndex(data) {

    if (data == null) {
        console.error('Erro ao retornar os dados da Index da página de casos de uso');
        return;
    }

    $('#caso-de-uso').html(data);
}

var CasoDeUsoModule = (function () {
    
    /**
     * Dado um array Json, e um valor, verifica se o valor está no array
     * @param {} jsonData Um array Json
     * @param {} value O valor a ser procurado
     * @returns {} O index do valor no Array, ou -1 caso não seja encontrado
     */
    var findJsonItemValue = function (jsonData, value) {
        if (jsonData == null || value == null || jsonData.length === 0) {
            return -1;
        }
        for (var i = 0; i < jsonData.length; i++) {
            if (jsonData[i] === value) {
                return i;
            }
        }
        return -1;
    }

    /**
     * Armazena um Array Json num Hidden field de Id #RequisitoSelecionado
     * @param {} jsonData O Array Json a ser armazenado
     */
    var setRequisitosAssociados = function (jsonData) {
        if (jsonData == null) {
            return;
        }
        $('#RequisitoSelecionado').val(JSON.stringify(jsonData));
    }

    /**
     * Recupera um Array Json armazenado num hidden field #RequisitoSelecionado
     * @returns {} Um Array Json com os valores que estavam armazenados no hidden field
     */
    var getRequisitosAssociados = function () {
        var values = $('#RequisitoSelecionado').val();
        if (values === '') {
            return JSON.parse('[]');
        }
        return JSON.parse(values);
    }

    /**
     * Associa um requisito ao caso de uso, e o armazena no DOM
     * @param {} selected O GUID do requisito selecionado
     * @returns {} 
     */
    var associaRequisitoAoCasoDeUso = function (selected) {
        if (selected == null) {
            throw new Error('Parametro Selecionado invalido');
        }
        var jsonData = getRequisitosAssociados();
        var index = findJsonItemValue(selected);
        if (index >= 0) {
            return;
        }
        jsonData.push(selected);
        setRequisitosAssociados(jsonData);
    }

    /**
     * Dado um requisito, o remove do hidden onde são armazenados os requisitos 
     * associados ao caso de uso
     * @param {} deselected O requisito desassociado
     * @returns {} 
     */
    var removeRequisitoDoCasoDeUso = function (deselected) {
        if (deselected == null) {
            throw new Error('Parametro Selecionado invalido');
        }
        var jsonData = getRequisitosAssociados();
        var index = findJsonItemValue(jsonData, deselected);
        if (index < 0) {
            return;
        }
        jsonData.splice(index, 1);
        setRequisitosAssociados(jsonData);
    }

    /**
     * Processa alterações na seleção do dropDownChosen
     * @param {} event Um Javascript event
     * @param {} params Os parâmetros enviados para o evento
     * @returns {} 
     */
    var dropDownChosenRequisitosOnChange = function (event, params) {
        if (params == null) {
            return;
        }
        if (params.selected != null) {
            associaRequisitoAoCasoDeUso(params.selected);
            return;
        }

        if (params.deselected != null) {
            removeRequisitoDoCasoDeUso(params.deselected);
            return;
        }

        throw new Error('Ocorreu um erro ao tratar o retorno do chosen. Parâmetro inválido');
    };

    /**
     * Monta o DropDownChosen para a associação de Requisitos x Casos de Uso
     * @returns {} 
     */
    var montaDropDownChosenRequisitos = function () {
        $('#DropDownListRequisitos').chosen()
            .change(function(event, params) {
                dropDownChosenRequisitosOnChange(event, params);
            });
    };

    return {
        LoadCreateFormCallback: function () {
            montaDropDownChosenRequisitos();
        }
    };
})();