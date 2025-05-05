using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonMovement : MonoBehaviour
{
    CharacterController controller;
    public GameObject mainCamera;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    float speed = 6.0f;
    float targetRotation = 0.0f;
    // 平滑旋转时间
    public float RotationSmoothTime = 0.3f;
    float rotationVelocity;
    void Update()
    {
        Vector3 verticalVelocity = Vector3.down;
        if(move != Vector2.zero)
        {
            // 计算输入方向，将其转换为世界空间坐标系下的方向
            Vector3 inputDirection = new Vector3(move.x, 0.0f, move.y).normalized;
            // 计算目标旋转角度
            targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + mainCamera.transform.eulerAngles.y;
            // 平稳旋转玩家，使其面向移动方向
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity, RotationSmoothTime);
            // 旋转玩家到目标角度
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            // 计算移动方向
            Vector3 targetDirection = Quaternion.Euler(0.0f, rotation, 0.0f) * Vector3.forward;
            verticalVelocity += targetDirection.normalized * (speed * Time.deltaTime);
        }
        // 移动玩家
        controller.Move(verticalVelocity);
    }

    Vector2 move;
    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }
}
