using UnityEngine;

public class LoseLevel : MonoBehaviour
{
    [SerializeField] private GameEvent onLevelLose;
    [SerializeField] private BoolVariable isGameOver;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            isGameOver.SetValue(true);
            onLevelLose.Raise();
        }
    }

    public void OnLevelStart_CallBack() {
        isGameOver.SetValue(false);
    }

    //Toggles KillPlayer Object so that player can fall without 
    //penalty once level is won
    public void DisableSelf()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    public void EnableSelf()
    {
        GetComponent<BoxCollider>().enabled = true;
    }
}
