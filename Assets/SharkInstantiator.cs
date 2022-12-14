using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkInstantiator : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform prefab;
    public float Timer = 4;
    public int speed;
    void Start()
    {
        if (prefab.gameObject.name.Contains("shark"))
        {
            Instantiate(prefab, new Vector3(10.0F, Random.Range(-6, 1),0), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0f)
        {
            if (prefab.gameObject.name.Contains("shark"))
            {
                prefab = Instantiate(prefab, new Vector3(10.0F, Random.Range(-6, 1),0), Quaternion.identity);
            }

            Timer = 4f;
        }

    }
}
