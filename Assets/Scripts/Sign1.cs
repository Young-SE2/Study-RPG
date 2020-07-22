using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign1 : MonoBehaviour
{
    public GameObject dialogBox1;
    public Text dialogText1;
    public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (dialogBox1.activeInHierarchy)
            {
                dialogBox1.SetActive(false);
            }
            else
            {
                dialogBox1.SetActive(true);
                dialogText1.text = dialog;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox1.SetActive(false);
        }
    }
}
