using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _board;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var target = other.gameObject;
        if (target.CompareTag("Player"))
        {
            OpenBoard();
        }
    }

    public void OpenBoard()
    {
        _board.gameObject.SetActive(true);
    }

    public void close()
    {
        _board.gameObject.SetActive(false);
    }
}