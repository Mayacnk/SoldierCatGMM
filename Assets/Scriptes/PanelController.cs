using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace MayaGame {
    public class PanelController : MonoBehaviour
    {
        public static PanelController Instance;
        public Image objImg, prodImg;
        public GameObject prodGo;
        public TextMeshProUGUI objTsk, prodName;

        private void Awake()
        {
            Instance = this;
        }
    }
}