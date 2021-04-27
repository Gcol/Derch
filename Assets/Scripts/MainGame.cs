using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    public static MainGame instance;

    public Text Life;
    public Text Log;
    public static int LifeScore = 5;
    public static int LogRessources = 0;
    

    public void Start()
    {
        instance = GetComponent<MainGame>();
        /*if (ButtonsManager.ScoreKeeper0First == false )
        {
            LifeScore = int.Parse(Life.text);
            ButtonsManager.ScoreKeeper0First = true;
        }
        else
        {
            LifeScore = ButtonsManager.ScoreKeeper;
            //Log.text = ButtonsManager.LogKeeper.ToString();

        }*/

        Sauvegarde_Reader.instance.LoadFromSauvegarde();

        TextUpdate();
    }

    public void TextUpdate()
    {
        Life.text = LifeScore.ToString();
        Log.text = LogRessources.ToString();
        print("Je viens de mettre à jour les infos HUD de MainGame");
        print("LifeScore = " + LifeScore.ToString());
        print("LogRessources = " + LogRessources.ToString());
    }

    public void LifeReduction()
    {
        LifeScore--;
    }
}
