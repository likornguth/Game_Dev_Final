using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashscreen : MonoBehaviour
{

    public string nextScene = "Assets/Scenes/First Dialogue.unity";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if ((Input.GetButtonDown("Space")))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
