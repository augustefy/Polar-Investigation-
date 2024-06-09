# Diagrame de cas d'utilisateur
![][def]

[def]: diagrameUseCase.drawio.png

### 1 - << utilisateurs >>
Les utilisateurs peuvent être n'importe qui, mais il faut avoir au moins 3 personnes pour jouer.

### Cas 2 - << consulter les regles >>
|||
-|-
**Nom**|consulter les règles
**Objectif**|fair connaitre les règles a des joueurs qui ne connaissent pas
**Acteurs prancipaux**|personne qui ne connaît pas les règles de jeu
**condition initial**| - joueur doit être connecté à l'application <br> - joueur doit cliquer sur le button de régles
**scenario d'utilisation**| - joueurs lisent les règles <br> - joueurs reviennent à menue principale une fois qu'il à finir sa lecture
**condition de fin**| - Joueur a bien lu donc matent il revina sur le menu avec savoir de joué <br> - joueur a lu moitié et revient sur menu sans savoir jouer

<br></br>

### Cas 3 - << gérer les paramètres >>
|||
----- | ----
**Nom**  |  gérer les paramètres
**Objectif**  |  fixé les paramètres soucheté pour confort des joueurs
**Acteurs prancipaux**  |  Des joueurs capricieux
**condition initial**  |  - joueur doit être connecté à l'application <br> - joueur doit cliquer sur le button de paramètres
**scenario d'utilisation**  |  - joueur règles les paramètres <br> - joueur revient sur le menu
**condition de fin**  |  - joueur à peut fixer application à son désir <br> - joueur n'est pas satisfait donc il peut nous mal noter

<br></br>

### Cas 4 - << crée une partie >>
|||
-|-
**Nom**|crée une partie
**Objectif**|crée un parti d'undercover et fixé les options
**Acteurs prancipaux**|joueur qui va créé parti
**Acteurs secondaires**|Les certains contraints prés définis qui permettent de pas fair de ni porte quoi (exemple: s'il a 3 joueurs, 2e st forcement civilian, 1 undercover et 0 M. White etc.)
**condition initial**| - joueur commenissait un parti <br> - joueur à 2 mais minimum et (19 maximum)
**scenario d'utilisation**| - joueur choisit nombres de joueurs <br> - joueur personalise proportion des personnages
**condition de fin**| - joueur démarre partis <br> - joueur na pas assez d'amis pour joué <br> - joueur ne plus envie de joué ou a oublié quelque chose donc il retourne sur le menu

<br></br>

### Cas 5 - << commencer partie >>
|||
-|-
**Nom**|commencer partie
**Objectif**| Personnalisé son personnage(photo et surnom) et commencé de jouer !!!!
**Acteurs prancipaux**|les joueurs de partis
**condition initial**|- il y a déjà un parti qui est créé avec les nombres de personnages choisit <br> - il y a groupe de 3-20 amis qui sont déjà prêt à jouer
**scenario d'utilisation**|- les joueurs choisissent leur surnom <br> les joueurs choisissent leur photo ou avatar <br> - joueurs commencent  joué
**condition de fin**|- les joueurs ont fait personnalisation de leurs personnages et ont commencé joué <br> - ils ont décidé de plus joué et ils ont quitté la partie

<br></br>

### Cas 6 - << quitter la partie >>
|||
-|-
**Nom**|quitter la partie
**Objectif**|Permettre les joueurs de quitter quand ils n'ont plus envie de jouer
**Acteurs prancipaux**|joueurs qui ne voulant plus se jure
**condition initial**|- les joueurs sont en train de jouer, partis est démarré
**scenario d'utilisation**|-les joueurs ne voulant plus passer temps devant écran et ils quit la partit pour prendre de l'air <br> a eu un problème donc ils ont envié de recommencer la partie > - partis et fini et les joueurs ont envie de quitter
**condition de fin**|- les joueurs ont quitté la partie, partis et détruit <br> joueurs ont fini partis et ils sont partis

<br></br>

### Cas 7 - << recommencer la partie >>
|||
-|-
**Nom**|recommencer la partie
**Objectif**|Recommencer la partie sans arriver à menu de départ, pour rapidement recommencer après la fin ou au milieu de partis 
**Acteurs prancipaux**|les joueurs qu'ils ont envie de recommencer la partie
**condition initial**|- la partie est en train de tourner
**scenario d'utilisation**|- les joueurs ont envie de recommencer car il y a eurent un fui d'information sur un personnage <br> ont fini un parti et tellement ils ont imprécisé qu'il ont envie de recommencer
**condition de fin**|- ils ont recommencer parti en sucée

<br></br>

### Cas 8 - << jouer son tour >>
|||
-|-
**Nom**|jouer son tour
|**Objectif**|jouer à son tour
**Acteurs prancipaux**|joueur qui doit jouer son tour
**condition initial**|- les autres ont joué et tout est venu pour joueur n
**scenario d'utilisation**|- joueur joue à son tour et clique suivant
**condition de fin**|- Tout est joué et prochain doit jouer <br> - c'était dernier joueur et maintenant il faut voté

<br></br>

### Cas 9 - << voter >>
|||
-|-
**Nom**|voter
**Objectif**|voté à qui les joueurs pensant d'être undercover
**Acteurs prancipaux**|Tous les joueurs
**Acteurs secondaires**|la tour de vote
**condition initial**|- tout le monde à jouer partis
**scenario d'utilisation**|- joueur vote a qu'il pensait d'être undercover
**condition de fin**|- vote est fait et un joueur quit la partie(ça peut être les trois personnages) et jeu continu <br> - il ne rest plus d'undercover donc les civilians ont gagné - <br> ils rest qu'un civilian donc les undercovers ont gagné <br> - M. white quit le jeu et il dit quil pensait d'être undercover
