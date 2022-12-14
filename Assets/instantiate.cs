using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform prefab;
    public float Timer = 2;
    public int speed;
    void Start()
    {
        if (prefab.gameObject.name.Contains("fishObject"))
        {
            Instantiate(prefab, new Vector2(10.0F, Random.Range(-6, 1)), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        
        if (Timer <= 0f)
        {
            if (prefab.gameObject.name.Contains("fishObject"))
            {
                prefab = Instantiate(prefab, new Vector2(10.0F, Random.Range(-6, 1)), Quaternion.identity);
            }
            
            Timer = 2f;
        }
        
    }
}
