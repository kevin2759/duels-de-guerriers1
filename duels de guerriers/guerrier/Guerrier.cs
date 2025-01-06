using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;

public class Guerrier
{
    // Attributs privés
    private string nom;
    private int pointsDeVie;
    private int nbDesAttaque;

    // Constructeur
    public Guerrier(string nom, int pointsDeVie, int nbDesAttaque)
    {
        this.nom = nom;
        this.pointsDeVie = pointsDeVie;
        this.nbDesAttaque = nbDesAttaque;
    }

    // Getters et Setters
    public string GetNom() => nom;
    public int GetPointsDeVie() => pointsDeVie;
    public void SetPointsDeVie(int pointsDeVie) => this.pointsDeVie = pointsDeVie;
    public int GetNbDesAttaque() => nbDesAttaque;

    // Afficher les informations du guerrier
    public void AfficherInfos()
    {
        Console.WriteLine($"{nom}{{PV={pointsDeVie}}}");
    }

    // Attaquer en lançant des dés
    public int Attaquer()
    {
        Random rand = new Random();
        int degats = 0;
        for (int i = 0; i < nbDesAttaque; i++)
        {
            degats += rand.Next(1, 7); // Lancer un dé (1 à 6)
        }
        return degats;
    }

    // Subir des dégâts
    public void SubirDegats(int degats)
    {
        pointsDeVie -= degats;
        if (pointsDeVie < 0)
            pointsDeVie = 0; // Ne pas avoir de points de vie négatifs
    }
}
