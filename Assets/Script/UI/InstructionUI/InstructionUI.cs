using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstructionUI : MonoBehaviour
{
    public Sprite[] listSprite;
    public Image image;
    public TMP_Text textMess;
    public Button OK;
    public Button Skip;
    private string[] messInstruction;
    public int index = 0;
    async void Start()
    {
        AddListInstruction();
        OK.onClick.AddListener(OnOKClick);
        Skip.onClick.AddListener(OnSkipClick);
        await Task.Delay(1000);
        Display(index);
        Time.timeScale = 0;
    }
    public void AddListInstruction(){
        messInstruction = new string[]{"Nút hiển thị nhiệm vụ và thanh tiến độ thực hiện nhiệm vụ.",
                                       "Thanh máu của số lượng lính trong đội quân",
                                       "Thu thập đủ tài nguyên để thực hiện nhiệm vụ",
                                       "Vị trí xây dựng nhà chính",
                                       "Khi nhà chính được xây, quái vật sẽ xuất hiện từng đợt để phá hủy",
                                       "Nếu nhà chính bị phá hủy hoặc không còn đội quân, bạn sẽ thua!",
                                       "Bảo vệ nhà chính khỏi những đợt tấn công của quái vật",
                                       "Nút thay đổi đội hình và các item hỗ trợ",
                                       "Để ý cảnh báo khi nhà chính bị tấn công",  
                                       "Để ý hướng mũi tên chỉ dẫn đến các nhà giam và quay lại nhà chính",                                    
                                       "Di chuyển đến nhà giam để giải cứu đồng đội, cẩn thận những quái vật canh gác",
                                       "Di chuyển lại gần mục tiêu để tấn công, nhận vàng khi tiêu diệt",
                                       "Di chuyển lại gần đồng đội tập hợp đội quân",
                                       "Thực hiện những nhiệm vụ để tăng sức mạnh",                                     
                                       "Cuối cùng: Đánh bại Boss để hoàn thành màn chơi!"
                            
                            };

    }
    public void OnOKClick(){
        index++;
        if(index==listSprite.Count()){
            OnSkipClick();
            return;
        }
        Display(index);
    }
    public void OnSkipClick(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void Display(int index){
        image.sprite = listSprite[index];
        textMess.text = messInstruction[index];
    }
    
}
