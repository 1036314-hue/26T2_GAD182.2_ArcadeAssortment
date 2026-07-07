using System.Collections;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

namespace Ithiel {

  public class Testing : MonoBehaviour
  {
    [SerializeField]
    private ArrowMovement notePrefab;
    [SerializeField]
    private Transform bossPosition;
    [SerializeField]
    private Transform targetPosition;
  [SerializeField]
    private float minFlight = 2f;
[SerializeField]
private float maxFlight = 2f;

[SerializeField]
private float minTime = 1f;
[SerializeField]
private float maxTime = 1.05f;
[SerializeField] private float gameTime = 60f;
private bool start = false;
    public void Shoot(NoteKey direction){
      
      NotesData test = new NotesData()
      {
        key = direction,
        floatTime = Random.Range(minFlight,maxFlight)
      };
      ArrowMovement note = Instantiate(notePrefab, bossPosition.position, Quaternion.identity, bossPosition);
      note.arrows = test;
      note.targetPosition =  targetPosition.position;
      switch(direction)
{
    case NoteKey.Up:
        note.transform.eulerAngles = new Vector3(0, 0, 90f);
        break;
    case NoteKey.Left:
        note.transform.eulerAngles = new Vector3(0, 0, 180f);
        break;
    case NoteKey.Down:
        note.transform.eulerAngles = new Vector3(0, 0, -90f);
        break;
    case NoteKey.Right:
        break;
}
      note.gameObject.SetActive(true);
      
    }
  
    private NoteKey RandomKey(){
      NoteKey[] choices = (NoteKey[])System.Enum.GetValues(typeof(NoteKey));
      int random = Random.Range(0, choices.Length-1);
      return choices[random];
    }

    public void Update(){
      if(Input.GetKeyDown(KeyCode.W)) Shoot(NoteKey.Up);
      else if(Input.GetKeyDown(KeyCode.S)) Shoot(NoteKey.Down);
      else if(Input.GetKeyDown(KeyCode.A)) Shoot(NoteKey.Left);
      else if(Input.GetKeyDown(KeyCode.D)) Shoot(NoteKey.Right);
      else if(Input.GetKeyDown(KeyCode.Return)&&!start)StartCoroutine(Punching());
    }
    IEnumerator Punching()
    {
        start = true;
        float elapsed = 0;
        while (elapsed < gameTime) 
        {
            float delay = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(delay);


            Shoot(RandomKey());
        }
        start = false;
    }
  }
}