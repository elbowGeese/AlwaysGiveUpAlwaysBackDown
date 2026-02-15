using UnityEngine;

public class FanScript : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D playerRB;
    public float fanStrength;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindAnyObjectByType<BunnyController>().gameObject;
        playerRB = player.GetComponent<Rigidbody2D>();
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
            Debug.Log("fan moving bunny up");
            
            playerRB.AddForceY(fanStrength);
        }
    }
   
}
