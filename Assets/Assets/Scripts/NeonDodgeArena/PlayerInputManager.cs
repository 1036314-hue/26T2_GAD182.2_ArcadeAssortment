using UnityEngine;
using Ithiel;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField]
    private RangeManager range;
    [SerializeField] private ParticleSystem Explosion;
    
    
    void Update(){

      NoteKey key = HandleInput();
      
      if(key == NoteKey.None) return;
      HandleDestroy(key);
    }

    private NoteKey HandleInput(){
      if(Input.GetKeyDown(KeyCode.W)) return NoteKey.Up;
      else if(Input.GetKeyDown(KeyCode.S)) return NoteKey.Down;
      else if(Input.GetKeyDown(KeyCode.A)) return NoteKey.Right;
      else if(Input.GetKeyDown(KeyCode.D)) return NoteKey.Left;

      return NoteKey.None;
    }
     
    private void HandleDestroy(NoteKey key){
        List<ArrowMovement> destroyList = null;
        switch(key){
          case NoteKey.Up:
              destroyList = range.UpArrows;
              break;
          case NoteKey.Down:
              destroyList = range.DownArrows;
              break;
          case NoteKey.Right:
              destroyList = range.LeftArrows;
              break;
          case NoteKey.Left:
              destroyList = range.RightArrows;
              break;
        }
        if (destroyList!= null && destroyList.Count > 0)
        {
          ArrowMovement arrow = destroyList[0];
          destroyList.RemoveAt(0);
          Debug.Log(arrow);
          Score.Instance.Arrow();
          if (arrow!=null)
          {
            ParticleSystem fx = Instantiate(
                    Explosion,
                    arrow.getPosition(),
                    Quaternion.identity
                );

                fx.Play();
                Destroy(fx.gameObject, fx.main.duration);
                Destroy(arrow.gameObject);
          }
          range.ClearLists();

        }
    }
}