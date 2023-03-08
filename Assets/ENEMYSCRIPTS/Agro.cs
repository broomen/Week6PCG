using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agro : MonoBehaviour
{
    public Transform target;
    Transform origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = gameObject.transform;
        target = origin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = origin;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject.transform;
        }
    }
}
