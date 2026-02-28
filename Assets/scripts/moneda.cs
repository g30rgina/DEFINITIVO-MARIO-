using UnityEngine;

public class moneda : MonoBehaviour
{
    public Animator monedaAnimator;
    public Rigidbody2D rigidbodyMoneda;

    private AudioSource _audioSourceMoneda;
    public AudioClip monedaSonido;
   // private gamemanager _gamemanager;
   // public SpriteRenderer _spriterender;

    void Awake()
    {

        monedaAnimator = GetComponent<Animator>();

        rigidbodyMoneda = GetComponent<Rigidbody2D>();

        _audioSourceMoneda = GetComponent<AudioSource>(); 
    
        gamemanager = GameObject.Find("game manager").GetComponent<game manager>();


    } 


    //void OnCollisionEnter2D(Collision2D monedaCollision)
    void OnTriggerEnter2D(Collider2D monedaCollision)
     {
       if (monedaCollision.gameObject.CompareTag("Player"))
        {
          //  _spriterender.enabled = false; 
          //  _gamemanager.Coins(); 
            _audioSourceMoneda.PlayOneShot(monedaSonido);  
            _gamemanager-CoinCounter();
            Destroy(gameObject, 0.5f);
        } 

    } 
}
