using UnityEngine;
using UnityEngine.InputSystem;


public class SkillCheckInputs : MonoBehaviour
{
    public GameObject arrow;
    public GameObject bar;

    public float barLeftLimit = -10f;
    public float barRightLimit = 120f;





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
                Debug.Log("Hit!");
            }
            else
            {
                Debug.Log("Miss!");
            }
        }
    }
}
