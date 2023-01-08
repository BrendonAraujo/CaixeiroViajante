  # CaixeiroViajante
Sistema para resolução do caixeiro Viajantre

EN
  # Travelingsalesman
An systen to solve the trevalingsalesman program

EN
## Problem:

  The travelsalesman is a math program, but to explain the problem, i willl change the travelsalesman by a truck.
  <br>
  Image a truck that needs to leave the store and make deliverys to the cities of the region in just one travel. That's the travelsalesman's problem.
  <br><br>
  The defination of the best route can change, because it's deppend of the variables of the analisys, for us, the best route will be the one who has the smallest distance.
  First, the resolution for this problem seems easy, to know the best route, look at the distace of all the routes and take de smallest.
  <br><br>
  But, in the real problem of trevalingsalesman, the quantity of routes is <strong>R( n ) = ( n - 1 )!<strong>, so, the quantity of routes is a fatorial of the number of cities.
  <br> 
  <br>
  The quantity of route grow up too much to wich city we want to add in the problem, this makes too hard to solve the problem with many cities
  <br>
  For exemplo, if we want to solve the problem with 19 cities, we will have 121.645.100.408.832.000 routes to look. This is to many routes 😱.
  <br>
  <br>
  ![image](https://user-images.githubusercontent.com/61763480/173256689-3447837f-a9b2-4817-897e-f002ff3733be.png)
  <br>
  <br>
  This quantity of cities makes impossible to solve this problem just look route by route.
  <br>
  Out project try to solve the problem using a genetic algorithm (an IA implementation).

### Genetic Algorithm
 The genetic algorithm is a IA implemetation that wants to simulate the natural select, in this case, We will use the natural select to identify the best route.
 <br>
 In our implementation, we create a class called "Geracao", she is responsabile to create "Individuos", this "Individuos" are the routes. (Arrays of integers, where for wich integers in this array, we have a city).
 <br>
 The "Geracao"  will crete some possibles routes, randomly, after another class (This class, we called "Darwin") will look this routes and select somes to pass to next step
 <br>
 <br>
 The class "Darwin" define how good a route was, e based in how good she was, give to the route a percent to survive.
 <br>
 "Darwin", select the two routes using a method called "Two-Needle Roulette", and select the best route too.
 <br>
 "The "Geracao" take this three routes and create new routes based in this three. We generate new routes randomly too, e repeat the process entil we want to stop, but when we will want to stop?
  <ul>
   <li>Time of execution</li>
     <dl>The process will stop whem the program runs for 15 minutes, because it's the time we have to show the professor</dl>
   <li>Quantitu of routes</li>
     <dl>If, we indentify a route 5 times like like good, so i take this like the best route.</dl>
  </ul>
### Try out program:
<br>
 To try, just download the file CaixeiroViajante.exe in the zip at the end of this text.
<br>
 In the zip file, you will find a model to now how to especify the Entries, a txt file, where wich line is a execution of the problem, the line has to write in this way:
<br>
<br>
  <ol>
    <li>Primeira posição: </li>
      <dl>Quantity of cities (has to by a number Below 21)</dl>
    <li>Distance of the cities</li>
     <dl>All values has to be separated by <strong>";"</strong></dl>
  </ol>

 Exemple
  <br>
  ![image](https://user-images.githubusercontent.com/61763480/173257726-39bbb306-0d5b-4921-a08e-84838858b9e5.png)
  <br>
[CaixeiroViajante.zip](https://github.com/BrendonAraujo/CaixeiroViajante/files/8886926/CaixeiroViajante.zip)

--------------------------------------------------------------------------------------------------------------------

PT=Br
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

