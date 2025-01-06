using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Elfe : Guerrier
{
    public Elfe(string nom, int pointsDeVie, int nbDesAttaque)
        : base(nom, pointsDeVie, nbDesAttaque)
    {
    }

    // Redéfinir la méthode Attaquer pour infliger un minimum de dégâts
    public new int Attaquer()
    {
        Random rand = new Random();
        int degats = 0;
        for (int i = 0; i < GetNbDesAttaque(); i++)
        {
            degats += rand.Next(1, 7);
        }
        // Assurer un minimum de dégâts égaux au nombre de dés d'attaque
        if (degats < GetNbDesAttaque())
        {
            degats = GetNbDesAttaque();
        }
        return degats;
    }
}
