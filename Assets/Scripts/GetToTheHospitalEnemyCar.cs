using UnityEngine;

public class GetToTheHospitalEnemyCar : MonoBehaviour
{
    public GameObject spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     spawner = GameObject.Find("Car Spawner");   
    }

    // Update is called once per frame
    void Update()
    {
        //Moving the car
        transform.position += -transform.forward * Time.deltaTime * 2;
        //Destroying Car when behind the camera 
        if (transform.position.z <= -15)
        {
            Destroy(gameObject);
        }
    }
}
