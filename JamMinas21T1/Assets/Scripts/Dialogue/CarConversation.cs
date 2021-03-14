using UnityEngine;

public class CarConversation : MonoBehaviour
{
    [SerializeField] Tester _tester;
    private bool click;
    private void OnTriggerStay2D(Collider2D other)
    {
        var target = other.gameObject;
        click = Input.GetMouseButton(0);
        var anim = GetComponent<Animator>();
        if (target.CompareTag("Player") && click)
        {
            _tester.StartConvo();
        }
    }
    
    
}
