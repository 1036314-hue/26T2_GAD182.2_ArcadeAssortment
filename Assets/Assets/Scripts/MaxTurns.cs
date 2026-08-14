using TMPro;
using UnityEngine;

public class MaxTurns : MonoBehaviour
{
    [Header("Turn Settings")]
    [SerializeField] private int currentTurn;
    private int maxTurn = 5;

    [SerializeField] private TextMeshProUGUI turnCounterUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        turnCounterUI.text = "Turn " + currentTurn + " / " + maxTurn;

        if (currentTurn == maxTurn)
        {
            Debug.Log("Max turn reached");
        }
    }

    private void OnMouseUp()
    {
        
        if(currentTurn < maxTurn)
        {
            currentTurn += 1;
        }
        Debug.Log("Turn " + currentTurn + " / " + maxTurn);
    }
}
