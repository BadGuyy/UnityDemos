using UnityEngine;

public class UIFollowObject : MonoBehaviour
{
    [SerializeField]
    GameObject entity;//3D物体（人物
    [SerializeField]
    GameObject canvas;//UI画布（如：血条等
    [SerializeField]
    Vector3 offset;//偏移量

    void Awake()
    {
        offset = canvas.transform.position - entity.transform.Find("LookRoot").transform.position;
    }

    void LateUpdate()
    {
        canvas.transform.position = entity.transform.Find("LookRoot").transform.position + offset;
    }
}
