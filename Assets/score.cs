using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class score : MonoBehaviour
{
    public int points;
    
    
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    public void UpdatePoints()
    {
        points += 1;
        print(("You have:" ,points, "fish!"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
