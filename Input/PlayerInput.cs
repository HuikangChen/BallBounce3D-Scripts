using UnityEngine;
using TMPro;
using BB3D.Platform;

namespace BB3D.Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        public static PlayerInput instance;

        [SerializeField] public Transform target;
        [SerializeField] float moveSpeed;
        [SerializeField] TextMeshProUGUI speedDisplay;

        private Vector2 originInputPos;
        private Vector2 previousInputPos;
        private Vector2 currentInputPos;
        private Vector2 moveAmount;

        private bool disabled;

        private void Awake()
        {
            instance = this;
            DisableInput();
        }

        private void Update()
        {
            if (disabled)
            {
                moveAmount = Vector2.zero;
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                currentInputPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                              Camera.main.ScreenToWorldPoint(Input.mousePosition).z);

                originInputPos = currentInputPos;
                previousInputPos = currentInputPos;
            }

            if (Input.GetMouseButton(0))
            {
                CalculateMoveVector();
            }

            if (Input.GetMouseButtonUp(0))
            {
                moveAmount = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            if (target == null)
                return;

            Vector3 targetMoveVector = new Vector3(moveAmount.x, 0, moveAmount.y * 2);
            target.Translate(targetMoveVector * Time.deltaTime * moveSpeed);
        }

        void CalculateMoveVector()
        {

            currentInputPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                              Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
            if (currentInputPos != previousInputPos)
            {
                Vector2 temp = currentInputPos - previousInputPos;
                float magnitude = temp.magnitude;
                moveAmount = -((currentInputPos - previousInputPos).normalized) * magnitude;
                previousInputPos = currentInputPos;
            }
            else
            {
                moveAmount = Vector2.zero;
            }
        }

        public void DisableInput()
        {
            disabled = true;
        }

        public void EnableInput()
        {
            disabled = false;
        }

        public void IncreaseSpeed()
        {
            moveSpeed += 5;
            speedDisplay.text = moveSpeed + "";
        }

        public void DecreaseSpeed()
        {
            moveSpeed -= 5;
            speedDisplay.text = moveSpeed + "";
        }

        public void FindPlatformRoot()
        {
            target = FindObjectOfType<PlatformSpawner>().platformRoot.transform;
        }
    }
}