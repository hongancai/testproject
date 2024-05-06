using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class S2RestartButton : MonoBehaviour
{
    public GameObject objectToReload;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReloadS2()
    {
        SceneManager.LoadScene("S2");
        Debug.Log("Button Clicked");
    }
}
