# 🌐 Conhecendo a Arquitetura

## 1. Como a Web funciona no contexto de microsserviços?  
A Web funciona como um sistema cliente-servidor, onde um navegador envia requisições HTTP para servidores que respondem com recursos (HTML, JSON, etc.). Na arquitetura de microsserviços, essa interação é dividida em serviços menores, cada um responsável por uma funcionalidade específica, permitindo escalabilidade e manutenção mais fácil.  

## 2. Desvantagens das arquiteturas monolíticas  
Duas desvantagens das arquiteturas monolíticas incluem a dificuldade em implantar mudanças rapidamente e a vulnerabilidade a falhas. Microsserviços resolvem isso ao permitir implantações independentes e isolamento de falhas.

## 3. O que são microsserviços?  
Microsserviços dividem uma aplicação em pequenos serviços independentes, cada um com uma responsabilidade específica e comunicação via APIs. Eles permitem escalabilidade e atualizações independentes, garantindo flexibilidade e resiliência.

## 4. Vantagens e desvantagens dos microsserviços  
As vantagens incluem flexibilidade para utilizar diferentes tecnologias e escalabilidade independente. As desvantagens incluem a maior complexidade na infraestrutura e a dificuldade de depuração.

## 5. Tipos de serviços em uma arquitetura de microsserviços  
Os serviços principais são:  
- **Data Services**: Integram os dados de forma consistente.  
- **Business Services**: Executam operações complexas de negócios.  
- **Translation Services**: Conectam recursos externos.  
- **Edge Services**: Otimizam a entrega para diferentes clientes (web, mobile).

---

# 🧩 Separando Serviços

## 1. O que são serviços de domínio?  
Serviços de domínio encapsulam a lógica de negócios, facilitando a modelagem clara e a gestão da complexidade no Domain-Driven Design (DDD).  

## 2. Por que dividir uma aplicação monolítica em serviços de negócio?  
Dividir uma aplicação monolítica facilita a modularidade e a gestão de operações complexas, sem expor detalhes desnecessários.

## 3. Padrão Strangler  
O Strangler Pattern ajuda na transição gradual de monolitos para microsserviços, migrando partes do sistema para serviços independentes.

## 4. Padrão Sidecar  
O Sidecar permite compartilhar funcionalidades comuns entre serviços, como autenticação e logs, facilitando manutenção e atualização.

## 5. Desafios ao quebrar um monolito em microsserviços  
Os desafios incluem a gestão da complexidade e a consistência dos dados. O Strangler Pattern pode ajudar a minimizar riscos e tornar a transição mais suave.

---

# 🔄 Integrando Serviços

## 1. O que é um API Gateway?  
Um API Gateway é o ponto de entrada central para microsserviços, simplificando autenticação, roteamento e monitoramento.

## 2. Agregador de processos  
O agregador de processos coordena múltiplos serviços em uma única operação, filtrando e combinando dados para simplificar a comunicação.

## 3. Edge Pattern  
O Edge Pattern adapta respostas e dados conforme as necessidades de diferentes usuários ou dispositivos, otimizando a experiência do cliente.

## 4. Cenários ideais para API Gateway  
Use um API Gateway para autenticação e simplificação de acesso externo. Para interações internas com baixa latência, opte pela comunicação direta entre serviços.

## 5. Desafios de um API Gateway  
Os principais desafios incluem o ponto único de falha e a latência, que podem ser mitigados com caching e automação.

---

# 🗃 Lidando com Dados

## 1. Por que cada serviço deve ter seu próprio banco de dados?  
Cada serviço deve ter seu próprio banco de dados para garantir independência, escalabilidade e resiliência, otimizando a performance.

## 2. Padrão CQRS  
O CQRS separa responsabilidades de leitura e escrita, otimizando operações e facilitando a escalabilidade.

## 3. Vantagens e desafios de diferentes bancos de dados  
**Vantagens**: Escolha da tecnologia mais adequada para cada serviço.  
**Desafios**: Complexidade na sincronização e transações distribuídas.

## 4. Eventos assíncronos  
Eventos assíncronos garantem comunicação entre serviços sem comprometer a performance, desacoplando processos e lidando com picos de demanda.

## 5. Cuidados ao implementar eventos assíncronos  
Garantia de entrega, gestão de falhas e monitoramento adequado são essenciais para assegurar a integridade dos eventos.

---

# 🔧 Operações

## 1. Importância dos logs  
Logs monitoram erros, desempenho e rastreiam chamadas entre serviços, facilitando a depuração e o entendimento das interações.

## 2. Stack trace em microsserviços  
Trace IDs permitem rastrear chamadas em múltiplos microsserviços, reconstruindo a sequência de operações para depuração eficiente.

## 3. Agregação de métricas  
Agregação de métricas melhora a observabilidade, permitindo identificar gargalos, otimizar recursos e prever problemas.

## 4. Desafios dos logs distribuídos  
Padronização e correlação de logs são essenciais para rastrear eventos, sem impactar a performance do sistema.

## 5. Coleta de métricas sem comprometer desempenho  
Soluções assíncronas e buffers ajudam a garantir que a coleta de métricas e logs não afete o desempenho dos microsserviços.
