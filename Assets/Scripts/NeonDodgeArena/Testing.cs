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
  
    public void Shoot(NoteKey direction){
      
      NotesData test = new NotesData()
      {
        key = direction,
        floatTime = 2.5f
      };
      ArrowMovement note = Instantiate(notePrefab, bossPosition.position, Quaternion.identity, bossPosition);
      note.arrows = test;
      note.targetPosition =  targetPosition.position;
      
      note.gameObject.SetActive(true);
      
    }
  
    private NoteKey RandomKey(){
      NoteKey[] choices = (NoteKey[])System.Enum.GetValues(typeof(NoteKey));
      int random = Random.Range(0, choices.Length);
      return choices[random];
    }

    public void Update(){
      if(Input.GetKeyDown(KeyCode.UpArrow)) Shoot(NoteKey.Up);
      else if(Input.GetKeyDown(KeyCode.DownArrow)) Shoot(NoteKey.Down);
      else if(Input.GetKeyDown(KeyCode.LeftArrow)) Shoot(NoteKey.Left);
      else if(Input.GetKeyDown(KeyCode.RightArrow)) Shoot(NoteKey.Right);
    }
  }
}