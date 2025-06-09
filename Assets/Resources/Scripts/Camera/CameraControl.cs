using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
    private float inputX, inputZ;
    public float speed;
    public float zoomSpeed;
    private float minDistance, maxDistance, currentDistance;
    private float zoomVelocity = 0f;  // 用于 SmoothDamp 缓存速度
    private float smoothY;
    public float scroll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 15.0f;
        minDistance = 4f;
        maxDistance = 9.0f;
        zoomSpeed = 5f;
        smoothY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");
        Vector3 input = new Vector3(inputX, 0f, inputZ).normalized;
        Vector3 move = transform.TransformDirection(input) * speed * Time.deltaTime;
        Vector3 newPosition = new Vector3(transform.position.x + move.x, transform.position.y, transform.position.z + move.z);
        transform.position = newPosition;

        // 滚轮缩放目标更新
        scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            smoothY -= scroll * zoomSpeed;
            smoothY = Mathf.Clamp(smoothY, minDistance, maxDistance);
        }

        // 将摄像机 Y 平滑地推向 smoothY
        float newY = Mathf.SmoothDamp(transform.position.y, smoothY, ref zoomVelocity, 0.15f);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}