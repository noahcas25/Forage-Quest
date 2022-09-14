using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleList : MonoBehaviour
{
     [SerializeField] private Transform _listInts;
     [SerializeField] private Button _closeButton;

     int[] _collectibleCount = new int[12];
     private RectTransform _listPosition;
     TextMeshProUGUI[] _collectibleCountTexts = new TextMeshProUGUI[12];

    public static CollectibleList Instance {get; private set;}

    private void Awake() {
        Instance = this;
        _listPosition = this.gameObject.GetComponent<RectTransform>();
        
        for(int i = 0; i < _listInts.childCount; i++) {
            _collectibleCountTexts[i] = _listInts.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
    }

    public void MoveIn() {
        _closeButton.enabled = true;

        LeanTween.moveX(_listPosition, 606f, 0.5f);
        LeanTween.moveY(_listPosition, 69f, 0.5f);
        LeanTween.scale(_listPosition, new Vector3(1f, 1f, 1f), 0.5f);
    }

    public void MoveOut() {
        _closeButton.enabled = false;
        
        LeanTween.moveX(_listPosition, 890f, 0.5f);
        LeanTween.moveY(_listPosition, 430f, 0.5f);
        LeanTween.scale(_listPosition, new Vector3(0.15f, 0.15f, 0.15f), 0.5f);
    }

    public void UpdateList(int index) {
        _collectibleCount[index]++;
        UpdateText(index);
    }

    private void UpdateText(int index) {
        _collectibleCountTexts[index].text = _collectibleCount[index] + "";
    }
}
