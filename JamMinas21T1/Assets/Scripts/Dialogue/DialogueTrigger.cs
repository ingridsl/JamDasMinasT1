using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialoge;

    public void TriggerDialoge()
    {
        FindObjectOfType<DialogeManager>().StartDialoge(dialoge);
    }
}