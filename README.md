  # CaixeiroViajante
Sistema para resolução do caixeiro Viajantre

## Problema:
  
  Caixeiro Viajante é um problema matemático, mas para explicar o problema trocarei o caixeiro por um caminhão.
  <br>
  Imagine que um caminhão precise sair do armazém onde está e fazer entregas pelas cidades da região em apenas uma viagem, o problema do caixeiro viajante se apresenta dessa maneira, buscando então saber qual seria a melhor rota para o caminhão passar sem que o mesmo passe duas vezes pela mesma cidade, mas que consiga passar por todas as cidades e ainda sim voltar para a cidade de origem.
  <br><br>
  A definição da melhor rota pode variar, no caso em questão, estamos apenas considerando a distancia total da rota, onde quanto menor a distância, melhor a rota.
  A principio,a resoluçção do problema parece simples, para identificar a melhor rota, basta calcular a distância de cada rota e pegar aquela com a menos distância.
  <br><br>
  Mas é ai que descobrimos o real problema deste desefio, a quantidade de rotas é data pela equação R( n ) = ( n - 1 )!, isto é, a quantidade de rotas é igual ao fatorial da quantidade de cidades que temos - 1 (isso por que a cidade incial é sempre a mesma).
  <br> 
  <br>
  Como a quantidades de rotas para cada cidade que adcionamos cresce em um número exponencial, cada vez que adcionamos uma cidade fica mais dificil calcular as rotas possíveis.
  <br>
  Por exmplo, se adcionarmos 19, conforme vemos abaixo no calculo de fatoral gerado (gerado pelo site https://calculareconverter.com.br/calculadora-fatorial/) podemos ver que, em apenas 19 cidades já teriamos 121.645.100.408.832.000 rotas 😱.
  <br>
  <br>
  ![image](https://user-images.githubusercontent.com/61763480/173256689-3447837f-a9b2-4817-897e-f002ff3733be.png)
  <br>
  <br>
  Isso acaba tornando impossível que tentamos resolver o desafio do caixeiro viajante apenas com a força bruta, olhando rota por rota.
  <br>
  O objetivo do projeto em questão é o problema do caixeiro viajante através da implementação de um algorítimo genético, na tentativa de encontrar-mos uma rota válida sem validar todas as opções possíveis.
  
### Algorítimo Genético
  O algorítimo genético é uma implementação que visa simular a ação da seleção natural, nesse caso, usaremos seleção natural para identificar qual a melhor rota.
  <br>
  Em nossa implementação, criamos uma classe chamada Geração, onde a mesma é responsável por gerar os "Indivíduos", ou em nosso caso, as rotas (que representamos por arrays de inteiros, onde a posição do array é a ordem em que se passa, o valor da posição é a cidade que vai passar).
  <br>
  No caso a ideia aqui não é que a geração crie todas as rotas possíveis, ela incialmente vai criar algumas rotas, de maneira aleatória, depois essas rotas criadas, serão passadas para uma classe que irá validar todas as rotas criadas e selecionar algumas para a próxima fase. ( Essa classe chamamos de darwin 😁)
  <br>
  <br>
  A classem darwin define o quão bom cada uma das rotas foi, e baseado nisso dá uma percentual de chance de passar para a próxima fase.
  <br>
  Darwin então seleciona aleatoriamente (utilizando o método de roleta de duas agulhas) dois indivíduos que passaram para a proxima fase, e passa, junto com o melhor individuo gerado, para a geração.
  <br>
  A geração então recebe recebe esses individuos que conseguiram passar para a próxima fase, e cria novos indivíduos para competir com esses que ficaram.
  <br>
  Aqui, o processo vai se repitir até que definimos que o processo deva parar. Resolvemos escolher depois métodos de parada, para impedir que o programa fique para sempre procurando as melhores rotas:
  <ul>
    <li>Tempo de execução</li>
      <dl>O programa para de procurar rotas quando chega a 15 minutos de execução (Tempo limite de apresentação para a matéria que pediu)</dl>
  <li>Quantidade de rotas repetidas</li>
      <dl>Se, por 5 gerações seguidas, for identificado a mesma rota, então consideramos que aquela efetivamente é a melhor rota. </dl>
  </ul>
 <br>
### Execute em sua máquina:
<br>
Para testar, baixe o arquivo abaixo e execute o arquivo CaixeiroViajante.exe;
<brr>
Na pasta exemplos você pode encontrar o arquivo com o modelo específiciado para entrada, um txt onde cada linha representa uma execução do problema, a linha deve ser preenchida da seguinte maneira:
  <br>
  <br>
  <ol>
    <li>Primeira posição: </li>
      <dl>Quantidade de cidades que entrará (deve ser um valor menor que 21)</dl>
    <li>Distancia entre as cidades</li>
     <dl>Todos os valores devem ser separados por <strong>";"</strong></dl>
  </ol>
  
  Exemplo de entrada + Explicação:
  <br>
  ![image](https://user-images.githubusercontent.com/61763480/173257726-39bbb306-0d5b-4921-a08e-84838858b9e5.png)
  <br>
  
[CaixeiroViajante.zip](https://github.com/BrendonAraujo/CaixeiroViajante/files/8886926/CaixeiroViajante.zip)

