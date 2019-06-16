using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel : MonoBehaviour
{
    [SerializeField] private IntVariable currentStar;
    [SerializeField] private IntVariable maxStar;
    [SerializeField] private GameEvent onLevelWin;
    private static bool gameWon;

    public void TryWinGame()
    {
        if (AllStarsPickedUp() && gameWon == false)
        {
            gameWon = true;
            onLevelWin.Raise();
        }
    }

    bool AllStarsPickedUp()
    {
        return currentStar.GetValue() == maxStar.GetValue();
    }

    public void ResetStars()
    {
        gameWon = false;
        currentStar.SetValue(0);
        maxStar.SetValue(0);
    }
}
