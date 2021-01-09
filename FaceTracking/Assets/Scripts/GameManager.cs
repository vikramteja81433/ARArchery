using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int appleCount;
    public int arrowCount;
    public Text debug;
    public GameObject session;
    private ARFaceManager faceManager;
    private ARAnchorManager anchorManager;
    public GameObject face;
    public ARFace tmpface;
    private bool isGameStarted = false;
    int count = 0;
    int arrowsWhileStartingLevel;
   [HideInInspector] public bool isApple1 = false, isApple2 = false, isApple3 = false;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        faceManager = session.GetComponent<ARFaceManager>();
        anchorManager = session.GetComponent<ARAnchorManager>();
        faceManager.facesChanged += OnFaceUpdated;
        anchorManager.anchorsChanged += OnAnchorChanged;
    }
    private void OnDisable()
    {
        faceManager.facesChanged -= OnFaceUpdated;

    }
    public void OnFaceUpdated(ARFacesChangedEventArgs args)
    {
        tmpface = args.added[0];
        count++;
        if (tmpface != null)
        {
            StartGame();
        }
        ARFace tempface1 = args.removed[0];
        if (tempface1 != null)
        {
            debug.text = "Face removed  ";
        }


    }
    public void OnAnchorChanged(ARAnchorsChangedEventArgs args)
    {
        ARAnchor anchor = args.added[0];
        if (anchor.gameObject.name == "Level1")
        {
            debug.text = "Anchor added successfully to level";
        }
    }
    void Start()
    {


    }
    void StartGame()
    {
        LevelManager.instance.LoadLevel();

        if (count == 1)
        {
            arrowsWhileStartingLevel = 15;
            arrowCount = arrowsWhileStartingLevel;
            appleCount = LoadAppleCount();
            AssignApples(LevelManager.instance.currentlevel);
        }
        else
        {
            RemoveExtraApples();
        }


    }
    // Update is called once per frame
    void Update()
    {
        //   debug.text = "AppleCount : " + appleCount.ToString();
        if (appleCount == 0 && arrowCount != 0 && LevelManager.instance.currentlevel != 9)
        {
            //   debug.text = "Loading next level";
            LevelManager.instance.UnLoadLevel();
            LevelManager.instance.IncrementLevel();
            LevelManager.instance.LoadLevel();
            AssignApples(LevelManager.instance.currentlevel);
            appleCount = LoadAppleCount();
        }
        if (appleCount == 0 && arrowCount == 0 && LevelManager.instance.currentlevel != 9)
        {
            //losing logic
            appleCount = LoadAppleCount();
            arrowCount = 5;
        }
        if (appleCount == 0 && arrowCount >= 0 && LevelManager.instance.currentlevel == 9)
        {
            // winning logic
            Application.Quit();
        }

    }
    public int LoadAppleCount()
    {
        int noOfApples = 0;
        switch (LevelManager.instance.currentlevel)
        {
            case 0:
                noOfApples = 1;
                break;
            case 1:
                noOfApples = 2;
                break;
            case 2:
                noOfApples = 3;
                break;
            case 3:
                noOfApples = 1;
                break;
            case 4:
                noOfApples = 2;
                break;
            case 5:
                noOfApples = 1;
                break;
            case 6:
                noOfApples = 2;
                break;
            case 7:
                noOfApples = 1;
                break;
            case 8:
                noOfApples = 2;
                break;
            case 9:
                noOfApples = 1;
                break;
        }
        return noOfApples;
    }

    public void AssignApples(int totalnofApples)
    {
        
        switch (totalnofApples)
        {
            case 0:
                isApple1 = true;             
                break;
            case 1:
                isApple1 = true;
                isApple2 = true;               
                break;
            case 2:
                isApple1 = true;
                isApple2 = true;
                isApple3 = true;              
                break;
            case 3:
                isApple1 = true;               
                break;
            case 4:
                isApple1 = true;
                isApple2 = true;               
                break;
            case 5:
                isApple1 = true;              
                break;
            case 6:
                isApple1 = true;
                isApple2 = true;           
                break;
            case 7:
                isApple1 = true;             
                break;
            case 8:
                isApple1 = true;
                isApple2 = true;             
                break;
            case 9:
                isApple1 = true;               
                break;
        }
    }
    public void RemoveExtraApples()
    {
        GameObject Apple1 = GameObject.Find("Apple1");
        GameObject Apple2 = GameObject.Find("Apple2");
        GameObject Apple3 = GameObject.Find("Apple3");
        if (Apple1 != null && isApple1 == false)
        {
            Destroy(Apple1);
        }
        if (Apple2 != null && isApple2 == false)
        {
            Destroy(Apple2);
        }
        if (Apple3 != null && isApple3 == false)
        {
            Destroy(Apple3);
        }
    }
}
