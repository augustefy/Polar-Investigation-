# Description Diagramme de classe 

## Mot

Cette classe possède comme attributs les deux mots : <small>*MotC et MotU*</small>, qui seront utilisés dans un <u>Round</u> ainsi qu'une phrase : <small>*MotW*</small> qui indique au joueur qu'il est Mr.White.


## Joueur
Cette classe possède comme attributs le nom du joueur : <small>*Name*</small> et une image  : <small>*Image*</small> qui lui permettra de pouvoir s'identifier et se différencier des autres joueurs

## Vote
Cette classe possède comme attribut un joueur (<u>IRole</u>) : <small>*JoueurVote*</small>. Cette classe est utilisé lors des votes et permet de savoir qui a été voté. Elle sera utilisé par <u>Tour</u>.

## Case
Cette classe possède comme attributs des coordonnées : <small>*X et Y*</small> qui permettent de savoir la position de la case sur le plateau. Elle possède aussi un mot : <small>*Mot*</small> et un joueur <small>*Joueur*</small>. Le mot permet d'attribuer un role au joueur dès qu'il choisi une case et le joueur est intégré dans la case pour l'affichage, car le nom et l'image du joueur sera affiché à la position de la case après l'avoir choisi.

## Plateau
Cette classe possède comme attributs une liste de <u>Cases</u> : <small>*Board*</small>, pour pouvoir faire le plateau ainsi qu'un <u>Mot</u> : <small>*Mot*</small> pour pouvoir distribuer tous les mots dans chaque case.

## IRole
Cette interface possède comme attributs deux booléens : <small>*Gagner et Mort*</small> qui permettent de savoir si le joueur a gagné ou non ou s'il est éliminé. Elle possède aussi un string qui indique le role/nom de la classe qui l'implémente : <small>*Role*</small>, ainsi qu'un autre string : <small>*ChangementRole*</small> qui est utilisé pour indiquer si le joueur doit changer de role <b> *Ce string a été ajouté après l'implémentation des events, puisque les events ne retournent rien et qu'il était impossible de changer la classe d'un objet passé en argument. Il fallait donc une indication qu'un joueur changeait de classe, étant donné que dans la classe Round, chaque joueur était inséré dans une classe Civil pour simplicité*</b>. Elle possède en dernier atttribut un joueur: <small>*Joueur*</small>.

Cette interface ne possède aucune méthode, car elle était utilisé pour différencier les joueurs par role et un joueur ne pouvait pas effectuer des actions sur lui-même.

## *Civil : Under : White*
Ces classes implémentes l'interface <u> IRole</u> et ne possèdent pas d'autres attributs


## Parametres
Cette classe possède comme attributs des int pour le nombre de joueurs : <small>*nbJoueur*</small>, le nombre de civil : <small>*nbCivil*</small>,  le nombre d'Undercover : <small>*nbUnder*</small>,  le nombre de Mr.White : <small>*nbWhite*</small> ainsi que le nombre de Rounds : <small>*nbRunds*</small>. Cette classe permet de choisir comment on souhaite jouer ainsi que combien de fois.

## Tour
Cette classe possède comme attributs une liste de IRole : <small>*JoueursList*</small>, ce sont les joueurs qui sont encore vivant, une liste et un dictionnaire de <u>Vote</u>  : <small>*VoteList et VoteDict*</small>. <b> *La raison des deux collections provient encore des events, en effet puisqu'un event ne peut rien retourner, il fallait contourner ce problème, nous avons donc ajouter une liste pour récupérer tous les votes*</b> Tour possède aussi un Plateau : <small>*Plateau*</small> pour pouvoir voter un joueur et le récuperer du plateau.

Un tour permet de parler, voter des joueurs et en éliminer un. Cela peut ce faire plusieurs fois quand on joue avec un mot, nous avons donc mis cette partie du jeu dans cette classe.

