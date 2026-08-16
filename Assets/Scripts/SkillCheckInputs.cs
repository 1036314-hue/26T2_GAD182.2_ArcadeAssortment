using UnityEngine;
using UnityEngine.InputSystem;


public class SkillCheckInputs : MonoBehaviour
{
    public SkillCheckManager manager;

    
    public GameObject arrow;
    public GameObject bar;


    //length of bar
    public float barLeftLimit = -10f;
    public float barRightLimit = 120f;

    //score and health
    public float score;
    public float health = 5f;

    //limits location change of Bar
    public float barRandomLeftLimit = -800f;
    public float barRandomRightLimit = 700f;




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

            if (arrowPositionComparedToBar >= barLeftLimit &&//tracking when you hit bar to give points
                arrowPositionComparedToBar <= barRightLimit)
            {
                score = score + 1;
                Debug.Log("Hit! Your score is now " + score);
                manager.arrowSpeed = manager.arrowSpeed + 175;
            }
            else//tracking when you miss to take away lives
            {
                health = health - 1;
                Debug.Log("Miss! You now have " + health + " Health");
            }

            //changes location of Bar
            Vector3 newBarPosition = bar.transform.localPosition;

            newBarPosition.x = Random.Range(
                barRandomLeftLimit,
                barRandomRightLimit
            );

            bar.transform.localPosition = newBarPosition;
        }
    }
}
