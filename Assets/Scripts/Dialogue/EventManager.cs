using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{

    public Canvas canvas;
    public GameObject textBox;
    public Dialogue diag;
    public Cutscene[] cutscenes;
    private int cutscenePos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            nextCutScene();
        }
    }


    void createTextBox(string file)
    {
        diag.StartNewDialogue(file);
    }


    void nextCutScene()
    {
        if(cutscenes.Length > cutscenePos)
        {
            unpackCutScene(cutscenes[cutscenePos++]);
        }
        else
        {

        }
    }

    void unpackCutScene(Cutscene cutscene)
    {
        createTextBox(cutscene.filename);
    }

    public void textFinished()
    {
        nextCutScene();
    }
    
}
