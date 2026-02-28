using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class playercontroler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 startPosition;
    public float movementSpeed = 5;
    //public float bounceForce = 10;
    public int direction = 5;

    private InputAction moveAction;
    public Vector2 moveDirection;  
    private InputAction jumpAction;
    private InputAction _pauseAction;

    public float bounceForce = 4;
    private gamemanager _gameManager;
    private bgmmanager _bgmManagerScript;
    private BoxCollider2D _boxCollider;
    private AudioClip deathSFXMario;

    public Rigidbody2D rBody2D;
    private SpriteRenderer render;
    private groundsensor sensor;
    private Animator animator;

    private AudioSource _audioSourceSalto;
    public AudioClip saltoSonido;

    public AudioClip win;

    public float jumpForce = 10; 
       //  public Vector3 intialPosition;
       //  public Vector3 finalPosition;

       // private InputAction jumpAction;
       // private InputAction _pauseAction;


    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        sensor = GetComponentInChildren<groundsensor>();
        animator = GetComponent<Animator>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<gamemanager>(); 

        _audioSourceSalto = GetComponent<AudioSource>();
        deathSFXMario = GetComponent<AudioClip>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<gamemanager>(); 

        
        moveAction = InputSystem.actions["Move"]; 
        jumpAction = InputSystem.actions["Jump"];
        _pauseAction = InputSystem.actions["Pause"];
    }
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.position = startPosition;
    }


    void Uptade()
    { 
        if(_pauseAction.WasPressedThisFrame()) 
        { 
            _gameManager.Pause(); 
        }

        if(_gameManager._pause == true) 
        { 
            return;  
        }
        moveDirection = moveAction.ReadValue<Vector2>();
        transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);


        if(moveDirection.x > 0)
        { 
             render.flipX = false; 
             animator.SetBool("IsRunning",true);
        }
        else if(moveDirection.x < 0) 
        { 
            render.flipX = true; 
            animator.SetBool("IsRunning",true);    
        }
        else 
        { 
            animator.SetBool("IsRunning",false);
        }

        if(jumpAction.WasPressedThisFrame() && sensor.isGrounded)
        { 
           rBody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            _audioSourceSalto.PlayOneShot(saltoSonido);
        }

        animator.SetBool("IsJumping",!sensor.isGrounded); 

    } 
    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);
    } 

    public void Bounce()
    {
        rBody2D.linearVelocity = new Vector2(rBody2D.linearVelocity.x, 0);
        rBody2D.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
    } 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Win")
        {
            _bgmManagerScript.Win();
            _audioSourceSalto.PlayOneShot(win);
        }
    }

    public IEnumerator MarioDeath()
    {
        _boxCollider.enabled = false;
        _bgmManagerScript.StopBGM();
        animator.SetBool("IsDeath", true);
        _audioSourceSalto.PlayOneShot(deathSFXMario);
        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
        
        _gameManager.GameOver();
    }
}








        //moveAction = InputSystem.actions["Move"];
        //JumpAction = InputSystem.actions["Jump"];

        //rBody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
   // }

    // Update is called once per frame
    //void Update()
    //{ 
     //   if(_gameManager._pause == true);
     //   moveDirection = moveAction.ReadValue<Vector2>();
        //transform.position = new Vector3(transform.position.x + direction * movementSpeed * Time.deltatime, transform.position.y, transform.position.z);

        //transform.Translate(new Vector3(direction * movementSpeed * Time.deltaTime, 0,0));

        //transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(10, 0, 0), movementSpeed * Time.deltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, new Vector2 (transform.position.x + direction, transform.position.y), movementSpeed * Time.deltaTime);


       // transform.position = new Vector3(transform.position.x + moveDirection.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        //transform.position = new Vector3(transform.position.x * movementSpeed * Time.deltaTime, transform.position.y, transform.position.z);
       // if (moveDirection.x > 0)
        //{
            //render.flipX = false;
           // animator.SetBool("IsRunning", true);
       // }
        //else if (moveDirection.x < 0)
        //{
         ////   render.flipX = true;
         //   animator.SetBool("IsRunning", true);
       // }
       // else
      //  {
       //     animator.SetBool("IsRunning", false);
      //  }

      //  if (JumpAction.WasPressedThisFrame() && sensor.isGrounded)
      //  {
       //     rBody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
     //   }
      //  animator.SetBool("IsJumping", sensor.isGrounded);

     //   Bounce();

   // }
            
//}
