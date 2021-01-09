using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateSAppleX2 : MonoBehaviour
{
    public GameObject Apple1,Apple2;
    private float x1,x2;
    // Start is called before the first frame update
    void Start()
    {
        x1 = 0;
        x2 = -0.15f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Apple1 != null)
        {
            Apple1.transform.localPosition = new Vector3(x1, Apple1.transform.localPosition.y, Apple1.transform.localPosition.z);
        }
        if (Apple2 != null)
        {
            Apple2.transform.localPosition = new Vector3(x2, Apple2.transform.localPosition.y, Apple2.transform.localPosition.z);
        }
        
       

        if (x1>0.15f)
        {
            x1 = -0.15f;
        }
        x1 += 0.003f;
        if (x2 > 0.15f)
        {
            x2 = -0.15f;
        }
        x2 += 0.003f;

    }

}