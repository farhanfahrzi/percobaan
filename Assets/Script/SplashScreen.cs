using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Example());
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(4);
        Application.LoadLevel ("Menu");
    }
}
