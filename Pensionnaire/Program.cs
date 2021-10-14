using System;

namespace Pensionnaire
{

    class Program
    {


        string[,] tableau = new string[10, 7];
        static int nombreCourantAnimaux = 0;
        static int numeroID = 0;

        static void Main(string[] args)
        {

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Bienvenue dans l'application gestion clinique Veterinaire");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Program program = new();
            Console.WriteLine();
            AfficherMenu();
            Console.WriteLine("numeroID : " + numeroID);
            program.StartTheMachine();

            Console.WriteLine("numeroID : " + numeroID);



        }// **************** fin de la methode Main ************************************


        // On demande a l'utilisateur de faire son choix tant que ce dernier est invalide
        private void SelectChoice(ConsoleKeyInfo choice)
        {
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    TraiterAjoutAnimal();
                    break;
                case ConsoleKey.D2:
                    VoirListeAnimauxPension();
                    break;
                case ConsoleKey.D3:
                    VoirListePropriétaire();
                    break;
                case ConsoleKey.D4:
                    VoirNombreTotalAnimaux();
                    break;
                case ConsoleKey.D5:
                    VoirPoidsTotalAnimaux();
                    break;
                case ConsoleKey.D6:
                    ExtraireAnimauxSelonCouleurs();
                    break;
                case ConsoleKey.D7:
                    RetirerUnAnimalDeListe();
                    break;
                case ConsoleKey.D8:
                    Environment.Exit(0);
                    break;
                default:
                    AfficherMessageErreur("Le choix n'est pas valide.......");
                    break;
            }

        }

