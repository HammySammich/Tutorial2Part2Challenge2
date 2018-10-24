using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
   
    private Rigidbody2D rb2d;
    private bool facingRight = true;
    public float speed;
    public float jumpForce;
    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
   

    //audio stuff
     private AudioSource source;
    public AudioClip jumpClip;
    public AudioClip coinPick;
    public int numberOfCoins;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        
       // count = 0;
        //winText.text = "";
        //SetCountText();

    }
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate ()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        Debug.Log(isOnGround);

        //Vector2 movement = new Vector2(moveHorizontal, 0);

       // rb2d.AddForce(movement * speed);

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }
        if (Input.GetKey("escape"))
            Application.Quit();

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            // count = count + 1;
            // SetCountText();
            
                float vol = Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(coinPick);
         }

        if (other.gameObject.CompareTag("PickOn")&& numberOfCoins>0)
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinPick);
            numberOfCoins = numberOfCoins - 1;


        }

    }

    //void SetCountText()
    //{
        //countText.text = "Count : " + count.ToString();
        //if (count >= 12)
        //{
            //winText.text = "You Win";
        //}
   // }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                float vol = Random.Range(volLowRange, volHighRange);

                source.PlayOneShot(jumpClip);
                
                
                rb2d.velocity = Vector2.up * jumpForce;

                
            }
        }
       

    }

}
