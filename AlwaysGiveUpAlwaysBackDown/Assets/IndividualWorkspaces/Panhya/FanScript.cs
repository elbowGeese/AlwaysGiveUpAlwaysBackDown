using UnityEngine;

public class FanScript : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D playerRB;
    public float fanStrength;
    public int DustRequiredToDropThrough;
    
    public DustReceiver dustReceiverScript;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindAnyObjectByType<BunnyController>().gameObject;
        playerRB = player.GetComponent<Rigidbody2D>();
        dustReceiverScript = player.GetComponent<DustReceiver>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("COLLISION HAPPENED");
        if (collision.transform.tag == "Player")
        {
            if (dustReceiverScript.DustAmount >= DustRequiredToDropThrough)
            {
                
            }
        
            else
            {
                playerRB.AddForceY(fanStrength);

            }

        }
    }
   
}
