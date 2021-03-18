using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _board;

    bool isInside = false;

    void Update()
    {
        if (isInside && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) && !_board.gameObject.activeSelf))
        {
            OpenBoard();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && _board.gameObject.activeSelf)
        {
            close();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var target = other.gameObject;
        if (target.CompareTag("Player"))
        {
            isInside = true;
        }
    }

    public void OpenBoard()
    {
        _board.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void close()
    {
        _board.gameObject.SetActive(false);
        Time.timeScale = 1;
        isInside = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInside = false;
        }
    }
}