using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    public float sensitivity = 100;

    private float rotation = 0;

    void Start()
    {
        // On start lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float x = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        float y = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;

        rotation -= y;
        // Clamp camera rotation from going lower than -90 or higher than 90
        rotation = Mathf.Clamp(rotation, -90, 90); 

        transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        // Rotate the player body according to the x axis movement of the camera
        playerBody.Rotate(Vector3.up * x);
    }
}
