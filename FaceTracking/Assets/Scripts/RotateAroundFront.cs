using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotateAroundFront : MonoBehaviour
{
    public GameObject Apple5;
    float x, y, centrex, centrey, angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        centrex = transform.position.y;
        centrey = transform.position.z;
        x = centrex + 0.2f * Mathf.Sin(Mathf.Deg2Rad * angle);
        y = centrey - 0.2f * Mathf.Cos(Mathf.Deg2Rad * angle);
        Apple5.transform.position = new Vector3(0,x,y);
        angle += 1f; 
        if(angle >120 && angle <180)
        {
            Apple5.SetActive(false);
        }
        if (angle >= 0 && angle < 120)
        {
            Apple5.SetActive(true);
        }
        if(angle == 180)
        {
            angle = 0;
        }

    }
}
