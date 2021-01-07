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
    ARRaycastManager rayManager;
    ARAnchorManager anchorManager;
    public GameObject arrow,cam,session;
    private GameObject temparrow;
    private ARFaceManager faceManager;
    public Text Debug;
    private ARFace face;
    private Vector3 dir;
    int i = 0;
 
    private float angle = 0;
  
    private Vector3[] coordinates;
    public GameObject pointer;
    private Vector3 offset;
    private bool isArrowShot = false;
    public bool isArrowLost = true;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {       
       // pointer = GameObject.Find("Pointer");
        rayManager = session.GetComponent<ARRaycastManager>();
        anchorManager = session.GetComponent<ARAnchorManager>();
        offset = new Vector3(0, 0, 0.04f);
      
    }
    private void OnEnable()
    {
        faceManager = session.GetComponent<ARFaceManager>();
        faceManager.facesChanged += OnFaceUpdated;
    }
    private void OnDisable()
    {
        faceManager.facesChanged -= OnFaceUpdated;
    }

    // Update is called once per frame
    void Update()
    {

         ShowPointer();
     
   
    }
    public void OnFireButtonClicked()
    {
        AudioManager.instance.PlayArrowReleaseSound();
       
        isArrowShot = true;
        pointer.SetActive(false);
        StartCoroutine(ShowPointerAgain());
    }
    public void OnFaceUpdated(ARFacesChangedEventArgs args)
    {
        face = args.added[0];
    
    }
    public void FixedUpdate()
    {
        if (isArrowShot)
        {
           GameObject temparrow = Instantiate(arrow, ArrowPosition.transform.position, ArrowPosition.transform.rotation);
            temparrow.transform.parent = face.transform;
            temparrow.GetComponent<Rigidbody>().AddForce(arrow.transform.up * 100);
            isArrowShot = false;
           
        }
    }

    public void ShowPointer()
    {
       
        try
        {
         
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
               
                 pointer.transform.position = hit.point;
            }
        }
        catch(Exception e) { Debug.text = e.Message; }
    }
    public IEnumerator ShowPointerAgain()
    {
        yield return new WaitForSeconds(2);
        pointer.SetActive(true);
    }
}
