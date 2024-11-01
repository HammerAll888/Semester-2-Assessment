using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{
    //List of objects used in the script
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    //References the player object
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Wand;

    //Will start the dialogue when the game starts
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    //Will wait for M1 click to either skip to the end of the line or move to the next one
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
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

    //This will start the dialogue
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    //This types out the lines on the page
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    //This will determine how many lines there will be
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); //Deactivates the dialogue box when the last line is complete
            Player.GetComponent<TopDownCharacterMover>().enabled = true;
            Wand.GetComponent<Wand>().enabled = true;
        }
    }
}
