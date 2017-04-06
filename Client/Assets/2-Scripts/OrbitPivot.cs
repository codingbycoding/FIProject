using UnityEngine;


public class OrbitPivot : MonoBehaviour
{
    public float sensitivity = 25f;

    private void LateUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.right * Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity, Space.Self);
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity, Space.World);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}