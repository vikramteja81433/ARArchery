using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSAppleY : MonoBehaviour
{
    public GameObject Apple7,Apple8;
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
     
        Apple7.transform.localPosition = new Vector3(Apple7.transform.localPosition.x, y, Apple7.transform.localPosition.z);
        Apple8.transform.localPosition = new Vector3(Apple8.transform.localPosition.x, y, Apple8.transform.localPosition.z);

        if (y>0.3)
        {
            y = 0;
        }
        y += 0.003f;

    }

}