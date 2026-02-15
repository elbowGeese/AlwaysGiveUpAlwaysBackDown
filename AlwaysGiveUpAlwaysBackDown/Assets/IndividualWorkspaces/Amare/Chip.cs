using UnityEngine;

public class ChipSpriteByDust : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite wholeSprite;   
    public Sprite brokenSprite;  

    [Header("Rule")]
    public int brokenThreshold = 5; 

    private SpriteRenderer sr;

    private DustReceiver playerDust;  
    private bool watchingPlayer = false;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
       
        if (sr != null && wholeSprite != null)
            sr.sprite = wholeSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        
        playerDust = collision.GetComponent<DustReceiver>();
        if (playerDust == null)
        {
            Debug.LogWarning("ChipSpriteByDust: Player 上找不到 DustReceiver 组件！");
            return;
        }

        
        RefreshSprite();

      
        if (!watchingPlayer)
        {
            playerDust.onDustReceived += RefreshSprite;
            watchingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        
        if (playerDust != null && watchingPlayer)
        {
            playerDust.onDustReceived -= RefreshSprite;
        }

        playerDust = null;
        watchingPlayer = false;
    }

    private void RefreshSprite()
    {
        if (sr == null || playerDust == null) return;

        
        if (playerDust.DustAmount >= brokenThreshold)
        {
            if (brokenSprite != null) sr.sprite = brokenSprite;
        }
        else
        {
            if (wholeSprite != null) sr.sprite = wholeSprite;
        }
    }
}
