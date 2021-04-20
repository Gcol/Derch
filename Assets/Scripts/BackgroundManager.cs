using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    
    void Start()
    {
        //Cache tous les background
        GameObject.Find("Bucheron_Background").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Chateau_Background").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("TourDeMage").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("FeuDeCamp_Background").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("Mine_Background").GetComponent<SpriteRenderer>().enabled = false;

        print(ButtonsManager.QueteScene);
        //check quel type de quete lancé pour charger le bon background
        if (ButtonsManager.QueteScene == "Bucheron")
        {
            print("Ok Bucheron");
            GameObject.Find("Bucheron_Background").GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (ButtonsManager.QueteScene == "Chateau")
        {
            print("Ok Chateau");
            GameObject.Find("Chateau_Background").GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (ButtonsManager.QueteScene == "TourDeMage")
        {
            print("Ok TourDeMage");
            GameObject.Find("TourDeMage").GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (ButtonsManager.QueteScene == "FeuDeCamp")
        {
            print("Ok FeuDeCamp");
            GameObject.Find("FeuDeCamp_Background").GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (ButtonsManager.QueteScene == "Mine")
        {
            print("Ok Mine");
            GameObject.Find("Mine_Background").GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
