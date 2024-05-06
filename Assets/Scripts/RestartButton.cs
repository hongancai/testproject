using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
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
public void ReloadS1()
    {
         SceneManager.LoadScene("S1");
		Debug.Log("Button Clicked");
    }
}
