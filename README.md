# JOLY_FSM_Unity
 
Contenu du projet

Idle --> Patrol --> Chase --> Attack

Le personnage se déplace par IA.
Il commence en idle, l'animation est choisie aléatoirement parmis les deux.
Au bout de quelques secondes il passe en mode patrol et marche vers un point in range chosit aléatoirement,
quand ce point est atteint, il en choisit un nouveau.
Si pendant sa patrouille, il trouve un ennemi, il passe en mode chase et cours vers lui (avec blend walk/run)
Une fois l'ennemi atteint, il joue l'animation d'attaque en boucle.

Appuyer sur espace pour sauter pendant l'idle ou la patrouille.
Appuyer sur E pour attaquer.

