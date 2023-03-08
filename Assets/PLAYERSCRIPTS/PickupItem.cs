using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public float pickupDistance = 2f; 
    public KeyCode pickupKey = KeyCode.E; 
    public GameObject pickupEffect; 

    private bool isInRange;
    private bool isPickedUp;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    private void Update()
    {
        if (isInRange && !isPickedUp && Input.GetKeyDown(pickupKey))
        {
            isPickedUp = true;

            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            PublicVars.paperCount++;
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, transform.rotation);
            }
            transform.parent = player;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
