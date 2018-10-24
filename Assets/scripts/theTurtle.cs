using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theTurtle : MonoBehaviour {
   
    public LayerMask isGround;
    public float speed;
    private bool wallHit;
    public Transform wallHitBox;
    public float wallHitHeight;
    public float wallHitWidth;
    // Use this for initialization
    private void Start()
    {
        
    }
    

    void FixedUpdate()
    {
       
        
        //wallHit is a bool similar to the ground one in the player code.
        //Physics2D.OverlapBox is similar to Physics2D.OverlapCircle but uses a box
        //The next is a Vector 2 with the box's Width and Height which are 
        //floats that I made public so I could edit them in the editor. 
        //The zero is the z value we don't need.
        //isGround is a LayerMask of everything that is ground.
        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        if (wallHit == true)
        {
            speed = speed * -1;
            
        }
        
       
        if ( wallHit == true && speed < 0)
       {
            Flip();
        }
       
    }
    void Flip()
    {
        wallHit = !wallHit;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    void Update()
    { 

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    }

