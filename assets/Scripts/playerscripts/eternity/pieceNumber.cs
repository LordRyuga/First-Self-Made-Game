using UnityEngine;
using UnityEngine.Playables;

public class pieceNumber : MonoBehaviour
{
    public int PieceNumber;
    public gameManager gameManager;
    [SerializeField] PlayableDirector gainedPiece;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager.PiecesOfEternity[PieceNumber - 1] == 0)
            {
                gameManager.PiecesOfEternity[PieceNumber - 1] = 1;
                Collider piece = GetComponent<Collider>();
                piece.enabled = false;
                gameObject.SetActive(false);
                gainedPiece.Play();
            }
        }
    }

    private void Update()
    {
        if (gameManager.PiecesOfEternity[PieceNumber - 1] != 0)
        {
            Collider piece = GetComponent<Collider>();
            piece.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
