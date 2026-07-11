# A prototype for a fighting game 

Two players fighting. Made using Unity engine.

<img width="1225" height="926" alt="Screenshot1" src="https://github.com/user-attachments/assets/2701a460-65e8-4631-95de-fdbc44df6017" />

## Features:

1. Movemenet, attacks, blocking for the player character.
2. Fight manger checking for the KO (also covering simultanious hits), anmd managing the rounds (start, end, restart).
3. Attacks are easily added using scriptable objects and Animation Controller.
4. Finite  State Machine for all the Player States (Idle, Moving, Attack startup, recovery and more).
5. Input buffer allowing for adding moves performed with motion inputs - qutercircles, halfcircles, precels...).

## Instructions adn important information:

1. There are two prefabs present - <i>Player</i> and <i>TrainingDummy</i>. <i>Player</i> will respond to user input (using Unity's Input system, allowing two players to play at the same time, keyboard/gamepad). <i>TrainingDummy</i> was created for the purposes of testing, and training mode functionality. It allows user to set desired state (blocking, idle, moving).
<img width="436" height="170" alt="image" src="https://github.com/user-attachments/assets/52067888-bf58-41a1-98b3-db2877ed480b" />

2. Attack data object - each Player character has a list of Attacks, allowing for easy way to add/remove/change the movelist.

<img width="676" height="190" alt="image" src="https://github.com/user-attachments/assets/b0384897-fb38-4174-8521-90bbd1896ea3" />

Each attack data object allows for the desingner to Set attack damage, all the necessary framedata, choose which animation should be used, whether the attack is Low/High/Medium, and choose the input (1-9 for directions, LP, LK, RP, RK for left/right punch/kick, with the ":" symbol used as ending of the motion inptup and start of attack buttons.

<img width="652" height="884" alt="image" src="https://github.com/user-attachments/assets/37ffd53f-b904-427a-844c-57b3fac9d3b4" />


3. Documentation (WIP) - documentation created with the use of [Mkdocs](https://www.mkdocs.org). To access the docs, run "mkdocs serve" in Documentation/documentation. It will create a site to be accessed on your local machine.
