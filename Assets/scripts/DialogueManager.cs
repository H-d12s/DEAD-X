using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import Scene Management
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    private Queue<string> sentences;
    private bool isDialogueActive = false;

    void Start()
    {
        sentences = new Queue<string>();
        
        FindObjectOfType<DialogueManager>().StartDialogue(new string[]
        {
            "Things are not looking good. It's a mess out there.",
            "People are turning into monsters. All because of HIM. He started it all. His greed for money and power has led to this.",
            "MONSTER. I SWEAR ON MY LIFE I WILL HUNT HIM DOWN UNTIL MY LAST BREATH.",
            "Now back to business. Dont be afraid. We are Amuzon . We never stop. Even if the world is falling apart.",
            "The town ahead is already done for but we have to deliver the antidotes to the people who are still alive.",
            "Now go. Im counting on you.",
            "Press SPACE to continue..."
        });
    }

    public void StartDialogue(string[] dialogueLines)
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        sentences.Clear();

        foreach (string line in dialogueLines)
        {
            sentences.Enqueue(line);
        }

        DisplayNextSentence();
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f); // Adjust for typing speed
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false); // Hide the dialogue box

        // Load the next scene (change "GameLevel" to your actual level scene name)
        SceneManager.LoadScene("truelevel1");
    }
}
