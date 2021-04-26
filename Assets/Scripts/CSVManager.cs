using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVManager : MonoBehaviour
{

    public TextAsset Quete1_Bucheron;
    //public TextAsset FinQuete1_Bucheron;
    public TextAsset Quete2_Bucheron;

    void Awake()
    {
        CSVReader.bindata = null;
    }

    void Start()
    {
        if (ButtonsManager.QueteScene == "Bucheron")
        {
            print("Le statut de la Quete1_Bucheron est : " + QuetesManager.Quete1_Bucheron);

            if (QuetesManager.Quete1_Bucheron < 2)
            {
                CSVReader.bindata = Quete1_Bucheron;
                print("je viens de charger le CSV reader");
                if (QuetesManager.Quete1_Bucheron == 0)
                {
                    print("Quete1_Bucheron == 0");
                    CSVReader.instance.LoadCSV();
                }
                if (QuetesManager.Quete1_Bucheron == 1)
                {
                    print("Quete1_Bucheron == 1");
                    CSVReader.instance.ShowRessources();
                }
            }

            if (QuetesManager.Quete1_Bucheron == 2)
            {
                CSVReader.bindata = Quete2_Bucheron;
                print("je viens de charger le CSV reader");
                if (QuetesManager.Quete2_Bucheron == 0)
                {
                    print("Quete2_Bucheron == 0");
                    CSVReader.instance.LoadCSV();
                }
                if (QuetesManager.Quete2_Bucheron == 1)
                {
                    print("Quete2_Bucheron == 1");
                    CSVReader.instance.ShowRessources();
                }
            }
        }
    }
}
