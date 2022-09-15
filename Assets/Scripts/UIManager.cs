using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{   
    [SerializeField] private Transform _listIntsCurrent;
    [SerializeField] private Transform _listIntsFinal;
    [SerializeField] private Transform _listCheckMarks;
    private TextMeshProUGUI[] _collectibleCountTextsCurrent = new TextMeshProUGUI[12];
    private TextMeshProUGUI[] _collectibleCountTextsFinal = new TextMeshProUGUI[12];

    public static UIManager Instance {get; private set;}

    private void Awake() {
        Instance = this;

        for(int i = 0; i < _listIntsCurrent.childCount; i++) {
            _collectibleCountTextsCurrent[i] = _listIntsCurrent.GetChild(i).GetComponent<TextMeshProUGUI>();
            _collectibleCountTextsFinal[i] = _listIntsFinal.GetChild(i).GetComponent<TextMeshProUGUI>();
        }    
    }

    public void UpdateText(int index, int value) {
        _collectibleCountTextsCurrent[index].text = value + "";
        
        if((_collectibleCountTextsCurrent[index].text).Equals(_collectibleCountTextsFinal[index].text))
            _listCheckMarks.GetChild(index).gameObject.SetActive(true);
    }
}
