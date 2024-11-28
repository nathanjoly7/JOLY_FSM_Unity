# JOLY_FSM_Unity
 
Contenu du projet

Idle --> Patrol --> Chase --> Attack

Le personnage se déplace par IA.
Il commence en idle, l'animation est choisie aléatoirement parmis les deux.
Au bout de quelques secondes il passe en mode patrol et marche vers un point in range choisit aléatoirement,
quand ce point est atteint, il en choisit un nouveau.
Si pendant sa patrouille il trouve un ennemi, il passe en mode chase et cours vers lui (avec blend walk/run)
Une fois l'ennemi atteint, il joue l'animation d'attaque en boucle.

Appuyer sur espace pour sauter pendant l'idle ou la patrouille.
Appuyer sur E pour attaquer pendant un autre state.

-> Demain vous arrivez dans un studio disposant d’un moteur que vous ne connaissez pas, 
de quoi avez-vous besoin pour intégrer le travail des graphistes dans votre proto ? 
que demandez-vous ? 
quelles questions posez-vous et à qui ?

Je demande aux artistes : 
Dans quelle format vais-je recevoir les assets ?
Sous quelle forme seront les matériaux / textures ?


Je demande au développeurs du moteur: 
Comment faire en sorte d'adapter le rig de l'animation au squelette du personnage.
Comment faire un FSM dans leur moteur, créer des states, des transitions, etc.
Comment le moteur gère le blend entre plusieures animations ?

