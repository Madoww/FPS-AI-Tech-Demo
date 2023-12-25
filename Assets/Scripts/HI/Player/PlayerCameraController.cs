using UnityEngine;

namespace FPS.HI.Player
{
    public class PlayerCameraController : MonoBehaviour, IPlayerCameraController
    {
        //TODO: Proper injection
        [SerializeField]
        private new Camera camera;
        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private Vector2 sensitivity;
        [SerializeField, Min(0)]
        private float maxRotationSpeed;

        private float xRotation = 0f;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void ProcessLook(Vector2 input)
        {
            float mouseX = input.x;
            float mouseY = input.y;

            xRotation -= mouseY * Time.deltaTime * sensitivity.y;
            xRotation = Mathf.Clamp(xRotation, -maxRotationSpeed, maxRotationSpeed);
            camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            float yRotation = mouseX * Time.deltaTime * sensitivity.x;
            yRotation = Mathf.Clamp(yRotation, -maxRotationSpeed, maxRotationSpeed);
            playerTransform.Rotate(Vector3.up * yRotation);
        }
    }
}