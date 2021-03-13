using UnityEngine;

public class Tester : MonoBehaviour
{
    public Conversation convo;

    public void StartConvo()
    {
        DialogueManager.StartConversation(convo);
    }
}