## Round
Cette classe possède comme attributs deux liste de IRole, une des joueurs vivants et l'autre des joueurs éliminés : <small>*JoueursVivant et JoueurMort*</small>, un Mot : <small>*Mott*</small> pour pouvoir les données aux cases du plateau que Round possède aussi en attribut : <small>*Plateau*</small>. Enfin, le dernier attribut est une liste de Tour : <small>*Tours*</small>, car on peut jouer plusieurs tours dans un round.

Un Round sert à choisir pour chaque joueur une carte (qui est nommée case dans notre code) et puisque ça ne se fait qu'une fois par partie avec un mot, nous l'avons mis dans cette classe pour pouvoir ensuite jouer autant de tour que nécessaire.

## Partie
Cette classe possède comme attributs une liste de Joueur : <small>*JoueursList*</small> qui sont tous les joueurs qui vont jouer et qui n'ont pas encore de roles, il y a aussi deux listes deux mots, une qui n'a pas encore été utilisé dans un Round et l'autre si : <small>*MotsPasJouer et MotJouer*</small>. Il y a aussi une liste de Round : <small>*Rounds*</small>, car on peut jouer plusieurs Round grâce au parametres : <small>*Parametres*</small>

Une Partie est la classe qui lance le jeu et qui permet de choisir tous les paramètres et noms des joueurs avant de réellement jouer.

## Regles

Cette classe n'a pas d'attribut, car elle est statique et n'a que des fonctions qui sont utilisés par Round et Plateau puisque c'est des règles du jeu.


# Events
___

## GuessingWordEventArgs
Cet event possède comme attributs un mot et un joueur, car cet event est utilisé si Mr.White est éliminé et qu'il doit deviner le mot des civils. On passe donc le mot en paramètre pour qu'il le devine.

## PickingCaseEventArgs
Cet event possède comme attributs un joueur, un plateau et un mot, car cela permet au joueur de choisir une case du plateau, d'être inséré ensuite qu'il la selectionné et de changer le type de role du joueur dépendant du mot que la case possède.

## PickingNameEventArgs
Cet event possède comme attributs un joueur et une liste de joueurs, pour que le joueur puisse écrire son nom et vérifier qu'il n'a pas le même nom qu'un autre joueur.

## PickingNumberPlayeurEventArgs
Cet event possède comme attributs un paramètre et un type pour qu'on puisse choisir le nombre du type, donc soit de joueurs, civil, under ou white.

## PickingNumberRoundEventArgs
Cet event possède comme attribut un paramètre pour qu'on puisse choisir le nombre de rounds.

## PlayeurOutEventArgs
Cet event possède comme attribut un role pour afficher que ce joueur est éliminé.

## PlayeurSpeakingEventArgs
Cet event possède comme attribut un role pour indiquer a ce joueur de parler.

## PlayeurVotingEventArg
Cet event possède comme attributs un joueur (role), une liste de vote et un plateau pour qu'un joueur puisse éliminer un joueur en le sélectionnant du plateau et le mettre dans une liste pour être traité.

## RestartVoteEventArgs
Cet event n'a aucun attribut, car il ne sert qu'a afficher un message qui dit qu'il y a une égalité.

## RoleWonEventArgs
Cet event possède comme attributs un role (string) et une liste de joueurs pour afficher que tous les joueurs du role donné ont gagnés.

## ShowingBoardEventArg 
Cet event possède comme attribut un plateau pour pouvoir l'afficher.

# Persistence
___

## ISerialized

Cette interface possède deux fonctions, une fonction *Write()* qui permet de lire les données d'une partie et de les écrire dans un fichier de son choix et une fonction *Read()* qui récupéra les informations dans le fichier et les retourneront dans une instance de partie.

## XmlSerialized
Cette classe implémente l'interface ISerialized et sera utilisé pour créer des fichiers .xml

## JsonSerialized
Cette classe implémente l'interface ISerialized et sera utilisé pour créer des fichiers .json