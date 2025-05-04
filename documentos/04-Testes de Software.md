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

#### Caso de Teste de Sucesso
<table>
  <tr>
    <th colspan="2" width="1000">CT-004<br>Deletar paciente.</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se o sistema deleta corretamente um paciente.</td>
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
    <td>RF-09, RF-10</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Acessar a listagem de pacientes.<br>
      2. Clicar no botão "Excluir" de um paciente.<br>
      3. Confirmar a exclusão.<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - paciente: Teste<br>
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>O paciente é removido do sistema e não aparece mais em gerenciamento.</td>
  </tr>
</table>

#### Caso de Teste de Sucesso
<table>
<tr>
    <th colspan="2" width="1000">CT-005<br>Login</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se é possível fazer o login do dentista corretamente.</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Mayra Rodriguez</td>
  </tr>
  <tr>
    <td><strong>Responsável Codigo </strong></td>
    <td width="430">Bianca </td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Sucesso</td>
  </tr> 
  <tr>
    <td><strong>Requisitos associados</strong></td>
    <td>RF-08</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Acessar a página "Login".<br>
      2. Preencher todos os campos obrigatórios.<br>
      3. Clicar no botão "Confirmar".<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>E-mail:</strong> consultoriodontovip@gmail.com<br>
      - <strong>Senha:</strong> odontovipJR294 <br>
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>Login Efetuado com sucesso.</td>
  </tr>
</table>

#### Caso de Teste de Sucesso
<table>
  <tr>
    <th colspan="2" width="1000">CT-006<br>Cancelamento de consulta via e-mail.
    Permitir que o usuário consulte informações sobre a clínica.</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se a mensagem enviada pelo cliente é recebida pelo email da clínica.</td>
  </tr>
  <tr>
    <td><strong>Responsável pelo código</strong></td>
    <td width="430">Arthur Oliveira</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Peterson Alves Gervazio</td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Sucesso</td>
  </tr> 
  <tr>
    <td><strong>Requisitos associados</strong></td>
    <td>RF-01, RF-06</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Acessar a página "Localização".<br>
      2. Preencher todos os campos.<br>
      3. Clicar no botão "Enviar Mensagem".<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>Nome:</strong> Maria Silva <br>
      - <strong>E-mail:</strong> maria.silva@email.com  <br>
      - <strong>Mensagem:</strong> Olá, gostaria de cancelar minha consulta marcada para o dia 05/05/2025 às 14h. Nome: Maria Silva. Motivo: imprevisto profissional. <br>
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>A mensagem é recebida pelo email da clínica.</td>
  </tr>
</table>

