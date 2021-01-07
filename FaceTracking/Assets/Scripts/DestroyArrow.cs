using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyCurrentArrow());
    }

    // Update is called once per frame
    public IEnumerator DestroyCurrentArrow()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
