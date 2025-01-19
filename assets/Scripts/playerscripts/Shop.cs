using UnityEngine;

public class Shop : MonoBehaviour
{
    gameManager manager;
    private void Awake()
    {
        manager = GetComponent<gameManager>();
    }

    public void BuySpeed()
    {
        manager.health -= 30f;
        manager.speedPots += 1;
    }

    public void BuyStr()
    {
        manager.health -= 45f;
        manager.strPots+= 1;
    }
}
