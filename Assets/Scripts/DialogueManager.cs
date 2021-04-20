using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text NameBox;
    public Text DialogueBox;
    //public TextAsset DialogueCSVFile;

    private Queue<string> sentences;
    private Queue<string> names;

    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        names.Clear();

        /*string[] DialogueData = DialogueCSVFile.text.Split(new char[] {'\n'});

        for (int i = 1; i < DialogueData.Length; i++)
        {
            string[] DialogueLine = DialogueData[i].Split(new char[] { ';' });

            //names.Enqueue(DialogueLine[0]);
            //sentences.Enqueue(DialogueLine[1]);
        }*/

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
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

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        NameBox.text = name;
        DialogueBox.text = sentence;
    }

    void EndDialogue()
    {
        print("Dialogue ended");
    }
}
