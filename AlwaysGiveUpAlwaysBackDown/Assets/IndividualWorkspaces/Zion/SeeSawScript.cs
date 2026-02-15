using UnityEngine;

public class SeeSawScript : MonoBehaviour
{
    public DustReceiver dustReceiverScript;
    public Rigidbody2D seeSawRigidbody;
    public int RequiredDustSeeSaw;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dustReceiverScript = GameObject.Find("DustReceiver").GetComponent<DustReceiver>();
        seeSawRigidbody = GetComponent<Rigidbody2D>();
        seeSawRigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (dustReceiverScript.DustAmount >= RequiredDustSeeSaw)
            {
                seeSawRigidbody.freezeRotation = false;
            }
        }
    }
}