#### Caso de Teste de Sucesso
<table>
  <tr>
    <th colspan="2" width="1000">CT-007<br>Tela Home</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se é possível visualizar a Home corretamente.</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Bianca Cristina</td>
  </tr>
 <tr>
    <td><strong>Tipo do Teste</strong></td>
    <td width="430">Sucesso</td>
  </tr> 
  <tr>
    <td><strong>Requisitos associados</strong></td>
    <td>RF-01</td>
  </tr>
  <tr>
    <td><strong>Passos</strong></td>
    <td>
      1. Acessar a página "Home".<br>
      2. Visualizar informações e vídeo sobre a clínica.<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      -
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>A interface está funcionando corretamente.</td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="2" width="1000">CT-008<br>Cadastrar Dentista</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se é possível cadastrar o dentista corretamente.</td>
  </tr>
    <tr>
    <td><strong>Responsável Codigo </strong></td>
    <td width="430">Mayra Rodriguez</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Bianca Cristina</td>
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
      1. Acessar a página "Cadastrar Dentista".<br>
      2. Preencher todos os campos obrigatórios.<br>
      3. Clicar no botão "Criar".<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>Nome:</strong> Claudia Vitoriana <br>
      - <strong>Cédula Profissional:</strong> 1234563 <br>
      - <strong>E-mail:</strong> internet@nos.pt <br>
      - <strong>Telefone:</strong> 913563877 <br>
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>O dentista é salvo no banco de dados e aparece na página de gerenciamento.</td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="2" width="1000">CT-009<br>Editar dados de Dentista</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se é possível editar os dados de dentista corretamente.</td>
  </tr>
    <tr>
    <td><strong>Responsável Codigo </strong></td>
    <td width="430">Mayra Rodriguez</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Bianca Cristina</td>
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
      1. Acessar a página de Listagem de Dentistas.<br>
      2. Clicar no botão "Editar" de algum dentista.<br>
      3. Editar dados necessários.<br>
      3. Clicar no botão "Editar".<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>Telefone Anterior:</strong> 913563877 <br>
      - <strong>Telefone Atualizado:</strong> 91356387 <br>
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>Os dados são editados corretamente.</td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="2" width="1000">CT-010<br>Deletar dados de Dentista</th>
  </tr>
  <tr>
    <td width="150"><strong>Descrição</strong></td>
    <td>Verifica se é possível deletar os dados de dentista corretamente.</td>
  </tr>
    <tr>
    <td><strong>Responsável Codigo </strong></td>
    <td width="430">Mayra Rodriguez</td>
  </tr>
  <tr>
    <td><strong>Responsável Caso de Teste </strong></td>
    <td width="430">Bianca Cristina</td>
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
      1. Acessar a página de Listagem de Dentistas.<br>
      2. Clicar no botão "Deletar" de algum dentista.<br>
      </td>
  </tr>
    <tr>
    <td><strong>Dados de teste</strong></td>
    <td>
      - <strong>Dentista deletado:</strong> Claudia Vitoriana <br>
  </tr>
    <tr>
    <td><strong>Critérios de êxito</strong></td>
    <td>Os dados são deletados corretamente.</td>
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
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/1e75f99d-70eb-4078-9ab3-2c33a63a6e10"></td>
  </tr>
   <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/1e57750c-524c-4742-8747-a7af6c179372"></td>
  </tr>
    <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/cc744dc5-0d05-4314-b04b-4e7a36d0838d"></td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="6" width="1000">CT-004<br>Deletar paciente.</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O paciente é removido do sistema e não aparece mais em gerenciamento.</td>
  </tr>
    <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Arthur Oliveira Santos</td>
     <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">06/04/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema não deletou corretamente.</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
   <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/4e63ad90-a91c-4fef-9379-6d6f9a3cabb0"></td>
  </tr>
   <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/5ce91f6f-ba1d-46e6-9e53-4c196e4621a8"></td>
  </tr>
    <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/b6d92c38-84d6-4970-913f-ec4ca69c4a71"></td>
  </tr>
</table>


## Solução
O problema está na forma como o método DeleteConfirmed está sendo chamado na view Delete.cshtml, em conjunto com o atributo [HttpPost("Delete/{id}")].

[HttpPost("Delete/{id}"), ActionName("Delete")]

