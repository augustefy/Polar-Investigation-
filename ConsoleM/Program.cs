// See https://aka.ms/new-console-template for more information

using UndercoverClass.Board;
using UndercoverClass.Game;
using UndercoverClass.Rules;
using UndercoverClass.Persistance;
using UndercoverClass;
using UndercoverClass.Events;
using System.Runtime.Serialization;


List<Mot> mot = new List<Mot>();

mot.Add(new Mot("Fraise", "Framboise"));
mot.Add(new Mot("Voiture", "Moto"));
mot.Add(new Mot("Chien", "Chat"));
mot.Add(new Mot("Fille", "Garçon"));

DisplayConsole d = new DisplayConsole();

var serializerParam = new DataContractSerializer(typeof(Parametres));
var serializerJoueurs = new DataContractSerializer(typeof(List<Joueur>));
var serializer = new DataContractSerializer(typeof(Partie));

Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), "E:/"));
string xmlFile = "parametresJoueurs.xml";
ISerializer s = new XmlSerializer();
Partie p =new Partie(s);
p.Parametres.ValueClickedBad += d.MauvaiseValeurNombres;
p.PickingCase += d.JoueurChoisirCarte;
p.PickingNumberPlayeur += d.ChoisirNombreJoueurs;
p.PickingName += d.ChoisirNomJoueur;
p.PickingNumberRound += d.ChoisirNombreRound;
p.PlayeurSpeaking += d.JoueurParler;
p.RestartVote += (sender, args) => Console.WriteLine("\nIl y a une égalité, recommencez donc le vote\n");
Regles.GuessingWord += d.DevinerMot;
Regles.RoleWon += d.RoleGagne;
p.ShowingBoard += d.AfficherPlateau;
p.PlayeurVoting += d.JoueurVoter;
p.PlayeurOut += d.JoueurEliminer;


//p.ChoisirParametres();
//p.ChoisirNomAll();

//using (Stream s = File.Create(xmlFile))
//{
//    //serializerParam.WriteObject(s, p.Parametres);
//    serializerJoueurs.WriteObject(s, p);

//}

//Partie Partie2 = new Partie();
//using (Stream s = File.OpenRead(xmlFile))
//{
//    //Partie2.Parametres = serializerParam.ReadObject(s) as Parametres;
//    Partie2 = serializer.ReadObject(s) as Partie;
//}
p.JouerPartie();
//Partie p2=new Partie(s);
//Round r =s.ReadRound("rounds");
//p2.Rounds.Add(r);
//p2.JouerRound(r);