using UnityEngine;

public class TestCameraController : MonoBehaviour
{
    public GameObject player;

    Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(player != null)
            transform.position = player.transform.position + offset;
    }
}
