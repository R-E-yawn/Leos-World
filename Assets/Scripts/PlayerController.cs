using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed, jumpSpeed;
    private PlayerActionControls playerActionControls;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask ground;
    private Collider2D col;
    Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioClip deathSound;
    private AudioSource audioSource;
    public bool shieldActive = false;
    float coolDownTime = 1f;
    float coolDownTimer;

    public bool isInvincible;
    float invincibleTimer = 3f;


    public bool jumpBoot = false;
    public float jumpTime = 10f;
    float jumpTimer = 0f;
    public bool touchedBottom = false;


    // Start is called before the first frame update
    void Awake()
    {
        playerActionControls = new PlayerActionControls();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Jump()
    {
        if (isGrounded())
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }

    void Start()
    {
        playerActionControls.Land.Jump.performed += _ => Jump();
        deathSound = (AudioClip)Resources.Load("deathsound");
        coolDownTimer = coolDownTime;
        jumpTimer = jumpTime;
    }

    private bool isGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= col.bounds.extents.x;
        topLeftPoint.y += col.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += col.bounds.extents.x;
        bottomRightPoint.y -= col.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        
        Shield();
        Debug.Log("shieldActive: " + shieldActive);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0f)
                isInvincible = false;
        }

        
        JumpBoot();

    }

    private void Move()
    {
        //Reads the movement value of the player
        float movementInput = playerActionControls.Land.Move.ReadValue<float>();

        //Finds position of player
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;


        //Animation
        if (movementInput != 0) animator.SetBool("run", true);
        else animator.SetBool("run", false);

        //Decides whether to flip sprite
        if(movementInput == -1)
        {
            spriteRenderer.flipX = true;
        }else if(movementInput == 1)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    { 
        
        if (other.gameObject.tag == "Enemy" )
        {
            
            StartCoroutine(PlaySound()); 
        } else if (other.gameObject.tag == "BottomScreen")
        {
            touchedBottom = true;
            StartCoroutine(PlaySound());
        }
    }

    IEnumerator PlaySound()
    {
        audioSource.clip = deathSound;
        audioSource.Play();
        yield return new WaitUntil(() => audioSource.isPlaying == false);

        if (!shieldActive || touchedBottom)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            touchedBottom = false;
        }
        else
        {
           
                shieldActive = false;
            
             
                
            
            
        }
        
    }

    private void Shield()
    {
        if (shieldActive)
        {
            GetComponent<SpriteRenderer>().color = new Color(.05f, .7f, 1f); 

        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        }
        
    }

    private void JumpBoot()
    {
        
        if (jumpBoot)
        {
            jumpTimer -= Time.deltaTime;

            if (jumpTimer > 0f)
            {
                jumpSpeed = 10f;
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
            }
            else
            {
                jumpSpeed = 5f;
                jumpTimer = jumpTime;
                jumpBoot = false;
            }
            
        }
    }


}
