using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class goomba : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private AudioSource _audioSource;
    private BoxCollider2D _boxCollider;
    private gamemanager _gameManager;

    public AudioClip deathSFX;

    public float movementSpeed = 4;
    public int direction = 1;
    private int _goombaHealth = 3;
    private Slider _healthSlider;

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("game manager").GetComponent<gamemanager>();
        _healthSlider = GetComponentInChildren<Slider>();
        // _playerScript = GameObject.Find("Mario_0").GetComponent<PlayerControler>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _healthSlider.maxValue = _goombaHealth; 
        _healthSlider.maxValue = _goombaHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    void FixedUptade()
    {
        _rigidBody2D.linearVelocity = new Vector2(direction * movementSpeed, _rigidBody2D.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tuberias") || collision.gameObject.layer == 7)
        {
            //ESTO HACE LO MISMO QUE LA LINEAS DE ABAJO PERO DE FORMA MAS INTUITIVA
            //direction = direction * -1;
            direction *= -1;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

      public void TakeDamage()
    {
        _goombaHealth--;
        _healthSlider.value = _goombaHealth;

        if(_goombaHealth <= 0)
        { 
            GoombaDeath();
        }
    }

    public void GoombaDeath()
    {

        _gameManager.Addkill();
        _audioSource.PlayOneShot(deathSFX);
        movementSpeed = 0;
        _boxCollider.enabled = false;
        Destroy(gameObject,1);
    }
}    

         //_animator.SetBool("Goomba death", true);
        //_audioSource.PlayOneShot(deathSFX);

        //movementSpeed = 0;

        //_boxCollider.enabled = false;

        //Destroy(gameObject, 1);
      
        // _audioSource.clip = deathSFX;
        // _audioSource.Play(); 


