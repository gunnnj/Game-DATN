using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class ShakeAndDestroy : MonoBehaviour
{
    public float shakeDuration = 0.5f; // Thời gian shake
    public float shakeStrength = 1.0f; // Độ mạnh của shake
    public int shakeVibrato = 10; // Số lần rung
    public float moveDownDuration = 1.0f; // Thời gian di chuyển xuống
    public float moveDownDistance = 5.0f; // Khoảng cách di chuyển xuống
    public GameObject effect;

    void OnEnable()
    {
        GameEvent.loseGame += TriggerShakeAndMove;
    }

    [ContextMenu("Lose")]
    public async void TriggerShakeAndMove(int type)
    {
        if(type == 1){
            await Task.Delay(1000);
            // Hiệu ứng shake
            Vector3 shakeDirection = new Vector3(shakeStrength, 0, shakeStrength);
            transform.DOShakePosition(shakeDuration, shakeDirection, shakeVibrato, 0, false, true)
                .OnComplete(MoveDown); // Khi shake xong, gọi hàm MoveDown
        }
        
    }

    private void MoveDown()
    {
        Instantiate(effect,transform.position,Quaternion.identity);
        AudioManager.Instance.PlaySfx(AudioManager.SoundFXData.Earthquake);
        // Di chuyển xuống
        transform.DOMoveY(transform.position.y - moveDownDistance, moveDownDuration)
            .SetEase(Ease.OutBounce); // Thêm hiệu ứng di chuyển
    }
}
