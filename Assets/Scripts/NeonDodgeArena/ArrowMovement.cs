using System.Security;
using Ithiel;
using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
 public Vector3 controlPoint;
 public NotesData arrows;
 public Vector3 targetPosition;
 public ParticleSystem rangeGlow;
 public Vector3 startPosition;
 private float curveStrength = 7;
 private float startTime;
 void OnEnable()
 {
        startPosition = transform.position;
        startTime = Time.time;

        Curve();
 }
 public void Update()
 {
 float elapsed = Time.time - startTime;
        float t = Mathf.Clamp01(elapsed / arrows.floatTime);

        Vector3 pos = Mathf.Pow(1 - t, 2) * startPosition
                    + 2 * (1 - t) * t * controlPoint
                    + Mathf.Pow(t, 2) * targetPosition;

        transform.position = pos;
 } 
 public void Curve()
    {
        Vector3 forward = (targetPosition - startPosition).normalized;
        Vector3 right = Vector3.Cross(Vector3.up, forward);

        Vector3 mid = (startPosition + targetPosition) * 0.5f;

        Vector3 offset = Vector3.zero;

        switch (arrows.key)
        {
            case NoteKey.Right:
                offset = -right * curveStrength;
                break;

            case NoteKey.Left:
                offset = right * curveStrength;
                break;
      
            case NoteKey.Down:
            case NoteKey.Up:
                offset = Vector3.up * curveStrength;
                break;
        }

        controlPoint = mid + offset;
    }
}
