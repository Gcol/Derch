using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CSVReader : MonoBehaviour
{
    public GameObject CharactersPanel;
    public GameObject TextAreaPanel;
    public GameObject ObjectifsQuetesPanel;

    public Text NameBox;
    public Text DialogueBox;
    public Text BoisNeed;
    public Text PierreNeed;
    public static TextAsset bindata;

    private static string StaticBoisNeed;
    private static string StaticPierreNeed;

    public Sprite HdL;
    public Sprite G;
    public Sprite S;
    public Sprite R;

    private Queue<string> sentences;
    private Queue<string> names;

    private Queue<string> NbPersonnage;

    private Queue<string> Name1;
    private Queue<string> State1;

    private Queue<string> Name2;
    private Queue<string> State2;

    private Queue<string> Name3;
    private Queue<string> State3;

    private Queue<string> Name4;
    private Queue<string> State4;

    private GameObject temp;

    public static CSVReader instance;

    void Start()
    {
        instance = GetComponent<CSVReader>();

        BoisNeed.text = StaticBoisNeed;
        PierreNeed.text = StaticPierreNeed;

        if (bindata == null)
        {
            HideAll();
        }
    }

    public void LoadCSV()
    {

        if (bindata != null)
        {
            ShowAll();
        }

        sentences = new Queue<string>();
        names = new Queue<string>();
        NbPersonnage = new Queue<string>();
        Name1 = new Queue<string>();
        Name2 = new Queue<string>();
        Name3 = new Queue<string>();
        Name4 = new Queue<string>();
        State1 = new Queue<string>();
        State2 = new Queue<string>();
        State3 = new Queue<string>();
        State4 = new Queue<string>();

        sentences.Clear();
        names.Clear();
        NbPersonnage.Clear();
        Name1.Clear();
        Name2.Clear();
        Name3.Clear();
        Name4.Clear();
        State1.Clear();
        State2.Clear();
        State3.Clear();
        State4.Clear();

        string[] data = bindata.text.Split(new char[] { '\n' });

        //Récupération infos ressources nécessaires
        string[] Ressources = data[0].Split(new char[] { ';' });
        BoisNeed.text = Ressources[1];
        PierreNeed.text = Ressources[3];
        StaticBoisNeed = BoisNeed.text;
        StaticPierreNeed = PierreNeed.text;

        //Récupération infos dialogue
        for (int i = 2; i < data.Length - 1; i++)
        {
            string[] row = data[i].Split(new char[] { ';' });

            names.Enqueue(row[0]);
            sentences.Enqueue(row[1]);
            NbPersonnage.Enqueue(row[2]);
            Name1.Enqueue(row[3]);
            State1.Enqueue(row[4]);
            Name2.Enqueue(row[5]);
            State2.Enqueue(row[6]);
            Name3.Enqueue(row[7]);
            State3.Enqueue(row[8]);
            Name4.Enqueue(row[9]);
            State4.Enqueue(row[10]);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        //Nom et phrase 
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        NameBox.text = name;
        DialogueBox.text = sentence;

        GameObject.Find("G_Normal").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("G_Colere").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("G_Peur").GetComponent<SpriteRenderer>().enabled = false;

        GameObject.Find("R_Normal").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("R_Colere").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("R_Peur").GetComponent<SpriteRenderer>().enabled = false;

        GameObject.Find("S_Normal").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("S_Colere").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("S_Peur").GetComponent<SpriteRenderer>().enabled = false;

        GameObject.Find("HdL_Normal").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("HdL_Colere").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("HdL_Peur").GetComponent<SpriteRenderer>().enabled = false;

        //Positionnement personnages et à ajouter la mise en place état personnage
        int NbCharacter = int.Parse(NbPersonnage.Dequeue());
        string Character1 = Name1.Dequeue();
        string Character2 = Name2.Dequeue();
        string Character3 = Name3.Dequeue();
        string Character4 = Name4.Dequeue();
        string Etat1 = State1.Dequeue();
        string Etat2 = State2.Dequeue();
        string Etat3 = State3.Dequeue();
        string Etat4 = State4.Dequeue();

        if (NbCharacter == 1)
        {
            if (Etat1 != "0")
            {
                temp = GameObject.Find(Character1 + "_" + Etat1);
                temp.transform.position = new Vector3(0.8f, 0, 0);
                temp.SetActive(true);
            }
            //print("J'ai 1 personnage");
        }
        else if (NbCharacter == 2)
        {
            if (Etat1 != "0")
            {
                temp = GameObject.Find(Character1 + "_" + Etat1);
                temp.transform.position = new Vector3(0.1f, 0, 0);
                temp.SetActive(true);
            }

            if (Etat2 != "0")
            {
                temp = GameObject.Find(Character2 + "_" + Etat2);
                temp.transform.position = new Vector3(1.65f, 0, 0);
                temp.SetActive(true);
            }
            //print("J'ai 2 personnage");
        }
        else if (NbCharacter == 3)
        {
            if (Etat1 != "0")
            {
                temp = GameObject.Find(Character1 + "_" + Etat1);
                temp.transform.position = new Vector3(-0.8f, 0, 0);
                temp.SetActive(true);
            }

            if (Etat2 != "0")
            {
                temp = GameObject.Find(Character2 + "_" + Etat2);
                temp.transform.position = new Vector3(0.8f, 0, 0);
                temp.SetActive(true);
            }

            if (Etat3 != "0")
            {
                temp = GameObject.Find(Character3 + "_" + Etat3);
                temp.transform.position = new Vector3(2.4f, 0, 0);
                temp.SetActive(true);
            }

            //print("J'ai 3 personnage");
        }
        else if (NbCharacter == 4)
        {

            if (Etat1 != "0")
            {
                temp = GameObject.Find(Character1 + "_" + Etat1);
                temp.GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find(Character1 + "_" + Etat1).transform.position = new Vector3(-2.5f, 0, 0); //-1,65f
            }

            if (Etat2 != "0")
            {
                temp = GameObject.Find(Character2 + "_" + Etat2);
                temp.GetComponent<SpriteRenderer>().enabled = true;
                temp.transform.position = new Vector3(-1f, 0, 0); //0,1f
            }

            if (Etat3 != "0")
            {
                temp = GameObject.Find(Character3 + "_" + Etat3);
                temp.GetComponent<SpriteRenderer>().enabled = true;
                temp.transform.position = new Vector3(1f, 0, 0); //1,65f
            }

            if (Etat4 != "0")
            {
                temp = GameObject.Find(Character4 + "_" + Etat4);
                GameObject.Find(Character4 + "_" + Etat4).GetComponent<SpriteRenderer>().enabled = true;
                temp.transform.position = new Vector3(2.5f, 0, 0); //3f
            }

            //print("J'ai 4 personnage");
        }
        else
        {
            print("On a un problème sur le nombre de personnage");
        }
    }

    void EndDialogue()
    {
        print("Dialogue ended");
        ShowRessources();
        QuetesManager.instance.UpdateStatutQuete(bindata.name);
    }

    public void ShowRessources()
    {
        CharactersPanel.SetActive(false);
        TextAreaPanel.SetActive(false);
        ObjectifsQuetesPanel.SetActive(true);
    }

    public void ValidateRessources()
    {
        int ActualBois = int.Parse(MainGame.instance.Log.text);
        int BoisNeeded = int.Parse(BoisNeed.text);
        print("J'ai ce stock de bois :" + ActualBois);
        print("Jai besoin de ce stock de bois : " + BoisNeeded);

        if (ActualBois >= BoisNeeded)
        {
            ActualBois -= BoisNeeded;
            print("Actual Bois = " + ActualBois);

            //ButtonsManager.LogKeeper = ActualBois;
            MainGame.LogRessources = ActualBois;

            print("Je viens de retirer le bois nécessaire");

            QuetesManager.instance.UpdateStatutQuete(bindata.name);
            SceneManager.LoadScene("Map");
            //SceneManager.LoadScene("End");
            bindata = null;
        }

    }

    public void HideAll()
    {
        CharactersPanel.SetActive(false);
        TextAreaPanel.SetActive(false);
        ObjectifsQuetesPanel.SetActive(false);
    }

    public void ShowAll()
    {
        CharactersPanel.SetActive(true);
        TextAreaPanel.SetActive(true);
        ObjectifsQuetesPanel.SetActive(false);
    }

    public void RelaunchDialogue()
    {
        QuetesManager.instance.RelaunchStatutQuete(bindata.name);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
