using UnityEngine;

public class groundsensor : MonoBehaviour
{    
    playercontroler _playerScript;

    public BoxCollider2D deathZone;

    void Awake()
    {
        _playerScript = GetComponentInParent<playercontroler>(); 
        deathZone = GameObject.Find("Death Zone").GetComponent<BoxCollider2D>();
    }

    public bool isGrounded;



    void OntriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }

    
        if (collision.gameObject.layer == 7)
        {
            //Destroy(collision.gameObject);
            goomba _enemyScript = collision.gameObject.GetComponent<goomba>();
            _enemyScript.TakeDamage();
         }

        if (collision.gameObject.CompareTag("DeathZone"))
        {
            StartCoroutine(_playerScript.MarioDeath());
            _playerScript.Bounce();
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)

        {
            isGrounded = false;
        }
    }
}