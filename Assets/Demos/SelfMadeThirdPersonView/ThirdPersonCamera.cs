using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float CameraSpeed = 0.1f;
    [Header("Cinemachine Camera")]
    [Tooltip("跟随的目标")]
    public GameObject CameraTarget;

    float TopClamp = 89.9f;

    float BottomClamp = -89.9f;

    const float threshold = 0.01f;
    float cinemachineTargetYaw;
    float cinemachineTargetPitch;

    void Awake()
    {
        // 使摄像机的初始前视角和目标一致
        cinemachineTargetYaw = CameraTarget.transform.rotation.eulerAngles.y;
    }
    void Update()
    {
        // 当每帧视角移动的距离超过一定阈值时，更新cinemachine的目标角度
        if (look.sqrMagnitude > threshold)
        {
            cinemachineTargetYaw += look.x * CameraSpeed;
            cinemachineTargetPitch -= look.y * CameraSpeed;

            // 限制偏航角范围
            if (cinemachineTargetYaw <= -360.0f) cinemachineTargetYaw += 360.0f;
            if (cinemachineTargetYaw >= 360.0f) cinemachineTargetYaw -= 360.0f;
            // cinemachineTargetYaw = Mathf.Clamp(cinemachineTargetYaw, -360.0f, 360.0f);
            // 限制俯仰角范围
            cinemachineTargetPitch = Mathf.Clamp(cinemachineTargetPitch, BottomClamp, TopClamp);

            // 更新目标角度
            CameraTarget.transform.rotation = Quaternion.Euler(new Vector3(cinemachineTargetPitch, cinemachineTargetYaw, 0.0f));
            // CameraTarget.transform.parent.transform.rotation = Quaternion.Euler(0.0f, cinemachineTargetYaw, 0.0f);
        }


    }
    Vector2 look;

    public void OnLook(InputValue input)
    {
        look = input.Get<Vector2>();
    }
}
