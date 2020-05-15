using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [Header("選定方塊")]
    public GameObject cube;
    [Header("使用藥水")]
    public Text drink;
    public string input;
    [Header("血量顯示")]
    public Slider bar;
    public Text HpDetect;
    public Text HpState;
    
    public void EndInput(string x)
    {
        input = x;
    }

    private float _hp;
    public float HP { get { return _hp; } set { _hp = value; } }

    public void CreateTriangle(int x, int y)
    {
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Instantiate(cube, new Vector3(x + i * 2, y + j * 2, 15), Quaternion.Euler(270, 0, 0));
            }
        }
    }

    private void Start()
    {
        CreateTriangle(1, -12);
    }

    private void Update()
    {
        _hp = bar.value;
        HpDetect.text = "" + HP;
        if (HP <= 30)
            HpState.text = "危險";
        else if (HP <= 70 && HP > 30)
            HpState.text = "警告";
        else
            HpState.text = "安全";

        drink.text = (input == "紅水") ? "生命恢復中..." : (input == "藍水") ? "魔力恢復中..." : (input == "") ? "" : "指令錯誤！";
    }
}
