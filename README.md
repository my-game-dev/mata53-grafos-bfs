# Breadth First Search Algorithm
## 🖱️ Acesso
Para utilizar a aplicação, [clique aqui](https://my-ufba-projects.github.io/mata53-grafos-bfs).
Para assistir ao vídeo descritivo, [clique aqui](https://youtu.be/jp16NbWs4os)

## ✏️ Apresentação
Aplicação desenvolvida por [Danilo de Andrade Peleteiro](https://www.linkedin.com/in/danilo-peleteiro-ufba/) no contexto da disciplina *MATA53 - Teoria dos Grafos*, ministrada pelo Prof. [Tiago Januário](https://www.linkedin.com/in/januarioccp/) através do curso de Ciência da Computação na Universidade Federal da Bahia (UFBA) - 2021.1.

Nº de Matrícula: 217115466

## 📃 Descrição
Foi desenvolvida uma aplicação que representa visualmente o comportamento do [Breadth First Search](https://pt.wikipedia.org/wiki/Busca_em_largura) (BFS) Algorithm, conhecido em português como o Algoritmo da Busca em Largura.

## 💻 Tecnologias
Foram utilizadas as seguintes tecnologias para o desenvolvimento:
- Unity Engine
- C#

### Unity
[Unity](https://unity.com/pt) é uma Game Engine e se encaixou no escopo deste trabalho por facilitar o uso de recursos visuais, build para Web, e por haver uma prévia familiaridade do Desenvolvedor com a ferramenta.

Caso haja interesse em abrir o Projeto através da Game Engine e realizar uma build local, basta seguir os seguintes passos:
1. Fazer Download do [Unity Hub](https://store.unity.com/download), que é um intermediário que controla as diversas versões da Unity instalada no PC do usuário;
2. Instalar Unity Hub;
3. Através do Unity Hub, instalar versão do Unity 2020.3.8f1 e o pacote para build WebGL;
4. Clonar este repositório e abrí-lo através do Unity Hub;
5. Dentro do Unity, clique em File > Build Settings;
6. Selecione a plataforma WebGL;
7. Clique em Add Open Scenes;
8. Clique em Build.
9. Aguarde e será gerado na pasta selecionada o seu build;
10. Agora basta fazer o upload da pasta gerada em algum servidor Web/local e pronto!

### C#
A [linguagem C#](https://pt.wikipedia.org/wiki/C_Sharp) é utilizada em conjunto com a Unity para o desenvolvimento de Scripts e Funcionalidades da aplicação.

Para acessar os Códigos que foram implementados para esta aplicação, basta ir à pasta `Assets/Scripts`. São os seguintes arquivos:
```
CoordinateLabeler.cs
GridMapHandler.cs
PaintController.cs
```

## 🦮 Guia
O usuário poderá realizar 5 Ações distintas durante o uso da aplicação:
- Selecionar os pontos de Início e Chegada;
- Iniciar a execução do Algoritmo;
- Interromper a execução do Algoritmo;
- Limpar resquícios de execução anterior do Algoritmo no mapa;
- Alterar velocidade de execução das etapas do Algoritmo.

### Selecionar Pontos de Início e Chegada
Há um `Dropdown` onde o usuário poderá escolher qual ponto será definido (Início ou Chegada). Após realizar a escolha de qual ponto será alterado, o usuário poderá clicar em qualquer lugar no mapa para definir o novo local de onde o Algoritmo iniciará/encerrará sua execução.

### Iniciar a Execução do Algoritmo
Há um `Botão` chamado `Start`, que dá início à execução do Algoritmo, saindo do Ponto de Início (Verde), até o Ponto de Chegada (Vermelho).

### Interromper a execução do Algoritmo
Há um `Botão` chamado `Stop`, que interrompe a execução do Algoritmo.

### Limpar Resquícios de Execução
Há um `Botão` chamado `Clear`, que limpa todo o caminho (Azul) anterior realizado pelo Algoritmo.

### Alterar Velocidade de Execução
Há um `Slider` chamado `Speed`, que o usuário poderá interagir para diminuir/aumentar a velocidade de execução dos passos do Algoritmo.


## 📹 Funcionamento
![iDD8RPsf3I](https://user-images.githubusercontent.com/36287131/120257353-788ea880-c266-11eb-8a05-00b188d47b8d.gif)


## ℹ️ Informações Pertinentes ao Algoritmo
Optou-se, para este Algoritmo BFS, utilizar apenas vizinhos e movimentos realizados nos sentidos Horizontal e Vertical.

## 📚 Saiba mais sobre a Busca em Largura
- [Busca em Largura - USP](https://www.ime.usp.br/~pf/algoritmos_para_grafos/aulas/bfs.html)
- [Busca em Largura - Wikipedia](https://pt.wikipedia.org/wiki/Busca_em_largura)
