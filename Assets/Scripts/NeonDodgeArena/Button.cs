using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
namespace Ithiel
{
    

public class CounterButton : MonoBehaviour
{
public Testing manager;
public RectTransform canvas;
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
    Destroy(gameObject);
}
}
}
