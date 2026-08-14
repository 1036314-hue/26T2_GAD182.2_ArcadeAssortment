using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace Ithiel
{
    

public class CounterButton : MonoBehaviour
{
public Testing manager;
public RectTransform canvas;
[SerializeField] private ParticleSystem Explosion;
public void Setup(Testing mng, RectTransform cvs)
{
    manager = mng; 
    canvas = cvs;
    GetComponent<Button>().onClick.AddListener(Clicked);
}

void Clicked()
{
     float canvasWidth = canvas.rect.width;
        float canvasHeight = canvas.rect.height;

        const float buttonWidth = 160f;
        const float buttonHeight = 30f;

    manager.SpawnButton(buttonWidth, buttonHeight, canvasHeight, canvasWidth);
    Score.Instance.Counter();
    RectTransform rect = GetComponent<RectTransform>();

Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(
    null,
    rect.position
);

Vector3 newPos = Camera.main.ScreenToWorldPoint(
    new Vector3(screenPos.x, screenPos.y, 4f)
);
    ParticleSystem fx = Instantiate(
                    Explosion,
                    newPos,
                    Quaternion.identity
                );
                ParticleSystem.MainModule main = fx.main;
                main.useUnscaledTime=true;
                fx.Play();
                Destroy(fx.gameObject, fx.main.duration);
    Destroy(gameObject);
}
}
}
