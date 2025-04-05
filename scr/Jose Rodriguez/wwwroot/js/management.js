document.addEventListener('DOMContentLoaded', function () {
    const today = new Date();
    let currentMonth = today.getMonth();
    let currentYear = today.getFullYear();
    let selectedDate = null;
    let selectedPatientId = null;

    const calendarGrid = document.getElementById('calendar-grid');
    const currentMonthElement = document.getElementById('current-month');
    const prevMonthButton = document.getElementById('prev-month');
    const nextMonthButton = document.getElementById('next-month');
    const selectedDateInfo = document.getElementById('selected-date-info');
    const timeSlotsGrid = document.getElementById('time-slots-grid');
    const patientDropdown = document.getElementById('patient-dropdown');
    const patientOptions = document.getElementById('patient-options');
    const selectedPatientText = document.getElementById('selected-patient-text');
    const patientForm = document.getElementById('patient-form');
    const noPatientSelected = document.getElementById('no-patient-selected');
    const saveBtn = document.getElementById('save-btn');
    const editBtn = document.getElementById('edit-btn');
    const deleteBtn = document.getElementById('delete-btn');

    const monthNames = [
        'Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho',
        'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'
    ];

    generateCalendar(currentMonth, currentYear);
    hidePatientForm();

    function generateCalendar(month, year) {
        calendarGrid.innerHTML = '';
        currentMonthElement.textContent = `${monthNames[month]} ${year}`;

        const firstDay = new Date(year, month, 1);
        const lastDay = new Date(year, month + 1, 0);
        const firstDayIndex = firstDay.getDay();
        const prevMonthLastDay = new Date(year, month, 0).getDate();

        for (let i = firstDayIndex - 1; i >= 0; i--) {
            const dayElement = document.createElement('div');
            dayElement.textContent = prevMonthLastDay - i;
            dayElement.classList.add('calendar-day', 'inactive');
            calendarGrid.appendChild(dayElement);
        }

        for (let day = 1; day <= lastDay.getDate(); day++) {
            const dayElement = document.createElement('div');
            dayElement.textContent = day;
            dayElement.classList.add('calendar-day');

            const dateObj = new Date(year, month, day);
            const dateString = formatDate(dateObj);
            dayElement.dataset.date = dateString;

            dayElement.addEventListener('click', function () {
                document.querySelectorAll('.calendar-day').forEach(d => d.classList.remove('selected'));
                this.classList.add('selected');
                selectedDate = this.dataset.date;
                fetchAppointmentsForDate(selectedDate);
            });

            calendarGrid.appendChild(dayElement);
        }

        const daysAfterMonthEnd = 42 - (firstDayIndex + lastDay.getDate());
        for (let i = 1; i <= daysAfterMonthEnd; i++) {
            const dayElement = document.createElement('div');
            dayElement.textContent = i;
            dayElement.classList.add('calendar-day', 'inactive');
            calendarGrid.appendChild(dayElement);
        }
    }

    function formatDate(date) {
        const year = date.getFullYear();
        const month = String(date.getMonth() + 1).padStart(2, '0');
        const day = String(date.getDate()).padStart(2, '0');
        return `${year}-${month}-${day}`;
    }

    function formatDisplayDate(dateString) {
        const [year, month, day] = dateString.split('-');
        return `${day}/${month}/${year}`;
    }

    function fetchAppointmentsForDate(date) {
        selectedDateInfo.textContent = `Data: ${formatDisplayDate(date)}`;
        resetPatientSelection();

        fetch(`/Patient/GetByDate?date=${selectedDate}`)
            .then(response => response.json())
            .then(appointments => {
                populatePatientDropdown(appointments);
                populateTimeSlots(appointments);
            })
            .catch(error => {
                console.error('Erro ao buscar agendamentos:', error);
            });
    }

    function populatePatientDropdown(patients) {
        patientOptions.innerHTML = '';

        if (patients.length === 0) {
            const noPatients = document.createElement('div');
            noPatients.textContent = 'Nenhum paciente agendado para esta data';
            noPatients.classList.add('patient-option');
            patientOptions.appendChild(noPatients);
            return;
        }

        patients.forEach(patient => {
            const option = document.createElement('div');
            option.textContent = `${patient.name} - ${patient.time}`;
            option.classList.add('patient-option');
            option.dataset.id = patient.id;
            option.addEventListener('click', function () {
                selectedPatientId = this.dataset.id;
                selectedPatientText.textContent = this.textContent;
                patientOptions.classList.remove('show');
                fetchPatientDetails(selectedPatientId);
            });
            patientOptions.appendChild(option);
        });
    }

    function populateTimeSlots(appointments) {
        timeSlotsGrid.innerHTML = '';

        if (appointments.length === 0) {
            const noAppointments = document.createElement('div');
            noAppointments.textContent = 'Nenhum agendamento para esta data';
            noAppointments.style.gridColumn = '1 / -1';
            noAppointments.style.textAlign = 'center';
            noAppointments.style.padding = '10px';
            timeSlotsGrid.appendChild(noAppointments);
            return;
        }

        appointments.forEach(appointment => {
            const timeSlot = document.createElement('div');
            timeSlot.textContent = `${appointment.time} - ${appointment.name}`;
            timeSlot.classList.add('time-slot');
            timeSlot.dataset.id = appointment.id;
            timeSlot.addEventListener('click', function () {
                document.querySelectorAll('.time-slot').forEach(s => s.classList.remove('selected'));
                this.classList.add('selected');
                selectedPatientId = this.dataset.id;
                selectedPatientText.textContent = this.textContent;
                fetchPatientDetails(selectedPatientId);
            });
            timeSlotsGrid.appendChild(timeSlot);
        });
    }

    function fetchPatientDetails(patientId) {
        fetch(`/Patient/GetPatientDetails?id=${patientId}`)
            .then(response => {
                if (!response.ok) throw new Error('Erro ao buscar detalhes.');
                return response.json();
            })
            .then(patient => {
                populatePatientForm(patient);
            })
            .catch(error => {
                console.error('Erro ao buscar detalhes do paciente:', error);
                alert('Erro ao buscar detalhes do paciente.');
            });
    }

    function populatePatientForm(patient) {
        document.getElementById('PatientID').value = patient.id;
        document.getElementById('Name').value = patient.name;
        document.getElementById('Address').value = patient.address;
        document.getElementById('Email').value = patient.email;
        document.getElementById('Phone').value = patient.phone;
        document.getElementById('Procedure').value = patient.specialty;
        document.getElementById('Complaint').value = patient.complaint;

        patientForm.style.display = 'block';
        noPatientSelected.style.display = 'none';

        setFormReadOnly(true);
    }

    function resetPatientSelection() {
        selectedPatientId = null;
        selectedPatientText.textContent = 'Paciente';
        hidePatientForm();
    }

    function hidePatientForm() {
        patientForm.style.display = 'none';
        noPatientSelected.style.display = 'block';
    }

    function setFormReadOnly(isReadOnly) {
        const formElements = patientForm.querySelectorAll('input, textarea');
        formElements.forEach(el => {
            el.readOnly = isReadOnly;
            el.style.opacity = isReadOnly ? '0.8' : '1';
        });
        saveBtn.style.display = isReadOnly ? 'none' : 'block';
        editBtn.style.display = isReadOnly ? 'block' : 'none';
    }

    prevMonthButton.addEventListener('click', function () {
        currentMonth--;
        if (currentMonth < 0) {
            currentMonth = 11;
            currentYear--;
        }
        generateCalendar(currentMonth, currentYear);
        resetPatientSelection();
    });

    nextMonthButton.addEventListener('click', function () {
        currentMonth++;
        if (currentMonth > 11) {
            currentMonth = 0;
            currentYear++;
        }
        generateCalendar(currentMonth, currentYear);
        resetPatientSelection();
    });

    patientDropdown.addEventListener('click', function () {
        patientOptions.classList.toggle('show');
    });

    document.addEventListener('click', function (event) {
        if (!patientDropdown.contains(event.target) && !patientOptions.contains(event.target)) {
            patientOptions.classList.remove('show');
        }
    });

    function showToast(message, type = 'success') {
        const toast = document.createElement('div');
        toast.className = `toast-message ${type}`;
        toast.textContent = message;
        toast.style.padding = '10px 20px';
        toast.style.marginBottom = '10px';
        toast.style.borderRadius = '8px';
        toast.style.backgroundColor = type === 'success' ? '#28a745' : '#dc3545';
        toast.style.color = 'white';
        toast.style.fontSize = '14px';
        toast.style.boxShadow = '0 2px 6px rgba(0,0,0,0.2)';
        toast.style.opacity = '0.95';
        toast.style.transition = 'opacity 0.5s ease';
        toast.style.position = 'fixed';
        toast.style.top = '20px';
        toast.style.right = '20px';
        toast.style.zIndex = '9999';

        document.body.appendChild(toast);

        setTimeout(() => {
            toast.style.opacity = '0';
            setTimeout(() => toast.remove(), 500);
        }, 3000);
    }

    saveBtn.addEventListener('click', function () {
        if (!selectedPatientId) {
            showToast('Selecione um paciente primeiro.', 'error');
            return;
        }

        const formData = new FormData(patientForm);
        const patientData = Object.fromEntries(formData.entries());

        fetch(`/Patient/Update`, {
            method: 'POST',
            headers: {
                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(patientData)
        })
            .then(response => response.json())
            .then(result => {
                if (result.success) {
                    showToast('Paciente atualizado com sucesso!');
                    setFormReadOnly(true);
                    fetchAppointmentsForDate(selectedDate);
                } else {
                    showToast(result.message || 'Erro ao salvar paciente.', 'error');
                }
            })
            .catch(error => {
                console.error('Erro ao salvar:', error);
                showToast('Erro na comunicação com o servidor.', 'error');
            });
    });

    editBtn.addEventListener('click', function () {
        if (!selectedPatientId) {
            showToast('Selecione um paciente primeiro.', 'error');
            return;
        }
        setFormReadOnly(false);
    });

    deleteBtn.addEventListener('click', function () {
        if (!selectedPatientId) {
            showToast('Selecione um paciente primeiro.', 'error');
            return;
        }

        if (confirm('Tem certeza que deseja excluir este agendamento?')) {
            fetch(`/Patient/DeleteAjax/${selectedPatientId}`, {
                method: 'POST',
                headers: {
                    'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
                }
            })
                .then(response => response.json())
                .then(result => {
                    if (result.success) {
                        showToast('Agendamento excluído com sucesso!');
                        resetPatientSelection();
                        fetchAppointmentsForDate(selectedDate);
                    } else {
                        showToast(result.message || 'Erro ao excluir paciente.', 'error');
                    }
                })
                .catch(error => {
                    console.error('Erro ao excluir:', error);
                    showToast('Erro na comunicação com o servidor.', 'error');
                });
        }
    });
});
