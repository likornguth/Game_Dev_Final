using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Space"))){
            SceneManager.LoadScene("Assets/Scenes/Text-Test (PEDRO).unity");
        }
    }
}