![Screenshot 2025-04-05 160738](https://github.com/user-attachments/assets/4162a446-8110-41aa-baf1-038148981ffa)

![Screenshot 2025-04-05 160832](https://github.com/user-attachments/assets/cdd95817-9062-4a70-9695-c25ab61f0305)

Mas no formulário da view Delete.cshtml

form asp-action="Delete" asp-controller="Patient" asp-route-id="@Model.ID" method="post"

![Screenshot 2025-04-05 160655](https://github.com/user-attachments/assets/d888ee66-b942-4dbc-8b4a-244405b4080b)

O que acontece:

O asp-action="Delete" chama a ação com nome Delete, não DeleteConfirmed.

Mas o método com [HttpPost("Delete/{id}")] tem ActionName("Delete"), que espera que o ID seja passado na rota, como parte da URL (/Patient/Delete/1), e não no corpo do formulário.

Agora quando deletamos o paciente, o erro de não encontrar o método/página foi resolvido e o paciente não aparece mais em gerenciamento

![Screenshot 2025-04-06 111559](https://github.com/user-attachments/assets/aefd838d-165e-4289-ae73-7348743e3403)

![Screenshot 2025-04-06 115344](https://github.com/user-attachments/assets/70a9996c-a076-4327-9ee9-37d54b65569d)

<table>
  <tr>
    <th colspan="6" width="1000">CT-005<br>Login.</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O Login ser efetuado</td>
  </tr>
  <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Mayra Rodriguez</td>
    <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">06/04/2025</td>
  </tr>
  <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">Tudo ocorreu como esperado.</td>
  </tr>
  <tr>
    <td><strong>Link do vídeo</strong></td>
    <td colspan="5">
      <a href="https://youtu.be/DuERvaUvUaM" target="_blank">Assistir no YouTube</a>

  </tr>
  
</table>


<table>
  <tr>
    <th colspan="6" width="1000">CT-006<br>Cancelamento de consulta via e-mail.
    Permitir que o usuário consulte informações sobre a clínica.</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">A mensagem é recebida pelo email da clínica.</td>
  </tr>
    <tr>
    <td><strong>Responsável pelo código</strong></td>
    <td width="430">Arthur Oliveira</td>
  </tr>
    <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Peterson Alves Gervazio </td>
    <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">02/05/2025</td>
  </tr>
    <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O sistema está recebendo a mensagem do cliente corretamente.</td>
  </tr>
  <tr>
    <td colspan="6" align="center"><strong>Evidência</strong></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/6e2c0a95-bad7-4cad-837a-587ca6a9151b"></td>
  </tr>
  <tr>
    <td colspan="6" align="center"><img src="https://github.com/user-attachments/assets/cbf09fbe-1f2b-4a55-af3e-3a321ed119cb"></td>
  </tr>
</table>

<table>
  <tr>
    <th colspan="6" width="1000">CT-007<br>Tela Home.</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O Tela Home é visualizada corretamente</td>
  </tr>
  <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Bianca Cristina</td>
    <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">03/05/2025</td>
  </tr>
  <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">A Home está funcionando corretamente.</td>
  </tr>
  <tr>
    <td><strong>Link do vídeo</strong></td>
    <td colspan="5">
      <a href="https://www.youtube.com/watch?v=AqrHyjIp4g0" target="_blank">Assistir no YouTube</a>

  </tr>

<table>
  <tr>
    <th colspan="6" width="1000">CT-008<br>Cadastrar Dentista.</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">O cadastro é realizado corretamente</td>
  </tr>
  <tr>
    <td><strong>Responsável pelo código</strong></td>
    <td width="430">Mayra Rodriguez</td>
  </tr>
  <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Bianca Cristina</td>
    <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">03/05/2025</td>
  </tr>
  <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">O cadastro é feito com sucesso.</td>
  </tr>
  <tr>
    <td><strong>Link do vídeo</strong></td>
    <td colspan="5">
      <a href="https://www.youtube.com/watch?v=ZdyVcvAxkT4" target="_blank">Assistir no YouTube</a>

  </tr>

  <table>
  <tr>
    <th colspan="6" width="1000">CT-009<br>Editar dados de Dentista.</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">A edição é realizada corretamente</td>
  </tr>
  <tr>
    <td><strong>Responsável pelo código</strong></td>
    <td width="430">Mayra Rodriguez</td>
  </tr>
  <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Bianca Cristina</td>
    <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">03/05/2025</td>
  </tr>
  <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">A edição é feita com sucesso.</td>
  </tr>
  <tr>
    <td><strong>Link do vídeo</strong></td>
    <td colspan="5">
      <a href="https://www.youtube.com/watch?v=ZdyVcvAxkT4" target="_blank">Assistir no YouTube</a>

  </tr>

  <table>
  <tr>
    <th colspan="6" width="1000">CT-010<br>Deletar dados de Dentista.</th>
  </tr>
  <tr>
    <td width="170"><strong>Critérios de êxito</strong></td>
    <td colspan="5">Os dados são deletados corretamente</td>
  </tr>
  <tr>
    <td><strong>Responsável pelo código</strong></td>
    <td width="430">Mayra Rodriguez</td>
  </tr>
  <tr>
    <td><strong>Responsável pelo Teste</strong></td>
    <td width="430">Bianca Cristina</td>
    <td width="100"><strong>Data do Teste</strong></td>
    <td width="150">03/05/2025</td>
  </tr>
  <tr>
    <td width="170"><strong>Comentário</strong></td>
    <td colspan="5">Os dados são deletados com sucesso.</td>
  </tr>
  <tr>
    <td><strong>Link do vídeo</strong></td>
    <td colspan="5">
      <a href="https://www.youtube.com/watch?v=ZdyVcvAxkT4" target="_blank">Assistir no YouTube</a>

  </tr>
