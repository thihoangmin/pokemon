using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int MoveSpeed = 3;
    float animator_speed;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator_speed = animator.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            animator.speed = animator_speed;
            transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
            animator.SetBool("RightWalk", true);
            animator.SetBool("LeftWalk", false);
            animator.SetBool("FrontWalk", false);
            animator.SetBool("DownWalk", false);

        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            animator.speed = animator_speed;
            transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
            animator.SetBool("RightWalk", false);
            animator.SetBool("LeftWalk", true);
            animator.SetBool("FrontWalk", false);
            animator.SetBool("DownWalk", false);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            animator.speed = animator_speed;
            transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
            animator.SetBool("RightWalk", false);
            animator.SetBool("LeftWalk", false);
            animator.SetBool("FrontWalk", false);
            animator.SetBool("DownWalk", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            animator.speed = animator_speed;
            transform.Translate(0, -MoveSpeed * Time.deltaTime, 0);
            animator.SetBool("RightWalk", false);
            animator.SetBool("LeftWalk", false);
            animator.SetBool("FrontWalk", true);
            animator.SetBool("DownWalk", false);
        }
        else
        {
            animator.speed = 0;
        }

    }
}


