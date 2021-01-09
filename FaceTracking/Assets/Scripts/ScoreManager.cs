using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ArrowCount, AppleCount;
    private int arrowCount, appleCount;
    // Start is called before the first frame update
    void Start()
    {
        arrowCount = 0;
        appleCount = 0;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        arrowCount = GameManager.instance.arrowCount;
        appleCount = GameManager.instance.appleCount;
        UpdateUI();
    }
    public void UpdateUI()
    {
        ArrowCount.text = "ArrowCount : " + arrowCount.ToString();
        AppleCount.text = "AppleCount : " + appleCount.ToString();
    }
}
