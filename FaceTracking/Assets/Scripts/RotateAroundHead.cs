using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotateAroundHead : MonoBehaviour
{
    public GameObject Apple4;

    private float centrex, centrey, x, y,angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        CalculateCentre();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCentre();
        if (angle > 210f && angle < 330f)
            {
             Apple4.SetActive(false);
            }
        else
        {
           Apple4.SetActive(true);
        }
        x = centrex + 0.12f * Mathf.Cos(Mathf.Deg2Rad*angle);
        y = centrey - 0.12f * Mathf.Sin(Mathf.Deg2Rad*angle);
        Apple4.transform.position = new Vector3(x,transform.position.y,y);
        angle += 1.25f;
        if(angle == 360f)
        {
            angle = 0;
        }
    }
    public void CalculateCentre()
    {
        centrex = transform.position.x;
        centrey = transform.position.z;
    }
   
}
