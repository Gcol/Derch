using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public static int ScoreKeeper;
    //public static int LogKeeper;
    public static bool ScoreKeeper0First;
    public static string QueteScene;
    
    public void Credits_ButtonClick() { SceneManager.LoadScene("Credits"); }
    public void Options_ButtonClick() { SceneManager.LoadScene("Options"); }
    public void Quit_ButtonClick() { Application.Quit(); }

    public void Bucheron_ButtonClick()
    {
        QueteScene = "Bucheron";
        SceneManager.LoadScene("Quetes");
    }

    public void Chateau_ButtonClick()
    {
        QueteScene = "Chateau";
        SceneManager.LoadScene("Quetes");
    }

    public void TourDeMage_ButtonClick()
    {
        QueteScene = "TourDeMage";
        SceneManager.LoadScene("Quetes");
    }

    public void FeuDeCamp_ButtonClick()
    {
        QueteScene = "FeuDeCamp";
        SceneManager.LoadScene("Quetes");
    }

    public void Mine_ButtonClick()
    {
        QueteScene = "Mine";
        SceneManager.LoadScene("Quetes");
    }
  
    public void Mini_Jeu_1_ButtonClick()
    {
        if (MainGame.LifeScore > 0)
        {
            MainGame.instance.LifeReduction();
            ScoreKeeper = MainGame.LifeScore;
            SceneManager.LoadScene("Mini Jeu 1");
        }
    }
    public void Mini_Jeu_2_ButtonClick()
    {
        if (MainGame.LifeScore > 0)
        {
            MainGame.instance.LifeReduction();
            ScoreKeeper = MainGame.LifeScore;
            SceneManager.LoadScene("Mini Jeu 2");
        }
    }
    public void Map_ButtonClick()
    {
        Sauvegarde_Reader.instance.LoadToSauvegarde();
        SceneManager.LoadScene("Map");
    }
}
