# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="01-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. 

## Usuários
| Tipo de Usuário   | Descrição | Responsabilidades |
|------------------|-----------|------------------|
| **xxx** | xxxxx | xxxxx |

### Exemplo

| Tipo de Usuário   | Descrição | Responsabilidades |
|------------------|-----------|------------------|
| **Administrador** | Gerencia a aplicação e os usuários. | Gerenciar usuários, configurar o sistema, acessar todos os relatórios. |
| **Funcionário** | Usa a aplicação para suas tarefas principais. | Criar e editar registros, visualizar relatórios. |


## Arquitetura e Tecnologias

Descreva brevemente a arquitetura definida para o projeto e as tecnologias a serem utilizadas. Sugere-se a criação de um diagrama de componentes da solução.

## Project Model Canvas

https://github.com/orgs/ICEI-PUC-Minas-PMV-ADS/projects/1623/views/1)](https://www.canva.com/design/DAGf2pQd5S0/E1quqrSFAMirmc2RtQ2mAg/view?utm_content=DAGf2pQd5S0&utm_campaign=designshare&utm_medium=link2&utm_source=uniquelinks&utlId=h67e89b4645
![Project Model Canvas ](img/canvas.png)
> **Links Úteis**:
> Disponíveis em material de apoio do projeto

## Requisitos

| **ID** | **Requisito Funcionais**                      | **Prioridade** | **Descrição**                                                                                     |
|--------|-----------------------------------|----------------|-------------------------------------------------------------------------------------------------|
| RF-01 | Acesso rápido às informações de contato da clínica.| ALTA | Telefone, Endereço. |
| RF-02 | Consultar informações sobre a clínica e os profissionais.| ALTA| história, serviços oferecidos e casos clínicos. |
| RF-03 | Automação do agendamento de consultas online, permitindo que o cliente escolha horários disponíveis sem a necessidade de intervenção da recepção. | ALTA |   |
| RF-04 | Geração de relatório de agenda quinzenal com consultas agendadas e canceladas. | ALTA |  |
| RF-05 | Um painel administrativo simples para gerenciar os agendamentos. | ALTA |  |
| RF-06 | Envio de e-mail de confirmação para o cliente um ou dois dias antes de uma consulta. | ALTA | |
| RF-07 | Envio de e-mail para a recepção caso o cliente cancele a consulta. | ALTA | |
| RF-08 | Sistema de recuperação e alteração de senha. | MÉDIA | |
| RF-09 | Níveis de acesso e permissões| MÉDIA |  |
| RF-10 | Cadastro de pacientes| ALTA |  |
| RF-11 | Cadastro de dentistas / recepcionistas| BAIXA |  |




| **ID** | **Requisito Não Funcionais**                      | **Prioridade** | **Descrição**                                                                                     |
|--------|-----------------------------------|----------------|-------------------------------------------------------------------------------------------------|
| RF-01 | Lançamento de dados na agenda para garantir que o agendamento ocorra sem erros. | ALTA | |
| RF-02 | Conformidade com a LGPD para garantir a proteção de dados dos clientes.| ALTA | |
| RF-03 | Responsividade, para garantir acesso em dispositivos móveis e computadores.| ALTA | |
| RF-04 | O sistema deve estar disponível em horário comercial com um tempo de resposta inferior a 4 segundos.| ALTA | |
| RF-05 | O site deve estar disponível em Português e Inglês. | ALTA | |
| RF-06 | Usuários: Acesso somente ao site para visualizar informações. | MÉDIA |     |
| RF-06.1 | Clientes: Acesso somente ao site para visualizar informações e realizar agendamentos. | MÉDIA | |
| RF-06.2 | Administrador (Dono da Clínica): Acesso total ao painel administrativo, podendo visualizar, editar e cancelar agendamentos, além de gerenciar conteúdos do site. | ALTA | |
| RF-06.3 | Recepcionistas: Acesso ao painel administrativo para visualizar e gerenciar a agenda, sem permissão para editar conteúdos do site. | ALTA | |



| ID  | Restrição                                             |
|-----|-------------------------------------------------------|
| 01  | O projeto deverá ser entregue em Setembro |

## Diagrama de Caso de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

Para mais informações, consulte o microfundamento Engenharia de Requisitos de Software 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.
 
Para mais informações, consulte o microfundamento "Modelagem de Dados".

