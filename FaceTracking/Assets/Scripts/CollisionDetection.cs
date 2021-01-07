using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
    public Text debug;
    private GameObject ps1;
  
    Rigidbody rb;
    private ParticleSystem[] ps;
    private Vector3 offset;
    private void Start()
    {
     //   pointer = GameObject.Find("Pointer");
      rb = gameObject.GetComponent<Rigidbody>();
       debug = GameObject.Find("Debug").GetComponent<Text>();
        
        offset = new Vector3(0, 0, 0.02f);
        ps1 = GameObject.Find("BloodSpray");
        ps = ps1.GetComponentsInChildren<ParticleSystem>();
       
    }
    public void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(0, 0, 0);
        rb.isKinematic = true;
        transform.position = collision.GetContact(0).point + offset;
        AudioManager.instance.PlayArrowImpactSound();
        ps1.transform.position = collision.GetContact(0).point;
        gameObject.transform.parent = collision.gameObject.transform;
        if (collision.gameObject.tag == "Fruit")
            {

                debug.text = "You hit Apple";
            }
            else if (collision.gameObject.tag == "Face")
            {
                ps[0].Play();
                ps[1].Play();
               debug.text = "It's my face Motherfucker";
            }
        
    }
    public void OnDestroy()
    {
    
    }
}
