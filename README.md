# GalaxyShooter

##Projeto de um jogo shooter 2D, feito para aprendizado sobre interface com o usuário, utilização do sistema de sons, aplicação de animações em 2D, aplicação de post-processing e criação de um sistema de spawn.

-Sobre:
============================

-Geral:

Jogo criado seguindo o curso "O guia definitivo para Desenvolvimento de jogos com unity", disponível na plataforma udemy. Este consiste em um shooter 2D, onde o player é uma nave percorrendo o espaço enquanto inimigos que aparecem aleatoriamente vem ao seu encontro, destruindo esses inimigos o player obtém pontos, para ajudá-lo power-ups aparecem aleatoriamente durante a gameplay.

- Pontos de aprendizado:

Para a criação desse projeto em 2D foi utilizado um modelo de nave simples com animações de movimentação para a esquerda, direita e idle, quando a nave é atingida e sofre dano, animações aleatórias de dano são instanciadas e continuam sobre a mesma, indicando o dano.

Um sistema de spawn foi criado para se instanciar os inimigos e os power-ups aleatoriamente acima da tela, onde os inimigos se direcionam para a atual posição do player, e os power-ups descem pela tela em linha reta, os inimigos que passam do player reaparecem acima da tela.

Os power-ups criados são 3, um para tiro triplo, outro para aumento de velocidade e outro que gera um escudo protetor que aguenta uma colisão, o tiro triplo e o aumento de velocidade são temporários, cada power-up tem sua própria animação.

Foram utilizados vários efeitos de post-processing para tornar o visual do jogo mais atrativo.

Foi criado um sistema de áudio, onde apresenta uma música ambiente para todo o jogo e várias das ações realizadas possuem seu próprio som, como o tiro do player, explosão do inimigo, colisão do inimigo com o player e quando se pega um power-up.

O sistema de UI consta com todas as telas necessárias para um jogo já ser apresentado e exportado, como tela de início, menu, pause e game over, além da interface in game, como a pontuação do player e a quantidade de vidas restantes.
