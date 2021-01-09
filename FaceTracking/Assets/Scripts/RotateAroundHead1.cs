using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotateAroundHead1 : MonoBehaviour
{
    public GameObject Apple1,Apple2;
    private GameObject Face;

    private float centrex, centrey,angle1 = 0,angle2 = 180;
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
        MakeAppleRotate();
    }
    public void CalculateCentre()
    {
        
        centrex = Face.transform.position.x;
        centrey = Face.transform.position.z;
    }
    public void MakeAppleRotate()
    {
        float x = 0, y = 0;
        if (Apple1 != null)
        {
            if (angle1 > 210f && angle1 < 330f)
            {

                Apple1.SetActive(false);
            }
            if (angle1 >= 0 && angle1 <= 210f)
            {
                Apple1.SetActive(true);
            }
            x = centrex + 0.12f * Mathf.Cos(Mathf.Deg2Rad * angle1);
            y = centrey - 0.12f * Mathf.Sin(Mathf.Deg2Rad * angle1);
            Apple1.transform.localPosition = new Vector3(x, Apple1.transform.localPosition.y, y);
            angle1 += 1.25f;
        }
        if (Apple2 != null)
        {
            if (angle2 > 210f && angle2 < 330f)
            {
                Apple2.SetActive(false);
            }
            if (angle2 >= 0 && angle2 <= 210f)
            {
                Apple2.SetActive(true);
            }
            x = centrex + 0.12f * Mathf.Cos(Mathf.Deg2Rad * angle2);
            y = centrey - 0.12f * Mathf.Sin(Mathf.Deg2Rad * angle2);
            Apple2.transform.localPosition = new Vector3(x, Apple2.transform.localPosition.y, y);
            angle2 += 1.25f;
        }
        if (angle1 == 360f)
        {
            angle1 = 0;
        }

        if (angle2 == 360f)
        {
            angle2 = 0;
        }

    }
   
}
