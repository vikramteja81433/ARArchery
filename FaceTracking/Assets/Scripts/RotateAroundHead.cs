using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotateAroundHead : MonoBehaviour
{
    public GameObject Apple;
    private GameObject Face;

    private float centrex, centrey, x, y,angle = 0;
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
        if (angle > 210f && angle < 330f)
        {
             Apple.SetActive(false);
        }
        else
        {
           Apple.SetActive(true);
        }
        x = centrex + 0.12f * Mathf.Cos(Mathf.Deg2Rad*angle);
        y = centrey - 0.12f * Mathf.Sin(Mathf.Deg2Rad*angle);
        Apple.transform.localPosition = new Vector3(x,Apple.transform.localPosition.y,y);
        angle += 1.25f;
        if(angle == 360f)
        {
            angle = 0;
        }
    }
    public void CalculateCentre()
    {
        
        centrex = Face.transform.position.x;
        centrey = Face.transform.position.z;
    }
   
}
