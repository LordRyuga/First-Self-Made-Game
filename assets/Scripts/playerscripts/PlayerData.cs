using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public float Health;
    public int strPots;
    public int speedPots;
    public float[] position;
    public float[] rotation;
    public float basicAttack;
    public int[] questItems;
    public bool[,] questStatus;
    public int[] piecesOfEternity;

    public int[] PiecesOfEternity;
    public bool[] flagPiecesOfEternity;
    public float timeFactor;
    public int numberOfPieces;
    public bool HasMagic;

    public PlayerData (gameManager manager)
    {
        this.Health = manager.health;
        this.strPots = manager.strPots;
        this.speedPots = manager.speedPots;
        this.basicAttack = manager.basicAttack;
        this.piecesOfEternity = manager.PiecesOfEternity;
        this.flagPiecesOfEternity = manager.flagPiecesOfEternity;
        this.timeFactor = manager.timeFactor;
        this.HasMagic = manager.HasMagic;
        numberOfPieces = manager.numberOfPieces;

        position = new float[3];
        rotation = new float[3];

        position[0] = manager.transform.position.x;
        position[1] = manager.transform.position.y;
        position[2] = manager.transform.position.z;

        rotation[0] = manager.transform.rotation.x;
        rotation[1] = manager.transform.rotation.y;
        rotation[2] = manager.transform.rotation.z;
        questItems = manager.questsScriptReference.items;
        questStatus = manager.questsScriptReference.questsData;
    }


}
