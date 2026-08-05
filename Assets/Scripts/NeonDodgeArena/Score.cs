using TMPro;
using UnityEngine;
namespace Ithiel
{
public class Score : MonoBehaviour
{
    public static Score Instance;

[SerializeField]
private int score;
[SerializeField]
private int combo;

[SerializeField]
private int arrowScore = 2000;
[SerializeField]
private int counterScore = 10000;

[SerializeField]
private int comboBonusCount = 10;
[SerializeField]
private int comboScore = 10000;
[SerializeField]
private RangeManager range;
[SerializeField]
private TMP_Text scoreText;
[SerializeField]
private TMP_Text comboText;
void OnAwake(){
    score = 0;
    combo = 0;
    
}

private void Awake()
{
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
    this.score = 0;
    this.combo = 0;
    DontDestroyOnLoad(gameObject);
}

public void Miss(){
    combo = 0;
        range.ClearLists();
        UpdateText();
}

public void Arrow(){
    score += arrowScore;
    combo++;
    if(combo % comboBonusCount == 0)
    {
        score += (combo / comboBonusCount) * comboScore;
       
    }
    UpdateText();
}


public void Counter(){
    score += counterScore;
    UpdateText();
}
private void UpdateText(){
    scoreText.text = score.ToString();
    comboText.text = combo.ToString();
}
}
}
