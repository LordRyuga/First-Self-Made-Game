using UnityEngine;

public class bgmMusicController : MonoBehaviour
{
    // The logic of saving current music can be removed later on if I add scripts to different regions assigning different audio
    // Clips to the MusicManager game object.

    [SerializeField] AudioClip CombatMusic;
    [SerializeField] AudioSource MusicManaager;
    [SerializeField] AudioClip currentMusic;

    private void OnTriggerExit(Collider other)              //If I exit the region to which this script is attached, save the music
                                                            //currently playing in a dummy var and start the combat music.
    {
        if (other.CompareTag("Player"))
        {
            if (MusicManaager.clip != CombatMusic)
            {
                currentMusic = MusicManaager.clip;
            }
            MusicManaager.clip = CombatMusic;
            MusicManaager.Play();
        }
    }

    private void OnTriggerEnter(Collider other)         //If I reenter this region, resume playing the saved music.
    {
        if(other.CompareTag("Player"))
        {
            if (currentMusic != null)
            {
                MusicManaager.clip = currentMusic;
                MusicManaager.Play();
            }
        }
    }
}
