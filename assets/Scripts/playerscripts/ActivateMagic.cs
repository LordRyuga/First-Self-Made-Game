using DialogueEditor;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateMagic : MonoBehaviour
{
    [SerializeField] private GameObject MagicShooter;
    [SerializeField] private PlayableDirector obtainedMagic;
    gameManager gameManager;
    

    private void Awake()
    {
        gameManager = GetComponentInParent<gameManager>();
    }
    public void ActivateMagicFuntion()
    {
        MagicShooter.SetActive(true);
        gameManager.health -= 60 * 5;
        ConversationManager.Instance.SetBool("HasMagic", true);
        gameManager.HasMagic = true;
        obtainedMagic.Play();
    }

    private void Update()
    {
        if (gameManager.HasMagic && !MagicShooter.activeSelf)
        {
            MagicShooter.SetActive(true);
        }
    }
}
