using UnityEngine;
using UnityEngine.InputSystem;


public class SkillCheckInputs : MonoBehaviour
{
    public SkillCheckManager manager;

    
    public GameObject arrow;
    public GameObject bar;

    public float barLeftLimit = -10f;
    public float barRightLimit = 120f;

    public float score;
    public float health = 5f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            float arrowPositionComparedToBar =
                arrow.transform.localPosition.x - bar.transform.localPosition.x;
            Debug.Log("Position actually checked: " + arrowPositionComparedToBar);

            if (arrowPositionComparedToBar >= barLeftLimit &&
                arrowPositionComparedToBar <= barRightLimit)
            {
                score = score + 1;
                Debug.Log("Hit! Your score is now " + score);
            }
            else
            {
                health = health - 1;
                Debug.Log("Miss! You now have " + health + " Health");
            }
        }
    }
}
