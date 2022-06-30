using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    
    public float enemyMovementSpeed;
    public float rayLenghtWall;
    public float rayLenghtGround;
    private bool moveLeft;
    public Transform contactCheckerWall;
    public Transform contactCheckerGround;


    
    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
       
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.left * enemyMovementSpeed * Time.deltaTime);
        
    }

   private void FixedUpdate() 
   {
       int layarMask = 1 << 9;
       layarMask = ~layarMask;

        RaycastHit2D contactCheckWall = Physics2D.Raycast(contactCheckerWall.position, Vector2.left, rayLenghtWall,layarMask); 
        RaycastHit2D contactCheckGround = Physics2D.Raycast(contactCheckerGround.position, Vector2.down, rayLenghtGround,layarMask); 
                if(contactCheckWall == true)
        {
            //Debug.Log("Touching wall");
            if(moveLeft == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                moveLeft = true;
            }
        } 

        if(contactCheckGround == false)
        {

            if(moveLeft == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                moveLeft = true;
            }
        }
   }

    
}
