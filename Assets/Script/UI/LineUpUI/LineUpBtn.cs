
using Script.Event;
using Script.Player.Army;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI.LineUpUI
{
    public class LineUpBtn : MonoBehaviour
    {
        public LineUp lineUp;

        private Button btn;
        private void Start()
        {
            btn = GetComponent<Button>();
            btn.onClick.AddListener(() => ArmyEvent.ChangeLineUpArmy?.Invoke(lineUp));
        }
    }
}