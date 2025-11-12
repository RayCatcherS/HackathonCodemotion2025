using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    public Transform orientation;

    private float xRotation;
    private float yRotation;

    [SerializeField] private bool invertY = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        if (invertY) {
            xRotation += mouseY;
        } else {
            xRotation -= mouseY;
        }
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotate cam and orientation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
