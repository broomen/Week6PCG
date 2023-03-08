using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject doorLock;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PublicVars.paperCount >= PublicVars.paperAmount)
        {
            doorLock.SetActive(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game over");
        }
    }
}
