

class Program
{
    public static void Main(string[] args)
    {
        // Création de deux guerriers
        Guerrier Aragorn = new Guerrier("Aragorn", 35, 3);
        Guerrier Boromir = new Guerrier("Boromir", 30, 4);

        // Affichage des informations initiales
        Aragorn.AfficherInfos();
        Boromir.AfficherInfos();

        // Simuler un duel
        Console.WriteLine("\nDébut du duel!\n");

        while (Aragorn.GetPointsDeVie() > 0 && Boromir.GetPointsDeVie() > 0)
        {
            // Aragorn attaque
            int degatsAragorn = Aragorn.Attaquer();
            Console.WriteLine($"Aragorn attaque et inflige {degatsAragorn} dégâts.");
            Boromir.SubirDegats(degatsAragorn);
            Boromir.AfficherInfos();

            // Vérifier si Boromir est toujours en vie
            if (Boromir.GetPointsDeVie() <= 0)
            {
                Console.WriteLine("Boromir a été vaincu!");
                break;
            }

            // Boromir attaque
            int degatsBoromir = Boromir.Attaquer();
            Console.WriteLine($"Boromir attaque et inflige {degatsBoromir} dégâts.");
            Aragorn.SubirDegats(degatsBoromir);
            Aragorn.AfficherInfos();

            // Vérifier si Aragorn est toujours en vie
            if (Aragorn.GetPointsDeVie() <= 0)
            {
                Console.WriteLine("Aragorn a été vaincu!");
                break;
            }
        }

        // Test avec Nain et Elfe
        Console.WriteLine("\nDébut du duel Nain vs Elfe!\n");

        Nain gimli = new Nain("Gimli", 40, 2, true);
        Elfe legolas = new Elfe("Legolas", 25, 5);

        gimli.AfficherInfos();
        legolas.AfficherInfos();

        while (gimli.GetPointsDeVie() > 0 && legolas.GetPointsDeVie() > 0)
        {
            // Legolas attaque
            int degatsLegolas = legolas.Attaquer();
            Console.WriteLine($"Legolas attaque et inflige {degatsLegolas} dégâts.");
            gimli.SubirDegats(degatsLegolas);
            gimli.AfficherInfos();

            // Vérifier si Gimli est toujours en vie
            if (gimli.GetPointsDeVie() <= 0)
            {
                Console.WriteLine("Gimli a été vaincu!");
                break;
            }

            // Gimli attaque
            int degatsGimli = gimli.Attaquer();
            Console.WriteLine($"Gimli attaque et inflige {degatsGimli} dégâts.");
            legolas.SubirDegats(degatsGimli);
            legolas.AfficherInfos();

            // Vérifier si Legolas est toujours en vie
            if (legolas.GetPointsDeVie() <= 0)
            {
                Console.WriteLine("Legolas a été vaincu!");
                break;
            }


        }
       
        
            List<Guerrier> guerriers = new List<Guerrier>();
            bool continuer = true;

            // Affichage du menu
            while (continuer)
            {
                Console.Clear();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Créer un guerrier");
                Console.WriteLine("2. Afficher la liste des guerriers");
                Console.WriteLine("3. Lancer un tournoi");
                Console.WriteLine("4. Quitter");
                Console.Write("Choisissez une option : ");

                int choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        // Créer un guerrier
                        CreerGuerrier(guerriers);
                        break;

                    case 2:
                        // Afficher la liste des guerriers
                        AfficherGuerriers(guerriers);
                        break;

                    case 3:
                        // Lancer le tournoi
                        LancerTournoi(guerriers);
                        break;

                    case 4:
                        // Quitter
                        continuer = false;
                        break;

                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }
            }
        }

        // Fonction pour créer un guerrier
        private static void CreerGuerrier(List<Guerrier> guerriers)
        {
            Console.Clear();
            Console.WriteLine("Créer un guerrier");
            Console.Write("Entrez le nom du guerrier : ");
            string nom = Console.ReadLine();

            Console.Write("Entrez les points de vie : ");
            int pointsDeVie = int.Parse(Console.ReadLine());

            Console.Write("Entrez le nombre de dés d'attaque : ");
            int nbDesAttaque = int.Parse(Console.ReadLine());

            Console.WriteLine("Choisissez le type de guerrier :");
            Console.WriteLine("1. Guerrier");
            Console.WriteLine("2. Nain");
            Console.WriteLine("3. Elfe");
            Console.Write("Votre choix : ");
            int type = int.Parse(Console.ReadLine());

            Guerrier guerrier;

            switch (type)
            {
                case 1:
                    guerrier = new Guerrier(nom, pointsDeVie, nbDesAttaque);
                    break;

                case 2:
                    Console.Write("Le Nain porte-t-il une armure lourde ? (true/false) : ");
                    bool armureLourde = bool.Parse(Console.ReadLine());
                    guerrier = new Nain(nom, pointsDeVie, nbDesAttaque, armureLourde);
                    break;

                case 3:
                    guerrier = new Elfe(nom, pointsDeVie, nbDesAttaque);
                    break;

                default:
                    Console.WriteLine("Type invalide. Création d'un guerrier standard.");
                    guerrier = new Guerrier(nom, pointsDeVie, nbDesAttaque);
                    break;
            }

            guerriers.Add(guerrier);
            Console.WriteLine($"Guerrier {guerrier.GetNom()} créé!");
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }

        // Fonction pour afficher la liste des guerriers
        private static void AfficherGuerriers(List<Guerrier> guerriers)
        {
            Console.Clear();
            Console.WriteLine("Liste des Guerriers :");
            foreach (var guerrier in guerriers)
            {
                guerrier.AfficherInfos();
            }
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }

        // Fonction pour lancer le tournoi
        private static void LancerTournoi(List<Guerrier> guerriers)
        {
            if (guerriers.Count < 2)
            {
                Console.Clear();
                Console.WriteLine("Il y a trop peu de guerriers pour lancer un tournoi.");
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Démarrage du tournoi...\n");

            Random rand = new Random();
            while (guerriers.Count > 1)
            {
                // Sélectionner deux guerriers au hasard pour se battre
                int index1 = rand.Next(guerriers.Count);
                int index2;
                do
                {
                    index2 = rand.Next(guerriers.Count);
                } while (index1 == index2);

                Guerrier guerrier1 = guerriers[index1];
                Guerrier guerrier2 = guerriers[index2];

                Console.WriteLine($"Le combat commence entre {guerrier1.GetNom()} et {guerrier2.GetNom()}!");

                // Simuler le combat
                while (guerrier1.GetPointsDeVie() > 0 && guerrier2.GetPointsDeVie() > 0)
                {
                    int degats1 = guerrier1.Attaquer();
                    Console.WriteLine($"{guerrier1.GetNom()} attaque et inflige {degats1} dégâts.");
                    guerrier2.SubirDegats(degats1);
                    guerrier2.AfficherInfos();

                    if (guerrier2.GetPointsDeVie() <= 0)
                    {
                        Console.WriteLine($"{guerrier2.GetNom()} est vaincu!");
                        guerriers.RemoveAt(index2);
                        break;
                    }

                    int degats2 = guerrier2.Attaquer();
                    Console.WriteLine($"{guerrier2.GetNom()} attaque et inflige {degats2} dégâts.");
                    guerrier1.SubirDegats(degats2);
                    guerrier1.AfficherInfos();

                    if (guerrier1.GetPointsDeVie() <= 0)
                    {
                        Console.WriteLine($"{guerrier1.GetNom()} est vaincu!");
                        guerriers.RemoveAt(index1);
                        break;
                    }
                }

                // Attendre avant le prochain combat
                Console.WriteLine("Appuyez sur une touche pour le prochain combat...");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine($"Le gagnant du tournoi est {guerriers[0].GetNom()}!");
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
    }












