# Prometheus-Grafana
## Tecnologia e conceitos aprendidos


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
