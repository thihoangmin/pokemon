using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalk : MonoBehaviour 
{

    // Start is called before the first frame update
    //public string ActorName;
    //public Sprite Portrait;
    private Rigidbody2D rb;
    public Animator interactionAnimator;
    public GameObject dialogueCanvas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Cham ne");
            interactionAnimator.Play("OpenDialogue");
            dialogueCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactionAnimator.Play("CloseDialogue");
        dialogueCanvas.SetActive(false);

    }

}

