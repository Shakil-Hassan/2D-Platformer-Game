using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public HealthController playerHealthController;
    public GameOverController gameOverController;
    private Rigidbody2D playerRigidBody;
    public int enemyDamage;
     [SerializeField] private HealthController _healthController;
    public float speed;
    public float jump;
    public int scoreValue;
    
    public isGrounded isPlayerGrounded;
    private bool falling = false;
    private bool playerDead = false;
    public ScoreController scoreController;//Score Controller
    private SpriteRenderer spriteR;

    public BoxCollider2D collider;

    public Vector2 standingSize;//Player Standing size
    public Vector2 standingOffset;//Player Croucing Offset 
    public Vector2 crouchingSize;//
    public Vector2 crouchingOffset;



    public void PickUpKey()
    {
        //Debug.Log("Player Picked Up the Key");
        scoreController.IncreaseScore(scoreValue);
    }
    //Player death
    public void playerDeathAnimation()
    {
        
        animator.SetBool("Fall", true);

        
    }


    public void killPlayer()
    {
        _healthController.playerHealth = _healthController.playerHealth - enemyDamage;
        _healthController.UpdateHealth();
        gameOverController.EndGame();
    }
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();

    }
    

   

    // Update is called once per frame
    void Update()
    {
        if(playerHealthController.playerHealth > 0)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Jump");
            MoveCharacter(horizontal, vertical);
            PlayerAnimationMovement(horizontal, vertical);
            PlayerCrouch();
        }

    }

    //Character Movement
    private void MoveCharacter(float horizontal, float vertical)
    {
        //horizontal
        Vector3 position = transform.position;
        position.x += horizontal *speed * Time.deltaTime;
        transform.position = position;

        //vertical
       if(vertical > 0 && isPlayerGrounded.isOnGrounded == true)
       {
           playerRigidBody.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
       }

    }
    //Player Movement Animation 
    private void PlayerAnimationMovement(float horizontal, float vertical)
    {
        //Animation : actual player movement along x axis
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

         //Jump animation along y axis
        if(vertical > 0 )
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

       

    }

    //Crouch

    private void PlayerCrouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {

            // spriteR.sprite = Crouching;
            animator.SetBool("Crouch", true);
            collider.size = crouchingSize;
            collider.offset = crouchingOffset;
        }

        if(Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("Crouch", false);
            //spriteR.sprite = Standing;
            collider.size = standingSize;
            collider.offset = standingOffset;
        }
    }

    
}
