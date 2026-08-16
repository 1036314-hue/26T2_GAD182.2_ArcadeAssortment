using UnityEngine;

public class SkillCheckManager : MonoBehaviour
{
    public GameObject arrow;

    //arrows speed
    public float arrowSpeed = 1000f;

    //movement checker
    public bool movingRight = true;

    //arrow limits
    public float leftLimit = -960f;
    public float rightLimit = 960f;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight == true)
        {
            arrow.transform.Translate(arrowSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            arrow.transform.Translate(-arrowSpeed * Time.deltaTime, 0, 0);
        }

        if (arrow.transform.localPosition.x >= rightLimit)
        {
            movingRight = false;
        }

        if (arrow.transform.localPosition.x <= leftLimit)
        {
            movingRight = true;
        }


    }
}
