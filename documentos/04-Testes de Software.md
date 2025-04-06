# Planos de Testes de Software

### Tipo de Teste
- **Sucesso**: Tem o objetivo de verificar se as funcionalidades funcionam corretamente.
- **Insucesso**: Tem o objetivo de verificar se o sistema trata erros de maneira correta.

#### Caso de Teste de Sucesso
<table>
  <tr>
    <th colspan="2" width="1000">CT-001<br>Agendamento do paciente com dados válidos</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se é possível cadastrar um paciente corretamente.</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Arthur Oliveira Santos</td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Sucesso</td>
  </tr> 
  <tr>
    <td><strong>Requisitos associados</strong></td>
    <td>RF-02, RF-03, RF-09</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Acessar a página "Cadastrar Pacientes/Agendamento".<br>
      2. Preencher todos os campos obrigatórios.<br>
      3. Clicar no botão "Confirmar".<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>Nome:</strong> John Doe Marsh <br>
      - <strong>Data de Nascimento:</strong> 11/11/2000 <br>
      - <strong>Endereço:</strong> Rua A <br>
      - <strong>E-mail:</strong> john@gmail.com <br>
      - <strong>Telefone:</strong> 12345678910 <br>
      - <strong>Descrição:</strong> Dentes prestes a cair. <br>
      - <strong>Procedimento:</strong> ProteseDentaria
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>O paciente é salvo no banco de dados e aparece na página de gerenciamento.</td>
  </tr>
</table>

#### Caso de Teste de Insucesso

<table>
  <tr>
    <th colspan="2" width="1000">CT-002<br>Agendamento do paciente com dados inválidos</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se o sistema impede o cadastro quando campos obrigatórios estão vazios.</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Arthur Oliveira Santos</td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Insucesso</td>
  </tr> 
  <tr>
    <td><strong>Requisitos associados</strong></td>
    <td>RF-02, RF-03, RF-09</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Acessar a página "Cadastrar Pacientes/Agendamento".<br>
      2. Deixar os campos obrigatórios vazios.<br>
      3. Clicar no botão "Confirmar".<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>Campos vazios.<br>
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>O sistema exibe mensagens de erro e não permite finalizar o agendamento.</td>
  </tr>
</table>

#### Caso de Teste de Sucesso
<table>
  <tr>
    <th colspan="2" width="1000">CT-003<br>Editar paciente com dados válidos</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se é possível editar corretamente os dados de um paciente.</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Arthur Oliveira Santos</td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Sucesso</td>
  </tr> 
  <tr>
    <td><strong>Requisitos associados</strong></td>
    <td>RF-09</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Acessar a página de edição de um paciente.<br>
      2. Alterar os dados desejados.<br>
      3. Clicar em "Salvar Alterações".<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - Email anterior: john@gmail.com<br>
      - Novo email: johnDoeMarsh@gmail.com
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>Os dados são atualizados corretamente.</td>
  </tr>
</table>

# Evidências de Testes de Software

<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br>Agendamento do paciente com dados válidos</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O paciente é salvo no banco de dados e aparece na página de gerenciamento.</td>
  </tr>
    <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Peterson Alves Gervazio </td>
     <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">05/04/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema está agendando e cadastrando o paciente corretamente.</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e5-proj-empext-t3-dr-joserodriguez/blob/main/documentos/img/dados-validos.png"></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e5-proj-empext-t3-dr-joserodriguez/blob/main/documentos/img/mensagem-valida.png"></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/fb3a20eb-95cc-44ff-8a5d-85bf0326de50"></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/9030c6e4-5d93-477b-af3a-681611ca900c"></td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="6" width="1000">CT-002<br>Agendamento do paciente com dados inválidos</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema exibe mensagens de erro e não permite finalizar o agendamento</td>
  </tr>
    <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Peterson Alves Gervazio </td>
     <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">05/04/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema não permite o cadastro corretamente.</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e5-proj-empext-t3-dr-joserodriguez/blob/main/documentos/img/dados-invalidos.png"></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2025-1-e5-proj-empext-t3-dr-joserodriguez/blob/main/documentos/img/campos-vazios.png"></td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="6" width="1000">CT-003<br>Editar paciente com dados válidos</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">Os dados são atualizados corretamente.</td>
  </tr>
    <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Arthur Oliveira Santos</td>
     <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">06/04/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema editou corretamente.</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
   <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/f750689a-c181-4bc4-b54d-b11517b5704a"></td>
  </tr>
   <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/1e57750c-524c-4742-8747-a7af6c179372"></td>
  </tr>
    <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/cc744dc5-0d05-4314-b04b-4e7a36d0838d"></td>
  </tr>


</table>

## Parte 2 - Testes por pares
A fim de aumentar a qualidade da aplicação desenvolvida, cada funcionalidade deve ser testada por um colega e os testes devem ser evidenciados. O colega "Tester" deve utilizar o caso de teste criado pelo desenvolvedor responsável pela funcionalidade (desenvolveu a funcionalidade e criou o caso de testes descrito no plano de testes).

### Exemplo
<table>
  <tr>
    <th colspan="6" width="1000">CT-001<br>Login com credenciais válidas</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O sistema deve redirecionar o usuário para a página inicial do aplicativo após o login bem-sucedido.</td>
  </tr>
    <tr>
    <td><strong>Responsável pela funcionalidade</strong></td>
    <td width="430">José da Silva </td>
      <td><strong>Responsável pelo teste</strong></td>
    <td width="430">Maria Oliveira </td>
     <td width="100"><strong>Data do teste</strong></td>
    <td width="150">08/05/2024</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema está permitindo o login corretamente.</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><video src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e5-proj-time-sheet/assets/82043220/2e3c1722-7adc-4bd4-8b4c-3abe9ddc1b48"/></td>
  </tr>
</table>



