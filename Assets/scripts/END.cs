using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour {

 

    private AudioSource source;
    public AudioClip endClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    // Use this for initialization
    void Start()
    {
       
    }
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        




    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(endClip);
           
           
            
        }
    }

    

}


