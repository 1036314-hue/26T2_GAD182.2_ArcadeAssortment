using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MaxTurns : MonoBehaviour
{
    [Header("Turn Settings")]
    [SerializeField] private int currentTurn;
    private int maxTurn = 6;

    [SerializeField] private TextMeshProUGUI turnCounterUI;

    private void Start()
    {
        TriggerTurn();
    }

    //private void OnMouseUp()
    //{
    //    if (turnCounterUI != null)
    //    {
    //        TriggerTurn();
    //    }
    //}

    public void TriggerTurn()
    {
        if (currentTurn < maxTurn)
        {
            currentTurn += 1;
        }
        Debug.Log("Turn " + currentTurn + " / 5" );
        turnCounterUI.text = "Turn " + currentTurn + " / 5";

        if (currentTurn == (maxTurn - 1) )
        {
            Debug.Log("Max turn reached");
            this.gameObject.SetActive(false);
            turnCounterUI.text = "Finished";
        }
    }
}
