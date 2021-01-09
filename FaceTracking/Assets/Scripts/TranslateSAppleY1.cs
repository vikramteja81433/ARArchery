using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSAppleY1 : MonoBehaviour
{
    public GameObject Apple1,Apple2;
    private bool isReversed = false;
    private float step = 0.005f, y1,y2;
    // Start is called before the first frame update
    void Start()
    {
        y1 = Random.Range(0,0.1f);
        y2 = Random.Range(0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Apple1 != null)
        {
            Apple1.transform.localPosition = new Vector3(Apple1.transform.localPosition.x, y1, Apple1.transform.localPosition.z);
        }
        if (Apple2 != null)
        {
            Apple2.transform.localPosition = new Vector3(Apple2.transform.localPosition.x, y2, Apple2.transform.localPosition.z);
        }
        
       

        if (y1>0.3)
        {
            y1 = 0;
        }
        y1 += 0.003f;
        if (y2 > 0.3)
        {
            y2 = 0;
        }
        y2 += 0.003f;
        if(y2>0 && y2<0.15f)
        {
            if (Apple2 != null)
            {
                Apple2.SetActive(false);
            }
        }
        if (y2 >= 0.15 && y2 < 0.3f)
        {
            if (Apple2 != null)
            {
                Apple2.SetActive(true);
            }
        }
    }

}