using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSAppleX1 : MonoBehaviour
{
    public GameObject Apple;
    private bool isReversed = false;
    private float step = 0.005f, x;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0,-0.15f);
    }

    // Update is called once per frame
    void Update()
    {
     
        Apple.transform.localPosition = new Vector3(x, Apple.transform.localPosition.y, Apple.transform.localPosition.z);
       

        if (x>0.15)
        {
            x = -0.15f;
        }
        x += 0.003f;

    }

}