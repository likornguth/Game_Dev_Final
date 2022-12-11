using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "cutscene", menuName = "cutscene-custom", order = 1)]
public class Cutscene : ScriptableObject
{
    

    public string filename;
    public string[] lines;
    public Color color;
    public string nextScene;
    public float waitTime;



}
