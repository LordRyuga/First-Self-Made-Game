using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    // On searching tutorials, in order to change sound in a linear manner, we need to log the float that we get as an input
    // From the Slider in the scene.

    // Using this, and a reference to an Audio Mixer, i.e. Main audio mixer, use references to the different channels to set vols.

    public void SetMasterVol(float level)
    {
        audioMixer.SetFloat("MasterVolumeParameter", Mathf.Log10(level) * 20f);
    }

    public void SetFXVol(float level)
    {
        audioMixer.SetFloat("FXVolumeParameter", Mathf.Log10(level) * 20f);
    }

    public void SetMusicVol(float level)
    {
        audioMixer.SetFloat("MusicVolumeParameter", Mathf.Log10(level) * 20f);
    }
}
