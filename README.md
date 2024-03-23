# Prometheus-Grafana
## Tecnologias e conceitos aprendidos
### Observabilidade
Observabilidade refere-se à capacidade de entender o estado interno de um sistema com base em suas saídas externas. Em um sistema distribuído, onde múltiplos componentes interagem para fornecer um serviço, a observabilidade é crucial para entender e depurar o comportamento do sistema como um todo. Isso envolve monitorar métricas de desempenho, rastrear solicitações através dos diferentes serviços, analisar logs e capturar eventos relevantes. Portanto, a observabilidade permite entender o que está acontecendo dentro de um sistema, identificar problemas, diagnosticar falhas e otimizar o desempenho.

### OpenTelemetry:
O OpenTelemetry é um conjunto de ferramentas, APIs e padrões para observabilidade em sistemas distribuídos. Nesse sentido, ele fornece instrumentação para coletar dados de rastreamento distribuído, métricas e logs de aplicativos e serviços em execução em ambientes distribuídos, como microsserviços, contêineres e ambientes de nuvem. O OpenTelemetry é projetado para ser interoperável, extensível e oferece suporte a várias linguagens de programação e sistemas de execução.

### Prometheus:
O Prometheus é um sistema de monitoramento e alerta de código aberto, projetado para coletar, armazenar e consultar métricas de sistemas distribuídos. Ele coleta métricas de alvos configurados, como aplicativos e serviços, usando um modelo de coleta de pull. As métricas são armazenadas em um banco de dados de séries temporais, onde podem ser consultadas e analisadas usando a linguagem de consulta Prometheus (PromQL). Além disso, o Prometheus também suporta alertas baseados em regras definidas pelo usuário.

### Grafana:
O Grafana é uma plataforma de análise e visualização de métricas de código aberto, que funciona bem com Prometheus e outros bancos de dados de séries temporais. Ele permite criar dashboards interativos e personalizados para monitorar e analisar métricas de sistemas distribuídos. Grafana oferece uma variedade de painéis e gráficos predefinidos, além de recursos avançados de personalização para criar visualizações informativas e esteticamente agradáveis.

### Rastreamento Distribuído:
Rastreamento distribuído é uma técnica de monitoramento que permite rastrear o fluxo de uma solicitação em um sistema distribuído composto por vários componentes interconectados. Cada componente registra informações sobre a solicitação à medida que ela passa por ele, incluindo tempo de execução, dependências externas, erros e metadados relevantes. Esses dados de rastreamento são agregados e correlacionados para fornecer insights sobre o desempenho e o comportamento do sistema como um todo.

### Jaeger:
O Jaeger é uma ferramenta de rastreamento distribuído de código aberto, usada para monitorar e diagnosticar solicitações em sistemas distribuídos complexos. Ele coleta e armazena dados de rastreamento de várias fontes e fornece uma interface de usuário intuitiva para visualizar e analisar o fluxo de solicitações através dos diferentes componentes do sistema. Além disso, o Jaeger é altamente escalável e suporta recursos avançados, como análise de dependências, análise de latência e correlação de logs e pode ser integrado com o OpenTelemetry e outras tecnologias de observabilidade para oferecer uma solução completa de rastreamento distribuído.

## Relatório
Criei um projeto de API Web ASP.NET Core Vazio no Rider e adicionei a definiçãao de métricas(greetings.count) e fonte de atividade(OtPrGRYa.Example) no código. Além disso, excluí todo o código que vem com o templatep padrão, incluindo a definição do ponto de extremidade de API WeatherForecast e todo o código que o envolvia.

Em seguida, criei um ponto de extremidade de API para enviar saudações(greetings), onde métricas e atividades são registradas e referenciei os pacotes do OpenTelemetry para permitir a exportação de métricas e rastreamento, alguns em versões superiores ao do artigo devido a "descontinuação" das versões antigas de alguns deles.

Nesse sentido, o OpenTelemetry foi configurado para capturar métricas e rastreamento, com exportadores para Prometheus e Jaeger que foram integrados posteriormente.

Considerando a portabilidade e consistência e isolamento de ambiente, criei um arquivo `docker-compose.yml` para configurar e executar os serviços do Prometheus, Grafana e Jaeger de forma contêinerizada.

### Execução
Primeiramente rodei a aplicação localmente e executei o comando `docker-compose up` no diretório `OpenTelemetryProject`. Depois disso abri o Prometheus na porta padrão(9090) para checar se a conexão com a aplicação tinha sido bem sucedida.

<img src="https://github.com/vict0rcarvalh0/Prometheus-Grafana/blob/main/assets/img1.png">

Em seguida, executei o endpoint de "Greetings" algumas vezes pelo Swagger e verifiquei o gráfico de contagem no Prometheus.

<img src="https://github.com/vict0rcarvalh0/Prometheus-Grafana/blob/main/assets/img2.png">
<img src="https://github.com/vict0rcarvalh0/Prometheus-Grafana/blob/main/assets/img3.png">

Após a etapa anterior, abri o Grafana na porta padrão(3000) para criar o dashboard de métricas alimentado pelo Prometheus.

<img src="https://github.com/vict0rcarvalh0/Prometheus-Grafana/blob/main/assets/img4.png">
<img src="https://github.com/vict0rcarvalh0/Prometheus-Grafana/blob/main/assets/img5.png">
<img src="https://github.com/vict0rcarvalh0/Prometheus-Grafana/blob/main/assets/img6.png">
<img src="https://github.com/vict0rcarvalh0/Prometheus-Grafana/blob/main/assets/img7.png">

Com o dashboard criado, a última etapa foi de configurar o Jaeger para coletar e visualizar informações de rastreamento distribuído. Nesse sentido, abri ele na porta padrão(16686) para que essa configuração fosse executada.

<img src="https://github.com/vict0rcarvalh0/Prometheus-Grafana/blob/main/assets/img8.png">
<img src="https://github.com/vict0rcarvalh0/Prometheus-Grafana/blob/main/assets/img9.png">
