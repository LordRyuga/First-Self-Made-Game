using UnityEngine;

public class Settings : MonoBehaviour
{
    public void Vsync()
    {
        if (QualitySettings.vSyncCount == 0)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

}
