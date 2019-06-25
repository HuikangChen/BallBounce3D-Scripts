using UnityEngine;
using BB3D.SO;

namespace BB3D.UI
{
    public class PlayInstruction : MonoBehaviour
    {
        [SerializeField] private IntVariable currentLevel;
        [SerializeField] private GameObject playInstruction;

        public void ShowPlayInstruction()
        {
            if (currentLevel.GetValue() == 1)
                playInstruction.SetActive(true);
            else
                playInstruction.SetActive(false);
        }
    }
}