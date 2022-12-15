using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    public Transform t;
    public Rigidbody2D fish = null;
    public Transform fish_xform = null;
    public Rigidbody2D rb;
    public GameObject f;
    public int score;
    public TextMeshProUGUI myText;
    public Vector3 initPos;
    public string fishWin;
    public string fishLose;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = UnityEngine.RigidbodyConstraints2D.FreezePositionX|UnityEngine.RigidbodyConstraints2D.FreezeRotation;
        //f = GetComponent<GameObject>() ;
        score = 0;
    }

    IEnumerator waiter()
    {
        
        // reel fish up
        rb.velocity = 9 * Vector2.up;
        fish.velocity = rb.velocity;
        //Wait for .5 seconds
        yield return new WaitForSeconds(0.4F);
        // reel back down
        rb.velocity = 9 * Vector2.down;
        //Wait for .5 seconds
        yield return new WaitForSeconds(0.4F);
        fish = null;
        
        rb.velocity = new Vector2(0, 0);
        
        yield return new WaitForSeconds(3);
        Destroy(f);
        rb.WakeUp();



    }

    // Update is called once per frame
    void Update()
    {
        
        //Detect when the down arrow key is pressed down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            t.position -= Vector3.up;
        }
            
        //Detect when the down arrow key has been released
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            t.position += Vector3.up;
        }

        if(score >= 10)
        {
            SceneManager.LoadScene(fishWin);
        }
    }

    void Reel()
    {
        rb.Sleep();
        fish.Sleep();
        StartCoroutine(waiter());
        

    }

    void fishingLose()
    {
        SceneManager.LoadScene(fishLose);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name.Contains("fishObject"))
            {
                //Destroy(coll.gameObject);
            if(fish == null)
            {
                Debug.Log("fish caught");
                score += 1;
                myText.text = score.ToString();
                print(("You have:", score, "fish!"));

                f = coll.gameObject;
                fish = coll.gameObject.GetComponent<Rigidbody2D>();
                if (fish.IsSleeping())
                {
                    fish.WakeUp();
                }
                fish.constraints = RigidbodyConstraints2D.FreezePositionX;
                fish_xform = coll.gameObject.GetComponent<Transform>();
                // fish_xform.LookAt(t);
                Reel();
            }         
        }
        if (coll.gameObject.name.Contains("shark"))
        {
            print("shark!");
            myText.text = "Game Over! \n final score: " + score.ToString();
            rb.AddForce(new Vector2(0, -1) * 3, ForceMode2D.Impulse);
            fishingLose();
            Destroy(this);

        }
    }


}
