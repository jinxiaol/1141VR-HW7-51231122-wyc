using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private GameObject timerText;
    [SerializeField]
    private GameObject pointText;
    [SerializeField]
    private GameObject generator;
    private float time = 30.0f;
    private int point = 0;
    public void GetApple()
    {
        this.point += 100;
    }
    public void Bomb()
    {
        this.point /= 2;
    }
    void Update()
    {
        this.time -= Time.deltaTime;
        if (this.timerText != null)
        {
            this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        }
        if (this.pointText != null)
        {
            this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + " point";
        }
        if (this.generator != null)
        {
            ItemGenerator itemGenerator = this.generator.GetComponent<ItemGenerator>();

            if (itemGenerator != null)
            {
                if (this.time < 0)
                {
                    this.time = 0;
                    itemGenerator.SetParameter(10000.0f, 0, 0);
                }
                else if (0 <= this.time && this.time < 4)
                {
                    itemGenerator.SetParameter(0.7f, -0.04f, 3);
                }
                else if (4 <= this.time && this.time < 12)
                {
                    itemGenerator.SetParameter(0.5f, -0.05f, 6);
                }
                else if (12 <= this.time && this.time < 23)
                {
                    itemGenerator.SetParameter(0.8f, -0.04f, 4);
                }
                else if (23 <= this.time && this.time < 30)
                {
                    itemGenerator.SetParameter(1.0f, -0.03f, 2);
                }
            }
        }
    }
}
