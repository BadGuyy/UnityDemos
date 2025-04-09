using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PageMenu : MonoBehaviour
{
    public Button btn_logo;
    bool isMenuOpen = false;

    public GameObject menuPos_1;
    public GameObject menuPos_2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        btn_logo.onClick.AddListener(OnClickMenu);
        btn_logo.gameObject.transform.position = menuPos_1.transform.position;
        menuPos_1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnClickMenu()
    {
        if(!isMenuOpen)
        {
            btn_logo.gameObject.transform.DOMove(menuPos_2.transform.position, 0.3f);
            Invoke("fun",0.3f);
            isMenuOpen = true;
        }
    }

    void fun()
    {
        menuPos_1.gameObject.SetActive(true);
    }
}
