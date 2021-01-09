using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class LevelManager : MonoBehaviour
{
    public GameObject[] level = new GameObject[10];
    [HideInInspector] public static LevelManager instance;
    public GameObject Face;
    public int currentlevel;
    private ARAnchorManager anchorManager;
    [HideInInspector] public Vector3 levelpos;
    [HideInInspector] public Quaternion levelrot;
    [HideInInspector] public GameObject tempobj;
    public Text debug;
    GameObject tmplevel;
    private ARFace tmpface;

    private void Awake()
    {
        instance = this;
        currentlevel = 0;
    }
    public void LoadLevel()
    {
       
            tmplevel = level[currentlevel];
            tmpface = GameManager.instance.tmpface;
            tempobj = Instantiate(tmplevel, tmpface.transform.position, tmpface.transform.rotation);
            tempobj.transform.parent = tmpface.transform;
    }
    public void IncrementLevel()
    {
       
        currentlevel++;
    }
    public void UnLoadLevel()
    {
        if (tempobj != null)
        {
            tempobj.transform.parent = null;
            Destroy(tempobj);
        }
    }
    public void ResetLevel()
    {
        currentlevel = 0;
    }
    public void Start()
    {
        anchorManager = FindObjectOfType<ARAnchorManager>();
       
    }
}
