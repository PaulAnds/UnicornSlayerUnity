using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogeManager : MonoBehaviour
{

    public Dialoge dialoge;
    Queue<string> sentences;
    public GameObject dialogePanel;
    public TextMeshProUGUI displayText;
    string activeSentence;
    public float typingSpeed;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void StartDialoge()
    {
        sentences.Clear();

        foreach (string sentence in dialoge.sentenceList)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void DisplayNextSentence()
    {
        if(sentences.Count <= 0)
        {
            displayText.text = activeSentence;
            return;
        }
        activeSentence = sentences.Dequeue();
        displayText.text = activeSentence;

        StopAllCoroutines();
        StartCoroutine(TypeTheSentence(activeSentence));
    }

    IEnumerator TypeTheSentence(string sentence)
    {
        displayText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            displayText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            dialogePanel.SetActive(true);
            StartDialoge();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E) && displayText.text == activeSentence)
            {
                DisplayNextSentence(); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            dialogePanel.SetActive(false);
            StopAllCoroutines();
        }
    }
}
