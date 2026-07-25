using UnityEngine;

public class antNestDestroyed : MonoBehaviour
{

    public GameObject QueenAnt;
    public GameObject BossManager;


    public void OnDestroy()
    {
        BossManager.TryGetComponent(out BossFightHandler AntNestAmount);
        AntNestAmount.antNestAmount -= 1f;
        if (AntNestAmount.antNestAmount == 0f)
        {
            QueenAnt.SetActive(true);
        }  
    }
}
