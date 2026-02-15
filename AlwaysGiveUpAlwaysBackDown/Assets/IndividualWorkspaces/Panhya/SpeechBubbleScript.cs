using UnityEngine;

public class SpeechBubbleScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject player;
    
    public float distanceThreshold;
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindAnyObjectByType<BunnyController>().gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < distanceThreshold)
        {
            animator.SetBool("InSpeechBubbleTrigger", true);

        }
        if ( distance > distanceThreshold)
        {
            animator.SetBool("InSpeechBubbleTrigger", false);

        }
    }
}
