using UnityEngine;

public class DropThrough : MonoBehaviour
{
    Collider2D thisCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           thisCollider.isTrigger = false;
        }
    }
}
