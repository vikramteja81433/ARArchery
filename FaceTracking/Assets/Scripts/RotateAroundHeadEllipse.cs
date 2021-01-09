using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotateAroundHeadEllipse : MonoBehaviour
{
    public GameObject Apple;
    private GameObject Face;

    private float centrex, centrey,centrez, x, y,z,temp,angle1 = 0,angle2 = 45;
    // Start is called before the first frame update
    void Start()
    {
        Face = GameObject.FindGameObjectWithTag("Face");
        CalculateCentre();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCentre();
        if (angle1 > 310f && angle1 < 360f)
        {
             Apple.SetActive(false);
        }
        if(angle1 < 90)
        {
           Apple.SetActive(false);
        }
        if(angle1 >= 90 && angle1 <=300)
        {
            Apple.SetActive(true);
        }
        temp =  0.15f * Mathf.Cos(Mathf.Deg2Rad*angle1);
        y = centrey+ - 0.15f * Mathf.Sin(Mathf.Deg2Rad*angle1);
        x = centrex + temp * Mathf.Cos(Mathf.Deg2Rad * angle2);
        z = centrez + temp * Mathf.Sin(Mathf.Deg2Rad * angle2);
        Apple.transform.localPosition = new Vector3(x,y,z);
        angle1 += 1.25f;
        if(angle1 == 360f)
        {
            angle1 = 0;
        }
    }
    public void CalculateCentre()
    {
        
        centrex = Face.transform.position.x;
        centrey = Face.transform.position.y;
        centrez = Face.transform.position.z;
    }
   
}
