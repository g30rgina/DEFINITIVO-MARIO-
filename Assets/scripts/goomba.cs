using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class goomba : MonoBehaviour
{
    //animacion para el goomba 
    public Animator goombaAnimator; 

    //direccion y velocidad 
    public float movementSpeed = 5;
    public int direction = 1;

    //muerte goomba 
    private Rigidbody2D _rigidBody2D;
    private AudioSource _audioSource;
    private BoxCollider2D _boxCollider;
    private gamemanager _gameManager;
    public int _goombaHealth = 3;
    private Slider _healthSlider;

    public AudioClip deathSFX;
    private playercontroler _playerScript;

  //  public float movementSpeed = 4;
  //  public int direction = 1;

    void Awake() 
    { 
        goombaAnimator = GetComponent<Animator>();

        _rigidBody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("game manager").GetComponent<gamemanager>();
        _healthSlider = GetComponentInChildren<Slider>();
        _playerScript = GameObject.Find("Mario_0").GetComponent<playercontroler>();
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
        if(direction > 0)
        {
            goombaAnimator.SetBool("Walk", true);
        }
        else if(direction > 0)
        {
            goombaAnimator.SetBool("Walk", false);
        }
        else
        {
            goombaAnimator.SetBool("Walk", false);
        }   
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
            StartCoroutine(_playerScript.MarioDeath());
           // Destroy(collision.gameObject);
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
        goombaAnimator.SetBool("Goomba death", true);

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


