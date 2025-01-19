using UnityEngine;

public class Piece2Appear : MonoBehaviour
{
    [SerializeField] BearManager bear1;
    [SerializeField] BearManager bear2;
    [SerializeField] BearManager bear3;
    [SerializeField] BearManager bear4;
    [SerializeField] BearManager bear5;
    [SerializeField] BearManager bear6;
    [SerializeField] BearManager bear7;
    [SerializeField] gameManager gameManager;
    [SerializeField] GameObject piece2;
    bool allFed;
    bool allDead;

    private void Update()
    {
        allFed = (bear1.fed &&  bear2.fed && bear3.fed && bear4.fed && bear5.fed && bear6.fed && bear7.fed);
        allDead = (!(bear1.isActiveAndEnabled) && !(bear2.isActiveAndEnabled) && !(bear3.isActiveAndEnabled) && !(bear4.isActiveAndEnabled) && !(bear5.isActiveAndEnabled) && !(bear6.isActiveAndEnabled) && !(bear7.isActiveAndEnabled));

        if( allFed || allDead )
        {
            if (gameManager.PiecesOfEternity[1] == 0)
            {
                piece2.SetActive(true);
            }
        }
        
    }


}
