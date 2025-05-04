using UnityEngine;

public class CubeLookAt : MonoBehaviour
{
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        // 检测到空格输入就执行物体的z轴指向指定物体的旋转
        if(Input.GetKey(KeyCode.Space))
        {
            // transform.LookAt(target.transform);
            transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
        }
    }
}