using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject ArrowPosition,Arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Input.mousePosition;
                 Plane plane = new Plane(Vector3.up, 0);
               float distance = 1;
            Vector3 screenpoint = new Vector3(pos.x, pos.y, 0);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenpoint);
           
                Debug.Log(worldPosition.ToString());
                //     }
            
        }
    }
}
