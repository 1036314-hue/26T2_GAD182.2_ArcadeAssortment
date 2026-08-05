using UnityEngine;
using System.Collections;
using Ithiel;
using System.Collections.Generic;

public class RangeManager : MonoBehaviour
{

  public List<ArrowMovement> UpArrows { get; private set; } = new();
  public List<ArrowMovement> DownArrows { get; private set; } = new();
  public List<ArrowMovement> LeftArrows { get; private set; } = new();
  public List<ArrowMovement> RightArrows { get; private set; } = new();
  
  void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.layer==LayerMask.NameToLayer("Note"))
        {
            Debug.Log("Found note!");
            if(other.TryGetComponent<ArrowMovement>(out ArrowMovement arrow))
            {
                Debug.Log("Found Arrow Movement!");
                // Make them Glow here or something
                switch(arrow.arrows.key)
                {
                    case NoteKey.Up:
                    Debug.Log("Adding up arrow");
                        if(!UpArrows.Contains(arrow)) UpArrows.Add(arrow);
                        break;
                    case NoteKey.Down:
                        if(!DownArrows.Contains(arrow)) DownArrows.Add(arrow);
                        break;
                    case NoteKey.Left:
                        if(!LeftArrows.Contains(arrow)) LeftArrows.Add(arrow);
                        break;
                    case NoteKey.Right:
                        if(!RightArrows.Contains(arrow)) RightArrows.Add(arrow);
                        break;
                }
            }
        }
    }

  void OnTriggerExit(Collider other)
    {
        ClearLists();
        if (other.CompareTag("Note"))
        {
            if (other.TryGetComponent<ArrowMovement>(out ArrowMovement arrow))
            {
                switch (arrow.arrows.key)
                {
                    case NoteKey.Up:
                        if (UpArrows.Contains(arrow)) UpArrows.Remove(arrow);
                        break;
                    case NoteKey.Down:
                        if (DownArrows.Contains(arrow)) DownArrows.Remove(arrow);
                        break;
                    case NoteKey.Left:
                        if (LeftArrows.Contains(arrow)) LeftArrows.Remove(arrow);
                        break;
                    case NoteKey.Right:
                        if (RightArrows.Contains(arrow)) RightArrows.Remove(arrow);
                        break;
                }
            }
        }
    }
    public void ClearLists()
{
    if (UpArrows != null)
    {
        UpArrows.RemoveAll(arrow => arrow == null);
    }
    if (DownArrows != null)
    {
        DownArrows.RemoveAll(arrow => arrow == null);
    }
    if (LeftArrows != null)
    {
        LeftArrows.RemoveAll(arrow => arrow == null);
    }
    if (RightArrows != null)
    {
        RightArrows.RemoveAll(arrow => arrow == null);
    }
}
}
