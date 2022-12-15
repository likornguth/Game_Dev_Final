using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Linq;


public class Dialogue : MonoBehaviour
{

    // Start is called before the first frame update

    public AudioSource audioSource;
    public AudioClip typing1;
    public TextMeshProUGUI textComponent;
    public EventManager eventman;
    public string[] lines;
    public float textSpeed;
    private int index;
    

    void Start()
    {


        //audioSource = GetComponent<AudioSource>();
        textComponent.text = string.Empty;

        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Space")))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());

    }
    
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            Debug.Log("AAAAA");

            if (lines[index].Contains("AL:"))
            {
                textComponent.color = new Color(1, 0, 0);
                lines[index] = lines[index].Replace("AL: ", "");
            }
            else if (lines[index].Contains("PLAYER:"))
            {
                textComponent.color = new Color(1, 1, 0);
                lines[index] = lines[index].Replace("PLAYER: ", "");
            }
            else
            {
                textComponent.color = new Color(0, 0, 1);
            }
            StartCoroutine(TypeLine());
        }
        else
        {
            endDialogue();
        }
    }

    void endDialogue()
    {
        gameObject.SetActive(false);



        //If there is a new scene or new cutscene to play, do it here.
        eventman.textFinished();

    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            audioSource.PlayOneShot(typing1, 0.7F);
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void StartNewDialogue(string filepath)
    {


        

        //Empty out the thing
        textComponent.text = string.Empty;

        //Set up filepath
        List<string> fileLines = File.ReadAllLines(filepath).ToList();

        

        //Add lines to
        lines = fileLines.ToArray();

        //Edge case for lines
        if (index < lines.Length - 1)
        {
            if (lines[index].Contains("AL:"))
            {
                textComponent.color = new Color(1, 0, 0);
                lines[index] = lines[index].Replace("AL:", "");
            }
            else if (lines[index].Contains("PLAYER:"))
            {
                textComponent.color = new Color(1, 1, 0);
                lines[index] = lines[index].Replace("PLAYER:", "");
            }
            else
            {
                textComponent.color = new Color(0, 0, 1);
            }
        }

        gameObject.SetActive(true);
        StartDialogue();


    }



}
