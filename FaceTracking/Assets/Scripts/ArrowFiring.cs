using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using System;

public class ArrowFiring : MonoBehaviour
{
    public GameObject ArrowPosition;
    public GameObject arrow,cam,session;
    private GameObject temparrow;
    public Text Debug;
    int i = 0;
    private float angle = 0;  
    private Vector3 screenpoint, worldPosition;
    public GameObject pointer;
  
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {             
    }
    // Update is called once per frame
    void Update()
    {
         ShowPointer();
        if(Input.touchCount == 1  && Input.GetTouch(0).phase == TouchPhase.Began)
        {       
                Touch touch = Input.GetTouch(0);
                Vector2 pos = touch.position;
                screenpoint = new Vector3(pos.x, pos.y, 0.2f);
                worldPosition = Camera.main.ScreenToWorldPoint(screenpoint);
                if (temparrow == null)
               {
                AudioManager.instance.PlayArrowReleaseSound();
                GameManager.instance.arrowCount -= 1;
                temparrow = Instantiate(arrow, ArrowPosition.transform.position, arrow.transform.rotation);         
                temparrow.transform.parent = GameManager.instance.tmpface.transform;
                temparrow.GetComponent<Rigidbody>().AddForce(temparrow.transform.up * 75);
                pointer.SetActive(false);
                StartCoroutine(ShowPointerAgain());
             }          
        }      
    }

    public void ShowPointer()
    {        
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
               
                 pointer.transform.position = hit.point;
            }   
    }
    public IEnumerator ShowPointerAgain()
    {
        yield return new WaitForSeconds(1);
        pointer.SetActive(true);
    }
}
