using UnityEngine;

public class TargetScript : MonoBehaviour
{
    private int target;
    // [SerializeField] private int totalPoints = 0;

    public TotalPoints points;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        points.points += 1;
        Debug.Log("Target HIT!");
    }
}
