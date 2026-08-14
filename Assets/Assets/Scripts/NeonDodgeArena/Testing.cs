using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ithiel {

  public class Testing : MonoBehaviour
  {
    [SerializeField]
    private ArrowMovement leftPrefab;
    [SerializeField]
    private ArrowMovement upPrefab;
    [SerializeField]
    private ArrowMovement downPrefab;
    [SerializeField]
    private ArrowMovement rightPrefab;
    [SerializeField] private GameObject gameOverCanvas;
    private ArrowMovement getPrefab(NoteKey Direction)
        {
            switch(Direction)
         {
      case NoteKey.Up:
        return upPrefab;
        
      case NoteKey.Left:
        return leftPrefab;
        
      case NoteKey.Down:
         return downPrefab;
     
      case NoteKey.Right:
      return rightPrefab;
       
         }
         return upPrefab;
        }
    [SerializeField]
    private Transform bossPosition;
    [SerializeField]
    private RangeManager range;
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
    [SerializeField]
    private RectTransform canvas;
    [SerializeField]
    private Button buttonPrefab;
    [SerializeField]
    private int minButtons = 7;
    [SerializeField]
    private int maxButtons = 13;
    private List<Button> buttons = new();
   private Vector3 camPos;
    private Quaternion camRot;

    [SerializeField] 
    private Transform newCamPos;
    [SerializeField] 
    private float cameraMoveTime = 1f;
    [SerializeField]
    private TMP_Text gameTimer;
    [SerializeField]
    private float topPad = 0.2f;
    [SerializeField]
    private float botPad = 0.1f;
    [SerializeField]
    private float sidePad = 0.25f;
    private bool start = false;
    public void Shoot(NoteKey direction){
      
      NotesData test = new NotesData()
      {
        key = direction,
        floatTime = Random.Range(minFlight,maxFlight)
      };
      ArrowMovement note = Instantiate(getPrefab(direction), bossPosition.position, Quaternion.identity, bossPosition);
      note.arrows = test;
      note.targetPosition =  targetPosition.position;
      note.range= range;
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

    public void StartGame(){
      
    StartCoroutine(Punching());
    }
    IEnumerator Punching()
    {
        start = true;
        StartCoroutine(GameTimer());
        float elapsed = 0;
        float pauseTimer = 0;
        while (elapsed < gameTime) 
        {
            float delay = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(delay);
            elapsed += delay;
            pauseTimer += delay;
            if (pauseTimer >= 20f)
            {
                pauseTimer = 0f;

                yield return StartCoroutine(CounterAttack());
            }


            Shoot(RandomKey());
        }
        start = false;
       yield return new WaitForSecondsRealtime(0.5f);
       gameOverCanvas.SetActive(true);
       Time.timeScale=0;
    }
    IEnumerator CounterAttack()
    {
        Time.timeScale = 0f;
       camPos = Camera.main.transform.position;
        camRot = Camera.main.transform.rotation;

        yield return StartCoroutine(MoveCamera(newCamPos.position, newCamPos.rotation));
        int count = Random.Range(minButtons, maxButtons);

        float canvasWidth = canvas.rect.width;
        float canvasHeight = canvas.rect.height;

        const float buttonWidth = 160f;
        const float buttonHeight = 30f;

        for (int i = 0; i < count; i++)
        {
            SpawnButton(buttonWidth, buttonHeight, canvasHeight, canvasWidth);
            yield return new WaitForSecondsRealtime(0.08f);
        }

        yield return new WaitForSecondsRealtime(5f);
       
        foreach(Button button in buttons)
        {
            if (button != null) Destroy(button.gameObject);
        }
         yield return StartCoroutine(MoveCamera(camPos, camRot));

        Time.timeScale = 1f;
      }
      IEnumerator MoveCamera(Vector3 targetPosition, Quaternion targetRotation)
{
    Transform cam = Camera.main.transform;

    Vector3 startPosition = cam.position;
    Quaternion startRotation = cam.rotation;

    float elapsed = 0f;

    while (elapsed < cameraMoveTime)
    {
        elapsed += Time.unscaledDeltaTime;

        float t = elapsed / cameraMoveTime;

        cam.position = Vector3.Lerp(startPosition, targetPosition, t);
        cam.rotation = Quaternion.Lerp(startRotation, targetRotation, t);

        yield return null;
    }

    cam.position = targetPosition;
    cam.rotation = targetRotation;
}
public void SpawnButton(float buttonWidth, float buttonHeight, float canvasHeight, float canvasWidth)
{
    Button button = Instantiate(buttonPrefab, canvas);

    float topPadding = canvasHeight * topPad;
    float bottomPadding = canvasHeight * botPad;
    float sidePadding = canvasWidth * sidePad;

    float x = Random.Range(-canvasWidth / 2 + sidePadding + buttonWidth / 2, canvasWidth / 2 - sidePadding - buttonWidth / 2);

    float y = Random.Range(-canvasHeight / 2 + bottomPadding + buttonHeight / 2, canvasHeight / 2 - topPadding - buttonHeight / 2);

    button.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);

    CounterButton btn = button.GetComponent<CounterButton>();
    btn.Setup(this, canvas);

    buttons.Add(button);
}
IEnumerator GameTimer()
{
    float remaining = gameTime;

    while (remaining > 0)
    {
        remaining -= Time.deltaTime;

        int totalSeconds = Mathf.CeilToInt(remaining);

        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        gameTimer.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        float percentage = remaining / gameTime;

        if (percentage <= 0.2f)
        {
            gameTimer.color = Color.red;
        }
        else if (percentage <= 0.5f)
        {
            gameTimer.color = Color.yellow;
        }
        else
        {
            gameTimer.color = Color.green;
        }
      
        yield return null;
    }

    gameTimer.text = "00:00:00";
    gameTimer.color = Color.red;

}
public void RestartGame()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
}
}

