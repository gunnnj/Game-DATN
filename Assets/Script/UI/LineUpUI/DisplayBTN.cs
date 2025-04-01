
using DG.Tweening;
using UnityEngine;

using UnityEngine.UI;

namespace Script.UI.LineUpUI
{
    public class DisplayBTN : MonoBehaviour
    {
        private Button mainBtn;
        private RectTransform direct;
        private RectTransform holder;


        private bool turnOn;
        private void Start()
        {
            mainBtn = transform.Find("MainBTN").GetComponent<Button>();
            direct = transform.Find("DirectionBTN").GetComponent<RectTransform>();
            holder = transform.Find("Containt").Find("Holder").GetComponent<RectTransform>();
            turnOn = false;
            holder.anchoredPosition = new Vector2(700, 0);
            mainBtn.onClick.AddListener(ChangeStatusBtn);
        }

        private void ChangeStatusBtn()
        {
            if (!turnOn)
            {
                holder.DOAnchorPos(new Vector2(0, 0), 0.5f);
                direct.rotation = Quaternion.Euler(0, 0, 0);
                turnOn = true;
            }
            else
            {
                holder.DOAnchorPos(new Vector2(700, 0), 0.5f);
                direct.rotation = Quaternion.Euler(0, 0, 180);
                turnOn = false;
            }
        }
    }
}