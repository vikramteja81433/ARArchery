using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSide : MonoBehaviour
{
    public GameObject Apple6;
    private bool clockwise = true;
    float centrex, centrey, x, y, angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        centrex = transform.localPosition.x;
        centrey = transform.localPosition.y;
        x = centrex - 0.25f * Mathf.Cos(Mathf.Deg2Rad * angle);
        y = centrey + 0.25f * Mathf.Sin(Mathf.Deg2Rad * angle);
        Apple6.transform.localPosition = new Vector3(x, y, 0);
        if (clockwise)
        {
            angle += 1.25f;
        }
        if(!clockwise)
        {
            angle -= 1.25f;
        }
        if (angle == 180)
        {

            clockwise = !clockwise;
        }
        if (angle == 0)
        {

            clockwise = !clockwise;
        }
    }
}
