// ==================== TESTES PARA A PÁGINA DE GERENCIAMENTO ====================

// Teste 6: Verificar se o calendário de gerenciamento está funcionando
console.log('======= TESTE 6: Verificando calendário de gerenciamento =======');
function testarCalendarioGerenciamento() {
    const calendarGrid = document.getElementById('calendar-grid');
    const prevMonth = document.getElementById('prev-month');
    const nextMonth = document.getElementById('next-month');
    const currentMonth = document.getElementById('current-month');

    console.log('Elementos do calendário presentes?');
    console.log('Grid:', !!calendarGrid);
    console.log('Botão mês anterior:', !!prevMonth);
    console.log('Botão próximo mês:', !!nextMonth);
    console.log('Mês atual:', currentMonth ? currentMonth.textContent : 'não encontrado');

    // Testar navegação
    if (nextMonth) {
        nextMonth.click();
        console.log('Navegou para o próximo mês:', currentMonth.textContent);
    }

    if (prevMonth) {
        prevMonth.click();
        console.log('Voltou para o mês anterior:', currentMonth.textContent);
    }
}

// Teste 7: Testar seleção de data e carregamento de pacientes
console.log('======= TESTE 7: Testando seleção de data e carregamento de pacientes =======');
function testarSelecaoPacientes() {
    const diasCalendario = document.querySelectorAll('.calendar-day:not(.inactive)');

    // Simular clique em um dia
    if (diasCalendario.length > 0) {
        const dia = diasCalendario[0];
        dia.click();

        console.log('Dia clicado:', dia.textContent);
        console.log('Data selecionada (info):', document.getElementById('selected-date-info').textContent);

        // Verificar se a requisição AJAX seria feita
        // Nota: Em um teste real, você poderia interceptar a chamada AJAX
        console.log('Requisição de pacientes seria feita para esta data');
    }
}

// Teste 8: Testar dropdown de pacientes
console.log('======= TESTE 8: Testando dropdown de pacientes =======');
function testarDropdownPacientes() {
    const patientDropdown = document.getElementById('patient-dropdown');
    const patientOptions = document.getElementById('patient-options');

    // Simular abertura do dropdown
    if (patientDropdown) {
        patientDropdown.click();
        console.log('Dropdown de pacientes aberto?', patientOptions.classList.contains('show'));

        // Simular alguns pacientes
        patientOptions.innerHTML = `
            <div class="patient-option" data-id="1">João Silva - 10:00</div>
            <div class="patient-option" data-id="2">Maria Santos - 11:00</div>
        `;

        // Selecionar um paciente
        const primeiroPatiente = patientOptions.querySelector('.patient-option');
        if (primeiroPatiente) {
            primeiroPatiente.click();
            console.log('Paciente selecionado:', document.getElementById('selected-patient-text').textContent);
            console.log('ID do paciente:', document.getElementById('PatientID').value);
        }
    }
}

// Teste 9: Testar botões de Editar, Salvar e Excluir
console.log('======= TESTE 9: Testando botões de gerenciamento =======');
function testarBotoesGerenciamento() {
    const saveBtn = document.getElementById('save-btn');
    const editBtn = document.getElementById('edit-btn');
    const deleteBtn = document.getElementById('delete-btn');
    const form = document.getElementById('patient-form');

    console.log('Botões presentes?');
    console.log('Salvar:', !!saveBtn);
    console.log('Editar:', !!editBtn);
    console.log('Excluir:', !!deleteBtn);

    // Testar botão editar
    if (editBtn) {
        editBtn.addEventListener('click', function () {
            console.log('Botão Editar clicado - campos devem ficar editáveis');
            const inputs = form.querySelectorAll('input, textarea, select');
            inputs.forEach(input => {
                console.log(`Campo ${input.id}: readonly = ${input.readOnly}`);
            });
        });
    }

    // Testar botão salvar
    if (saveBtn) {
        saveBtn.addEventListener('click', function () {
            console.log('Botão Salvar clicado');
            console.log('Dados para salvar:');
            console.log('ID:', document.getElementById('PatientID').value);
            console.log('Nome:', document.getElementById('Name').value);
            console.log('Email:', document.getElementById('Email').value);
            // ... outros campos
        });
    }

    // Testar botão excluir
    if (deleteBtn) {
        deleteBtn.addEventListener('click', function () {
            console.log('Botão Excluir clicado');
            console.log('ID do paciente a excluir:', document.getElementById('PatientID').value);
        });
    }
}

// Teste 10: Testar sistema de notificação (toast)
console.log('======= TESTE 10: Testando sistema de notificação (toast) =======');
function testarToast() {
    const toastContainer = document.getElementById('toast-container');
    console.log('Container de toast presente?', !!toastContainer);

    // Criar um toast de teste
    if (toastContainer) {
        const toast = document.createElement('div');
        toast.className = 'toast';
        toast.textContent = 'Teste de notificação';
        toast.style.backgroundColor = '#4CAF50';
        toast.style.color = 'white';
        toast.style.padding = '15px';
        toast.style.marginBottom = '10px';
        toast.style.borderRadius = '5px';

        toastContainer.appendChild(toast);
        console.log('Toast de teste criado');

        // Remover após 3 segundos
        setTimeout(() => {
            toast.remove();
            console.log('Toast removido');
        }, 3000);
    }
}

// ==================== EXECUÇÃO DOS TESTES DE GERENCIAMENTO ====================

function executarTestesGerenciamento() {
    console.log('============ INICIANDO TESTES DE GERENCIAMENTO ============');

    setTimeout(() => {
        testarCalendarioGerenciamento();
        testarSelecaoPacientes();
        testarDropdownPacientes();
        testarBotoesGerenciamento();
        testarToast();
    }, 2000);
}

// Executar testes quando a página carregar
window.addEventListener('load', function () {
    console.log('Página de Gerenciamento carregada - Iniciando testes...');
    executarTestesGerenciamento();
});

// ==================== FUNÇÕES AUXILIARES PARA TESTE MANUAL ====================

window.testesGerenciamento = {
    testarCalendarioGerenciamento,
    testarSelecaoPacientes,
    testarDropdownPacientes,
    testarBotoesGerenciamento,
    testarToast,
    executarTodos: executarTestesGerenciamento
};

console.log('💡 Dica: Use window.testesGerenciamento para executar testes individuais');
console.log('Exemplo: window.testesGerenciamento.testarDropdownPacientes()');

