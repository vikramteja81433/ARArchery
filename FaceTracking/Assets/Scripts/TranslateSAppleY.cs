using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSAppleY : MonoBehaviour
{
    public GameObject Apple;
    private bool isReversed = false;
    private float step = 0.005f, y;
    // Start is called before the first frame update
    void Start()
    {
        y = Random.Range(0,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
     
        Apple.transform.localPosition = new Vector3(Apple.transform.localPosition.x, y, Apple.transform.localPosition.z);
       

        if (y>0.3)
        {
            y = 0;
        }
        y += 0.003f;

    }

}