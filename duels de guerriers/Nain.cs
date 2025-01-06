using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class Nain : Guerrier
{
    private bool armureLourde;

    public Nain(string nom, int pointsDeVie, int nbDesAttaque, bool armureLourde)
        : base(nom, pointsDeVie, nbDesAttaque)
    {
        this.armureLourde = armureLourde;
    }

    // Redéfinir la méthode SubirDegats pour prendre en compte l'armure lourde
    public new void SubirDegats(int degats)
    {
        if (armureLourde)
        {
            degats /= 2; // Réduire les dégâts de moitié si armure lourde
        }
        base.SubirDegats(degats);
    }
}




