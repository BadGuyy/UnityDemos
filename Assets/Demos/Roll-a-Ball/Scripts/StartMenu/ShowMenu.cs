using DG.Tweening;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{

    public GameObject menuAnchor;
    public void onClickMenu()
    {
        transform.parent.DOMove(transform.parent.position + new Vector3(-50, 0, 0), 0.5f);

        menuAnchor.SetActive(true);
        menuAnchor.transform.position = menuAnchor.transform.position + new Vector3(-90, 0, 0);
        menuAnchor.transform.DOMove(menuAnchor.transform.position + new Vector3(40, 0, 0), 0.15f);
    }


}
