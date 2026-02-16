using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioMixer gameMixer;
    public Slider MasterSlider;
    public Slider BGMSlider;
    public Slider SFXSlider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVol()
    {
        float volume = MasterSlider.value;
        gameMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void SetBGMVol()
    {
        float vol = BGMSlider.value;
        gameMixer.SetFloat("BGM", Mathf.Log10(vol) * 20);
    }
   public  void SetSFXVol()
    {
        float vol = SFXSlider.value;
        gameMixer.SetFloat("SFX", Mathf.Log10(vol) * 20);
    }
}
