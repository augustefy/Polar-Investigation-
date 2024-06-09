
```plantuml
@startuml


Class Partie {
    +Partie(motsPasJouer:List<Mot>)
    +ChoisirNbJoueur()
    +ChoisirNbUnder()
    +ChoisirNbWhite()
    +ChoisirNbRounds()
    +ChoisirParametres()
    +ChoisirNom(j:Joueur)
    +ChoisirNomAll()
    +CreerRound():Round
    +JouerRound(r:Round)
    +JouerPartie()

}

Class Parametres{
    -nbJoueur: int
    -nbCivils: int
    -nbUnder: int
    -nbWhite: int
    -nbRounds: int
    +Parametres(nbJ:int)
}

Class Round{
    -motU: Mot
    -motC: Mot
    -motW: Mot
    +Round(joueurs:Joueurs, parametre:Parametres, mot:Mot)
    +ChoisirCase(j:IRole)
    +CreerTour()
    +ChoisirCaseAll()
    +JouerTour(tour:Tour): bool
    +JouerAllTour()
}

Class Plateau{
    
    +Plateau(nbCivil:int, nbUnder:int, nbWhite:int ,nbJ:int, mot:Mot)
}

Class Joueur{
    -Name:string
    -Image:string
    +Joueur(Name:string)
}

Class Mot{
    - MotC:string
    - MotU:string
    - MotW:string
    + Mot(motC:string, motU:string)
}

Class Vote{
    
    +Vote()
    +Vote(Joueur joueur)
    +AddJoueur()
}

Class Case {
    - Face:bool
    - X:int
    - Y:int
    - Mot:string
    + Case(x:int, y:int)
    + ChangeFace()
}

Class Tour{
    +Tour(Joueurs:List<IRole>, plateau:Plateau )
    +DireMotAll()
    +Voter(IRole j)
    +VoterAll()
    +CompterVote():Vote
    +FinDeTour(Vote v, List<IRole> Joueurvivant, List<IRole> JoueurMort)
}

Interface IRole{
    - Gagner:bool
    - Mort:bool
    - Role:string
    - ChangementRole:string
}

static Class  Regles{
    + <<static>> AttribuerMotCase(plateau:Plateau , nbCivil:int ,  nbUnder:int, nbWhite:int , nbJ:int , mot:Mot )
    + <<static>> ChangerOrdreDeJeu(round:Round)
    + <<static>> VerifGagner(round:Round):bool

}

Class White{}
Class Under{}
Class Civil{}

Class GuessingWordEventArgs <EventArgs>{
    + word:string
    + Playeur:IRole
    +GuessingWordEventArgs(gagner:bool, word:string, Playeur:IRole)
}

class PickingCaseEventArgs<EventArgs>{
    +Playeur:IRole
    +Board:List<Case>
    +PickingCaseEventArgs(Playeur:IRole,Board:List<Case>,Mot:Mot)
}

class PickingNameEventArgs<EventArgs>{
    +Playeur:Joueur
    +Joueurs:List<Joueur>
    +PickingNameEventArgs(Playeur:Joueur,Joueurs:List<Joueur>)
}

class PickingNumberPlayeurEventArgs<EventArgs>{
    +Parametres:Parametres
    +Type:string
    +PickingNumberPlayeurEventArgs(Parametres:Parametres,Type:string)
}

class PickingNumberRoundEventArgs<EventArgs>{
    +Parametres:Parametres
    +PickingNumberRoundEventArgs(Parametres:Parametres)
}

class PlayeurOutEventArgs<EventArgs>{
    +Playeur:IRole
    +PlayeurOutEventArgs(Playeur:IRole)
}

class PlayeurSpeakingEventArgs<EventArgs>{
    +Role:IRole
    +PlayeurSpeakingEventArgs(Role:IRole)
}

class PlayeurVotingEventArg<EventArgs>{
    +Playeur:IRole
    +Votes:List<Vote>
    +Plateau:Plateau
    +PlayeurVotingEventArg(Playeur:IRole,Votes:List<Vote>,Plateau:Plateau)
}

class RestartVoteEventArgs<EventArgs>{}

class RoleWonEventArgs<EventArgs>{
    +Role:string
    +Joueurs:List<IRole>
    +RestartVoteEventArgs(Role:string,Joueurs:List<IRole>)
}

class ShowingBoardEventArg<EventArgs>{
    +Board:List<Case>
    +ShowingBoardEventArg(Board:List<Case>)
}



Partie --> "*-Rounds" Round
Partie --> "-info" Parametres
Partie --> "*-Joueurs" Joueur
Partie -->  Mot :MotsPasJouer
Partie --> "*-MotsJouer" Mot


Round --> "-Plateau" Plateau
Round --> "*-Tour" Tour
Round   --> IRole:*-JoueursVivant
Round --->  IRole:*-JoueursMort
Round --> " -Mott" Mot
Round ..> Regles

Plateau  --> "* -Board" Case
Plateau --> "-Mot" Mot

Case --> "-Joueur" IRole

Tour  --> "*-JoueursList" IRole
Tour  [Vote,int] --> "VoteDict " Vote
Tour   --> "*-VoteList " Vote
Tour --> "-Plateau" Plateau


Regles <..Plateau

Vote  --> "-JoueurVote" IRole

IRole --> "-Joueur" Joueur

White ..|> IRole
Under ..|> IRole
Civil ..|> IRole

Tour --> PlayeurOutEventArgs
Tour --> PlayeurVotingEventArg
Tour --> PlayeurSpeakingEventArgs
Tour --> RestartVoteEventArgs

Round --> PickingCaseEventArgs
Round --> ShowingBoardEventArg

Regles --> GuessingWordEventArgs
Regles --> RoleWonEventArgs

Parametres --> ValueClickedBadEventArg

Partie --> PickingNameEventArgs
Partie --> PickingNumberPlayeurEventArgs
Partie --> PickingNumberRoundEventArgs

@enduml
```