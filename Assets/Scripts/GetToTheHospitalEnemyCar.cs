using Unity.VisualScripting;
using UnityEngine;

public class GetToTheHospitalEnemyCar : MonoBehaviour
{
    public GameObject spawner;

    [SerializeField]
    private GetToTheHospitalEnemyCarSpawner spawnerScript;

    [SerializeField]
    private GameObject playerCar;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner = GameObject.Find("CarSpawner");
        spawnerScript = spawner.GetComponent<GetToTheHospitalEnemyCarSpawner>();
        playerCar = GameObject.Find("Player Car");
    }

    // Update is called once per frame
    void Update()
    {
        //Moving the car
        transform.position += -transform.forward * Time.deltaTime * (spawnerScript.score + 1);
        //Destroying Car when behind the camera 
        if (transform.position.z <= -13)
        {
            spawnerScript.score += 1;
            Debug.Log(spawnerScript.score);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision playerCar)
    {
        Debug.Log("Collided with something");

    }
}
