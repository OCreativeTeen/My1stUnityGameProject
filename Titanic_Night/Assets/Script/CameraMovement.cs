using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public void Start()
    {
        Debug.Log("Camera Movement is started");
    }

    public void Update() {
        this.yaw = this.yaw + this.getMouseMove("Mouse X");
        this.pitch = this.pitch - this.getMouseMove("Mouse Y");

        this.transform.eulerAngles = new Vector3(this.pitch, this.yaw, 0.0f);
    }


    private float getMouseMove(string flag) {
        return Input.GetAxis(flag);
    }


}
