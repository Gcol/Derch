using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuetesManager : MonoBehaviour
{

    public static QuetesManager instance;

    //Création de tous les statut de quêtes (pour info : 0 = Jamais lancé ; 1 = En cours ; 2 = Objectif atteint
    public static int Quete1_Bucheron = 0;
    public static int Quete2_Bucheron = 0;

    /*Quetes existantes :
     *Quete1_Bucheron
     */

    void Start()
    {
        instance = GetComponent<QuetesManager>();
    }

    public void UpdateStatutQuete(string NomQuete)
    {
        print("Augmentation statut quête : " + NomQuete);
        if (NomQuete == "Quete1_Bucheron") { Quete1_Bucheron++; }
        print(NomQuete + "= " + Quete1_Bucheron);
    }

    public void RelaunchStatutQuete(string NomQuete)
    {
        print("Réduction statut quête : " + NomQuete);
        if (NomQuete == "Quete1_Bucheron") { Quete1_Bucheron--; }
        print(NomQuete + "= " + Quete1_Bucheron);
    }

}
