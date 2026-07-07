using UnityEngine;

public class PointSystem : MonoBehaviour
{
    private int target;
    [SerializeField] private int totalPoints = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        totalPoints ++;
        Debug.Log("I suck");
    }
}
