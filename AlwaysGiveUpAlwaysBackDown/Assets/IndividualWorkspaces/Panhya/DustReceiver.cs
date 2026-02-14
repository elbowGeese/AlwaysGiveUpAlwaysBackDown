using UnityEngine;

public class DustReceiver : MonoBehaviour
{
    public int DustAmount;
    public Dust dustScript;
    public int DustReceiveLimit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CorrectAmntDustReceived()
    {
        Debug.Log($"received this much dust:" + dustScript.ContainsThisMuchDust);
        DustAmount += dustScript.ContainsThisMuchDust;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "dust")
        {
            if (DustReceiveLimit >= dustScript.ContainsThisMuchDust)
            {

                CorrectAmntDustReceived();
            }
        }
    }
}
