using UnityEngine;

public class Bandera : MonoBehaviour
{

    public gamemanager _gameManager;
    public BoxCollider2D _boxCollider;
   


    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<gamemanager>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _boxCollider.enabled = false;
            StartCoroutine(_gameManager.Win());
        }
        

    }
}
