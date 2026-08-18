using Ithiel;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private Material material;

    public Vector3 controlPoint;
    public NotesData arrows;
    public Vector3 targetPosition;

    public ParticleSystem Explosion;

    public Vector3 startPosition;

    private float curveStrength = 7f;
    private bool finish = false;

    public RangeManager range;

    private float startTime;

    void OnEnable()
    {
        startPosition = transform.position;
        startTime = Time.time;
        finish = false;

        Curve();
    }

    public void Update()
    {
        float elapsed = Time.time - startTime;

        float t = Mathf.Clamp01(
            elapsed / arrows.floatTime
        );

        Vector3 pos =
            Mathf.Pow(1 - t, 2) * startPosition
            + 2 * (1 - t) * t * controlPoint
            + Mathf.Pow(t, 2) * targetPosition;

        transform.position = pos;

        if (Vector3.Distance(
            transform.position,
            targetPosition
        ) < 0.07f && !finish)
        {
            finish = true;

            // Destroy arrow FIRST
            // so other errors cannot leave it stuck on screen.
            Destroy(gameObject);

            // Miss score
            if (Score.Instance != null)
            {
                Score.Instance.Miss();
            }

            // Explosion effect
            if (Explosion != null)
            {
                ParticleSystem fx = Instantiate(
                    Explosion,
                    getPosition(),
                    Quaternion.identity
                );

                fx.Play();

                Destroy(
                    fx.gameObject,
                    fx.main.duration
                );
            }

            // Clear range lists
            if (range != null)
            {
                range.ClearLists();
            }
        }
    }

    public void Curve()
    {
        Vector3 forward =
            (targetPosition - startPosition).normalized;

        Vector3 right =
            Vector3.Cross(Vector3.up, forward);

        Vector3 mid =
            (startPosition + targetPosition) * 0.5f;

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

    public Vector3 getPosition()
    {
        return transform.position;
    }
}