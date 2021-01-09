using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public GameObject ArrowPosition,Arrow,tmpArrow;
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
                
            Vector3 screenpoint = new Vector3(pos.x, pos.y, 20);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenpoint);
       //     tmpArrow = Instantiate(Arrow,ArrowPosition.transform.position,ArrowPosition.transform.rotation);
            tmpArrow.transform.LookAt(worldPosition, -Arrow.transform.up);
         tmpArrow.GetComponent<Rigidbody>().AddForce(Arrow.transform.up * 100);
            Debug.Log(worldPosition.ToString());
                //     }
            
        }
    }
}