        // Fonction qui affiche le menu principal de l'application
        private static void AfficherMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1- Ajouter un animal");
            Console.WriteLine("2- Voir la liste de tous les animaux en pension");
            Console.WriteLine("3- Voir la liste de tous les proprietaires");
            Console.WriteLine("4- Voir le nombre Total d'animaux en pension");
            Console.WriteLine("5- Voir le poids total de tous les animaux en pensions");
            Console.WriteLine("6- Voir la liste des animmaux d'une couleur(rouge,bleu ou violet)");
            Console.WriteLine("7- Retirer un anamal de la liste");
            Console.WriteLine("8- Quitter l'application ");
            Console.WriteLine();

        }

        // Fonction qui demarre l'Application  et qui redirrige le programme
        // en fonction de l'Entree au clavier
        private void StartTheMachine()
        {
            ConsoleKeyInfo cki;

            while (true)
            {
                Console.WriteLine("Enter votre choix ou taper CTRL+C pour quitter");
                cki = Console.ReadKey(true);
                SelectChoice(cki);
                AfficherMenu();
            }


        }


        // Fonction qui affiche un message d'errur sur la console
        private static void AfficherMessageErreur(string message)
        {
            Console.WriteLine(message);

        }

        // Fonction qui permet d'ajouter un animal dans le tableau 
        // En demandant a l'utilisateur de saisir les informations d'un animal
        private void AjouterUnAnimal()
        {
            Console.WriteLine("Veuillez saisir le type de l'animal: ");
            var type = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le nom de l'animal: ");
            var nomAnimal = Console.ReadLine();
            Console.WriteLine("Veuillez saisir l'age de l'animal: ");
            var ageAnimal = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le poids de l'animal:");
            var poidsAnimal = Console.ReadLine();
            Console.WriteLine("Veuillez saisir la couleur de l'animal: ");
            var couleurAnimal = Console.ReadLine().ToLower();
            if (!ValidationCouleur(couleurAnimal))
                AfficherMessageErreur("votre couleur n'est pas valide.........");
            while (!ValidationCouleur(couleurAnimal))
            {
                Console.WriteLine("Veuillez saisir la couleur de l'animal: ");
                couleurAnimal = Console.ReadLine().ToLower();
                if (!ValidationCouleur(couleurAnimal))
                    AfficherMessageErreur("votre couleur n'est pas valide.........");





            }
            Console.WriteLine("Veuillez saisir le nom du proprietaire de l'animal: ");
            var nomProprietaireAnimal = Console.ReadLine();

            // Appel de la fonction pour traiter l'ajout d'un animal

            tableau[numeroID, 0] = numeroID.ToString();
            tableau[numeroID, 1] = type;
            tableau[numeroID, 2] = nomAnimal;
            tableau[numeroID, 3] = ageAnimal;
            tableau[numeroID, 4] = poidsAnimal;
            tableau[numeroID, 5] = couleurAnimal;
            tableau[numeroID, 6] = nomProprietaireAnimal;
            ++numeroID;
            ++nombreCourantAnimaux;
            Console.WriteLine("numeroID apres AjouterUnAnimal() :" + numeroID);
            Console.WriteLine("nombreAnimaux apres AjouterUnAnimal() :" + nombreCourantAnimaux);


        }

        // Fonction qui affiche la liste des animaux en pensions(choix 2)
        private void VoirListeAnimauxPension()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID\t|\tTYPE ANIMAL\t|\tNOM\t|\tAGE\t|\tPOIDS\t|\tCOULEUR\t|\tPROPRIETAIRE |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

            for (int indice = 0; indice < tableau.GetLength(0); indice++)
            {

                Console.WriteLine($"{tableau[indice, 0]} \t\t{tableau[indice, 1]}\t\t\t{tableau[indice, 2]}\t\t{tableau[indice, 3]} \t\t{tableau[indice, 4]}\t\t{tableau[indice, 5]}\t\t{tableau[indice, 6]}");
            }

        }
        /*
         * Une fonction de type void
         * qui affiche la liste des proprietaires des animaux pensionnaires
         */
        private void VoirListePropriétaire()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("|\tPROPRIETAIRE\t|");
            Console.WriteLine("----------------------------------------------------------------------");
            for (int indice = 0; indice < tableau.GetLength(0); indice++)
            {
                Console.WriteLine($"\t{tableau[indice, 6]}\t");
            }

        }
        // fonction qui affiche  le nombre total des animaux  pensionnaires
        private static  void VoirNombreTotalAnimaux()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("|\tNOMBRE ANIMAUX\t|");
            Console.WriteLine("----------------------------------------------------------------------");

            Console.WriteLine($"\t{nombreCourantAnimaux}\t");

        }

        // Fonction qui calcule et  affiche le poids total de l'ensemble des  animaux
        // pensionnaires 
        private void VoirPoidsTotalAnimaux()
        {
            int Total = 0;

            for (int indice = 0; indice < tableau.GetLength(0); indice++)
            {
                if (tableau[indice, 4] == null)
                    continue;

                Total += int.Parse(tableau[indice, 4]);
            }

            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("|\tPOIDS TOTAL\t|");
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"\t{Total}\t");

        }
        // Fonction qui permet d'extraire une sous-liste d'animaux suivant leur couleur
        private void ExtraireAnimauxSelonCouleurs()
        {
            Console.WriteLine("VEUILLEZ SAISIR LA COULEUR DE RECHERCHE : ");
            string couleur = Console.ReadLine().ToLower();
            switch (couleur)
            {
                case "bleu":
                    AfficherAnimauxParCouleur(couleur);
                    break;
                case "rouge":
                    AfficherAnimauxParCouleur(couleur);
                    break;
                case "violet":
                    AfficherAnimauxParCouleur(couleur);
                    break;
                default:
                    AfficherMessageErreur("Le choix n'est pas valide.........");
                    break;
            }

        }

        // Une fonction qui permet de retirer un animal dans la liste
        // En connaissant son ID
        private void RetirerUnAnimalDeListe()

        {
            if (nombreCourantAnimaux > 0)
            {
                Console.WriteLine("VEUILLEZ SAISIR LE ID DE L'ANIMAL: ");
                string id = Console.ReadLine();

                bool result = int.TryParse(id, out int identifiant);
                if (result == true)
                {
                    if (identifiant >= numeroID || identifiant < 0)
                    {
                        AfficherMessageErreur("ID entrer n'est pas valide.........");
                    }
                    else
                    {
                        for (int indice = 0; indice < 7; indice++)
                        {
                            tableau[identifiant, indice] = null;
                        }
                        nombreCourantAnimaux--;

                    }
                }
                else
                {
                    while (!result)
                    {
                        Console.WriteLine("Entrer un Identifiant entier valide");
                        id = Console.ReadLine();
                        result = int.TryParse(id, out identifiant);
                        Console.WriteLine("identifiant invalide veuillez reesassayer");

                    }
                    if (identifiant >= 0 && identifiant < nombreCourantAnimaux)
                    {
                        for (int indice = 0; indice < 7; indice++)
                        {
                            tableau[identifiant, indice] = null;
                        }
                        nombreCourantAnimaux--;

                    }
                    else
                    {
                        Console.WriteLine("Identifiant invalide ");

                    }

                }

                // On affiche la nouvelle liste mise a jour
                VoirListeAnimauxPension();
            }
            else
            {
                Console.WriteLine("La liste des animaux est vide..........");
            }

        }

        // fonction qui permet de lister les animaux suivant la couleur saisie
        // par l'Utilisateur 
        private void AfficherAnimauxParCouleur(string couleur)
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID\t|\tTYPE ANIMAL\t|\tNOM\t|\tCOULEUR\t\t|");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            for (int indice = 0; indice < tableau.GetLength(0); indice++)
            {
                if (tableau[indice, 5] == couleur)
                {

                    Console.WriteLine($"{tableau[indice, 0]}  \t\t{tableau[indice, 1]}\t\t\t{tableau[indice, 2]}\t\t{tableau[indice, 5]}");
                }

            }


        }
        // Une fonction qui permet de rechercher une case vide dans le tableau des animaux
        // s'il trouve une case vid il retourne le numero index correspondant
        // sinon il retourne -1 pour sortir de la fonction
        private int RechercheLigneVide()
        {
            int indice = 0;
            while (indice < numeroID && tableau[indice, 0] != null)
            {
                indice += 1;
            }
            if (indice < numeroID)
            {
                return indice;
            }
            else
            {
                return -1; // juste pour avoir une sortie de la fonction

            }


        }
        // une fonction qui inserre a la ligne index dans le Tableau
        private void Ajouter2UnAnimal(int index)
        {
            Console.WriteLine("Veuillez saisir le type de l'animal: ");
            var type = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le nom de l'animal: ");
            var nomAnimal = Console.ReadLine();
            Console.WriteLine("Veuillez saisir l'age de l'animal: ");
            var ageAnimal = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le poids de l'animal:");
            var poidsAnimal = Console.ReadLine();
            Console.WriteLine("Veuillez saisir la couleur de l'animal: ");
            var couleurAnimal = Console.ReadLine();
            if (!ValidationCouleur(couleurAnimal))
                AfficherMessageErreur("votre couleur n'est pas valide.........");
            while (!ValidationCouleur(couleurAnimal))
            {
                Console.WriteLine("Veuillez saisir la couleur de l'animal: ");
                couleurAnimal = Console.ReadLine();
                AfficherMessageErreur("votre couleur n'est pas valide.........");

            }
            Console.WriteLine("Veuillez saisir le nom du proprietaire: ");
            var nomProprietaireAnimal = Console.ReadLine();

            //on insere les informations saisies dans le tableau

            tableau[index, 0] = index.ToString();
            tableau[index, 1] = type;
            tableau[index, 2] = nomAnimal;
            tableau[index, 3] = ageAnimal;
            tableau[index, 4] = poidsAnimal;
            tableau[index, 5] = couleurAnimal;
            tableau[index, 6] = nomProprietaireAnimal;
            ++nombreCourantAnimaux;

        }
        // fonction qui permet de traiter l'ajout d'un animal dans la liste
        private void TraiterAjoutAnimal()
        {
            int ligne;
            if (nombreCourantAnimaux < 10)
            {
                if (numeroID == 10) //ajout simplement possible entre 0 et 9
                {
                    ligne = RechercheLigneVide();
                    Ajouter2UnAnimal(ligne);


                }
                else if (numeroID < 10)
                {
                    ligne = RechercheLigneVide(); // entre 0 et numeroID
                    if (ligne == 0) // sil y'a pas de ligne vide entre 0 et numeroID
                    {
                        Ajouter2UnAnimal(ligne); // ajouter en fin du tableau

                    }
                    else if (ligne < 0) //pas de ligne vide
                    {
                        AjouterUnAnimal();

                    }
                    else
                    {
                        Ajouter2UnAnimal(ligne);
                    }
                }

            }
            else
            {
                Console.WriteLine("Taille maximale en ligne du tableau atteinte");
            }

        }
        private  static bool ValidationCouleur(string couleur)
        {
            return couleur == "bleu" || couleur == "rouge" || couleur == "violet";
        }


    }


}


