using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool can_interact;
    public bool active;
    public GameObject interactable;
    
    // Start is called before the first frame update
    void Start()
    {
        can_interact = false;
        active = false;
        interactable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (active == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interactable.SetActive(false);
                active = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) && can_interact == true)
            {
                interactable.SetActive(true);
                active = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactable.SetActive(false);
        active = false;
        can_interact = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        can_interact = true;
    }
}
