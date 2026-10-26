using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int requiredCollectibles = 17;
    [SerializeField] private GameView view;

    private int collectedCount;

    private void Start()
    {
        collectedCount = 0;
        if (view != null)
        {
            view.Initialize(requiredCollectibles);
        }
    }

    public void CollectItem()
    {
        collectedCount++;

        if (view != null)
        {
            view.SetProgress(collectedCount, requiredCollectibles);
        }

        if (collectedCount >= requiredCollectibles)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        if (view != null)
        {
            view.ShowWin();
        }
        Debug.Log("¡Condición de victoria alcanzada!");
    }
}