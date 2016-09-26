using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);  //Reset
        }
	}
}
