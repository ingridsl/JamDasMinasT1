using System;
using UnityEngine;

/*
 * Classe: ConversationAda
 * Descrição: Ao colidir com o player, abra-se uma caixa de diálogo
 */
public class ConversartionPlayer : MonoBehaviour
{
    public GameObject exclamacao;
    bool isInside = false;
    bool started = false;
    //Expõe um campo para conectar o Script Tester e usar suas funções/atributos
    [SerializeField] Tester _tester;

    void Update()
    {
        if (isInside && Input.GetMouseButtonDown(0) && !started)
        {
            _tester.StartConvo();
            started = true;
            Destroy(exclamacao);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
         * Se o objeto colidido tiver a tag Player, chama-se a função StartConvo que abre uma caixa de diálogo
         */
        var conversartion = GetComponent<ConversartionPlayer>();
        if (other.gameObject.CompareTag("Player"))
        {
            isInside = true;
            // _tester.StartConvo();
            //Destroy(conversartion);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInside = false;
            started = false;
        }
    }

}