using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] private TMP_Text collectibleText;
    [SerializeField] private TMP_Text winText;

    public void Initialize(int totalCollectibles)
    {
        if (winText != null) winText.gameObject.SetActive(false);
        SetProgress(0, totalCollectibles);
    }

    public void SetProgress(int current, int total)
    {
        if (collectibleText != null)
        {
            collectibleText.text = $"Monedas: {current} / {total}";
        }
    }

    public void ShowWin()
    {
        if (winText != null)
        {
            winText.gameObject.SetActive(true);
        }
    }
}