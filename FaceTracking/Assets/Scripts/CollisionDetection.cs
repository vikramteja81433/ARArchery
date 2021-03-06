﻿using System;
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
                if(collision.gameObject.name == "Apple1")
                {
                GameManager.instance.isApple1 = false;
                }
                if (collision.gameObject.name == "Apple2")
                {
                GameManager.instance.isApple1 = false;
                }
               if (collision.gameObject.name == "Apple3")
                {
                GameManager.instance.isApple1 = false;
                }
                GameManager.instance.appleCount--;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if (collision.gameObject.tag == "Face")
            {
                ps[0].Play();
                ps[1].Play();
              
            }     
    }
}
