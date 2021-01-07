using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateApple : MonoBehaviour
{
    private float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(0,angle,0);
        angle = angle + 5f;
    }
}
