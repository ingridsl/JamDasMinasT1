using System;
using UnityEngine;

public class CarConversation : MonoBehaviour
{
    [SerializeField] Tester _tester;
    private bool click;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var target = other.gameObject;
            click = Input.GetMouseButton(0);
            var anim = target.GetComponent<Animator>();
            anim.SetBool("AreaTrigger", true);
            if (target.CompareTag("Player") && click)
            {
                _tester.StartConvo();
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player") {
            var target = other.gameObject;
            var anim = target.GetComponent<Animator>();
            anim.SetBool("AreaTrigger", false);
        }
    }
}