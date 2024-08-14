using UnityEngine;

public class PlayerAttackView : MonoBehaviour
{
    PlayerAttackModel playerAttackModel;

    private void Start()
    {
        playerAttackModel = new PlayerAttackModel();
        GetComponent<PlayerAttackController>().PlayerAttackModel = playerAttackModel;


    }

    void IsHoldChanged()
    {

    }
}
