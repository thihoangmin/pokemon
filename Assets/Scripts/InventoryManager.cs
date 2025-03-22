using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    public GameObject inventory;
    public int state;
    public int cooldown;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        cooldown = 0;
        inventory.SetActive(false);
    }
    IEnumerator Delay(float time)
    {
        cooldown = 1;
        yield return new WaitForSeconds(time);
        cooldown = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            if ( (cooldown == 0))
            {
                if (state == 0)
                {
                    StartCoroutine(Delay(0.5f));
                    inventory.SetActive(true);
                    state = 1;
                }
                else
                {
                    StartCoroutine(Delay(0.5f));
                    inventory.SetActive(false);
                    state = 0;
                }



            }
            else
            {

            }


            
            

    }
}
