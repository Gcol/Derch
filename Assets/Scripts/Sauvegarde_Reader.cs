using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;
using UnityEditor;

public class Sauvegarde_Reader : MonoBehaviour
{

    public TextAsset Sauvegarde;

    public static Sauvegarde_Reader instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = GetComponent<Sauvegarde_Reader>();
    }

    public void LoadFromSauvegarde()
    {
        string[] data = Sauvegarde.text.Split(new char[] { '\n' });

        //Récupération infos ressources nécessaires
        string[] RessourcesBois = data[1].Split(new char[] { ';' });
        string Ressource_Bois = RessourcesBois[1];
        MainGame.LogRessources = int.Parse(Ressource_Bois);

        string[] RessourcesPierre = data[2].Split(new char[] { ';' });
        string Ressource_Pierre = RessourcesPierre[1];
        //Pas encore implémenté

        string[] RessourcesVie = data[3].Split(new char[] { ';' });
        string Nombre_Vie = RessourcesVie[1];
        MainGame.LifeScore = int.Parse(Nombre_Vie);

        string[] Quete1 = data[4].Split(new char[] { ';' });
        string Quete1_Bucheron = Quete1[1];
        QuetesManager.Quete1_Bucheron = int.Parse(Quete1_Bucheron);

        string[] Quete2 = data[5].Split(new char[] { ';' });
        string Quete2_Bucheron = Quete2[1];
        QuetesManager.Quete2_Bucheron = int.Parse(Quete2_Bucheron);
    }

    public void LoadToSauvegarde()
    {
        string path = "Assets/Text/Sauvegarde.csv";
        int LogRessources = MainGame.LogRessources;
        int LifeScore = MainGame.LifeScore;
        int Quete1_Bucheron = QuetesManager.Quete1_Bucheron;
        int Quete2_Bucheron = QuetesManager.Quete2_Bucheron;

        StreamWriter writer = new StreamWriter(path);
        //writer.WriteLine("Test");
        //writer.WriteLine("Ligne2");

        writer.WriteLine("Variable;Valeur");
        writer.WriteLine("Ressource_Buche;" + LogRessources.ToString());
        writer.WriteLine("Ressource_Pierre;" + "0");
        writer.WriteLine("Nombre_Vie;" + LifeScore.ToString());
        writer.WriteLine("Quete1_Bucheron;" + Quete1_Bucheron.ToString());
        writer.WriteLine("Quete2_Bucheron;" + Quete2_Bucheron.ToString());
        writer.Close();

    }
}
