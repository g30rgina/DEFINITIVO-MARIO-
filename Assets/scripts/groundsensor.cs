using UnityEngine;

public class groundsensor : MonoBehaviour
{    
    playercontroler _playerScript;

    void Awake()
    {
        _playerScript = GetComponentInParent<playercontroler>();
    }

    public bool isGrounded;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        } 
        
        if(collision.gameObject.layer == 7) 
        {
          goomba _enemyScript = collision.gameObject.GetComponent<goomba>();
          _enemyScript.TakeDamage();

          _playerScript.Bounce(); 
        } 
    }

    void OntriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }

    
        if (collision.gameObject.layer == 7)
        {
            //Destroy(collision.gameObject);
            goomba _enemyScript = collision.gameObject.GetComponent<goomba>();
            _enemyScript.TakeDamage();

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