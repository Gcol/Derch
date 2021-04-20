using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuetesManager : MonoBehaviour
{

    public static QuetesManager instance;

    //Création de tous les statut de quêtes (pour info : 0 = Jamais lancé ; 1 = En cours ; 2 = Objectif atteint ; 4 = Terminé
    public static int Quete1_Bucheron = 0;

    void Start ()
    {
        instance = GetComponent<QuetesManager>();
    }

    public void UpdateStatutQuete (string NomQuete)
    {
        print("Augmentation statut quête : " + NomQuete);
        Quete1_Bucheron++;
        print(Quete1_Bucheron);
    }

    public void RelaunchStatutQuete (string NomQuete)
    {
        print("Réduction statut quête : " + NomQuete);
        Quete1_Bucheron--;
        print(Quete1_Bucheron);
    }

}
