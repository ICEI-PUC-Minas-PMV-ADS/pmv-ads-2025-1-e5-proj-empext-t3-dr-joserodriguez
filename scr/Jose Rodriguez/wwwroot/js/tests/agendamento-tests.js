// ==================== TESTES PARA A PÁGINA DE AGENDAMENTO ====================

// Aguardar o carregamento completo da página
window.addEventListener('load', function () {
    console.log('============ INICIANDO TESTES DE AGENDAMENTO ============');

    // Aguardar um pouco mais para garantir que todos os scripts carregaram
    setTimeout(iniciarTestes, 3000);
});

function iniciarTestes() {
    // Teste 1: Verificar se o calendário está sendo gerado corretamente
    console.log('======= TESTE 1: Verificando geração do calendário =======');
    try {
        const calendarGrid = document.getElementById('calendar-grid');
        if (calendarGrid) {
            const calendarDays = calendarGrid.querySelectorAll('.calendar-day');
            console.log('✅ Calendário encontrado');
            console.log('Total de dias no calendário:', calendarDays.length);
            console.log('Dias ativos:', calendarGrid.querySelectorAll('.calendar-day:not(.inactive)').length);
            console.log('Fim de semana:', calendarGrid.querySelectorAll('.calendar-day.weekend').length);
            console.log('Dias passados:', calendarGrid.querySelectorAll('.calendar-day.past').length);
        } else {
            console.error('❌ Elemento calendar-grid não encontrado!');
        }
    } catch (error) {
        console.error('❌ Erro no teste de calendário:', error);
    }

    // Teste 2: Verificar campos do formulário
    console.log('======= TESTE 2: Verificando campos do formulário =======');
    try {
        const campos = {
            nome: document.querySelector('[name="Name"]') || document.querySelector('[name="Nome"]'),
            email: document.querySelector('[name="Email"]'),
            telefone: document.querySelector('[name="Phone"]') || document.querySelector('[name="Telefone"]'),
            endereco: document.querySelector('[name="Address"]') || document.querySelector('[name="Endereco"]'),
            especialidade: document.querySelector('[name="Especialidade"]') || document.querySelector('[name="SpecialtiesString"]'),
            mensagem: document.querySelector('[name="Mensagem"]') || document.querySelector('[name="Complaint"]')
        };

        for (const [nome, campo] of Object.entries(campos)) {
            if (campo) {
                console.log(`✅ Campo ${nome} encontrado`);
            } else {
                console.log(`❌ Campo ${nome} não encontrado`);
            }
        }
    } catch (error) {
        console.error('❌ Erro no teste de campos:', error);
    }

    // Teste 3: Verificar elementos de seleção de data/hora
    console.log('======= TESTE 3: Verificando elementos de data/hora =======');
    try {
        const elementos = {
            prevMonth: document.getElementById('prev-month'),
            nextMonth: document.getElementById('next-month'),
            currentMonth: document.getElementById('current-month'),
            timeSlots: document.querySelectorAll('.time-slot'),
            dataHoraInput: document.getElementById('DataHora') || document.getElementById('AppointmentDate')
        };

        console.log('Navegação do calendário:');
        console.log('- Botão mês anterior:', !!elementos.prevMonth);
        console.log('- Botão próximo mês:', !!elementos.nextMonth);
        console.log('- Exibição mês atual:', !!elementos.currentMonth);
        console.log('Slots de horário encontrados:', elementos.timeSlots.length);
        console.log('Campo data/hora:', !!elementos.dataHoraInput);
    } catch (error) {
        console.error('❌ Erro no teste de data/hora:', error);
    }

    // Teste 4: Verificar dropdown de especialidades
    console.log('======= TESTE 4: Verificando dropdown de especialidades =======');
    try {
        // Tentar diferentes possíveis estruturas
        const dropdown1 = document.getElementById('specialty-dropdown');
        const dropdown2 = document.getElementById('specialty-display');
        const dropdown3 = document.querySelector('.specialty-select');

        const options1 = document.getElementById('specialty-options');
        const options2 = document.querySelectorAll('.specialty-option');

        console.log('Dropdown encontrado (método 1):', !!dropdown1);
        console.log('Dropdown encontrado (método 2):', !!dropdown2);
        console.log('Dropdown encontrado (método 3):', !!dropdown3);
        console.log('Opções encontradas:', options2.length);

        if (dropdown1 || dropdown2 || dropdown3) {
            console.log('✅ Estrutura de dropdown encontrada');
        } else {
            console.log('❌ Estrutura de dropdown não encontrada');
        }
    } catch (error) {
        console.error('❌ Erro no teste de dropdown:', error);
    }

    // Teste 5: Verificar botão de envio
    console.log('======= TESTE 5: Verificando botão de envio =======');
    try {
        const submitButton = document.querySelector('button[type="submit"]') ||
            document.querySelector('.submit-btn') ||
            document.querySelector('.btn-primary');

        if (submitButton) {
            console.log('✅ Botão de envio encontrado');
            console.log('Texto do botão:', submitButton.textContent);
        } else {
            console.log('❌ Botão de envio não encontrado');
        }
    } catch (error) {
        console.error('❌ Erro no teste de botão:', error);
    }

    console.log('============ TESTES CONCLUÍDOS ============');
}

// Funções auxiliares para testes manuais
window.testesAgendamento = {
    verificarElementos: function () {
        console.log('=== Verificação Manual de Elementos ===');

        // Lista todos os IDs na página
        const todosIds = Array.from(document.querySelectorAll('[id]')).map(el => el.id);
        console.log('IDs encontrados na página:', todosIds);

        // Lista todas as classes
        const todasClasses = Array.from(new Set(
            Array.from(document.querySelectorAll('[class]'))
                .flatMap(el => Array.from(el.classList))
        ));
        console.log('Classes encontradas na página:', todasClasses);

        // Lista todos os campos de formulário
        const campos = Array.from(document.querySelectorAll('input, select, textarea'));
        console.log('Campos de formulário:', campos.map(c => ({
            name: c.name,
            id: c.id,
            type: c.type,
            value: c.value
        })));
    },

    executarTodos: iniciarTestes
};

console.log('💡 Use window.testesAgendamento.verificarElementos() para listar todos os elementos');
console.log('💡 Use window.testesAgendamento.executarTodos() para executar todos os testes');