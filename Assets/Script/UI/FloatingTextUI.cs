using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FloatingTextUI : MonoBehaviour
{
    public TMP_Text textComponent;
    private float floatDuration = 0.5f;
    private float fadeDuration = 0.3f;
    private float floatHeight = 1.5f;

    // void Start()
    // {
    //     ShowText(10);
    // }
    public void ShowText(int dame)
    {
        textComponent.text = "-"+dame;
        textComponent.transform.localScale = Vector3.one; // Đặt kích thước mặc định

        // Hiệu ứng nổi lên
        textComponent.transform.DOMoveY(textComponent.transform.position.y + floatHeight, floatDuration)
            .OnComplete(() => 
            {
                // Hiệu ứng biến mất
                textComponent.DOFade(0, fadeDuration).OnComplete(() => 
                {
                    // Reset lại vị trí và độ mờ
                    textComponent.transform.position = new Vector3(textComponent.transform.position.x, 
                                                                    textComponent.transform.position.y - floatHeight, 
                                                                    textComponent.transform.position.z);
                    textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, 1);
                    textComponent.gameObject.SetActive(false);
                    Destroy(this.gameObject,0.5f);
                });
            });
    }
}
