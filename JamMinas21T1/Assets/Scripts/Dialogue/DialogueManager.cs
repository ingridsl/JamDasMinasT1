using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialogue, navButtonText;
    public Image speakerSprite;
    // public Canvas painel;
    
    private int currentIndex;
    private Conversation currentConvo;
    private static DialogueManager instance;
    private Animator anim;
    private Coroutine typing;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            // anim = GetComponent<Animator>();
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReadNext();
        }
    }

    public static void StartConversation(Conversation convo)
    {
        // instance.anim.SetBool("isOpen", true);
        var child = instance.transform.GetChild(0);
        child.gameObject.SetActive(true);
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialogue.text = "";
        instance.navButtonText.text = ">";

        instance.ReadNext();
    }

    public void ReadNext()
    {
        if (currentConvo != null) {
            if (currentIndex > currentConvo.GetLength())
            {
                // instance.anim.SetBool("isOpen", false);
                var child = instance.transform.GetChild(0);
                child.gameObject.SetActive(false);
                Time.timeScale = 1;
                return;
            }
            speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();

            StopAllCoroutines();
            instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialogue));
            speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
            currentIndex++;
            Time.timeScale = 0;
        }
    }

    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        foreach(char letter in text.ToCharArray())
        {
            dialogue.text += letter;
            yield return new WaitForSecondsRealtime(0.025f);
        }

    }

    public void CloseDialogue()
    {
        instance.anim.SetBool("isOpen", false);
    }

}