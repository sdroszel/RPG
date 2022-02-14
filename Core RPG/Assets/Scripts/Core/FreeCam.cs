using UnityEngine;

public class FreeCam : MonoBehaviour
{

    [SerializeField] float freeLookSensitivity = 3f;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private bool looking = false;

    void Update()
    {
        if (looking)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(Mathf.Clamp(newRotationY, minY, maxY), newRotationX, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartLooking();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopLooking();
        }
    }

    public void StartLooking()
    {
        looking = true;
    }

    public void StopLooking()
    {
        looking = false;
    }
}