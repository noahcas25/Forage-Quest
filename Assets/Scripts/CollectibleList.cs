using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectibleList : MonoBehaviour
{
    [SerializeField] private Transform _collectibles;
    [SerializeField] private Transform _listInts;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _collectAudio;
    [SerializeField] private AudioClip _listAudio;

     int[] _collectibleCount = new int[12];
     private RectTransform _listPosition;

    public static CollectibleList Instance {get; private set;}

    private void Awake() {
        Instance = this;
        _listPosition = this.gameObject.GetComponent<RectTransform>();
    }

    public void MoveIn() {
        if(LeanTween.isTweening(_listPosition)) return;
        _audio.PlayOneShot(_listAudio);

        LeanTween.moveX(_listPosition, 606f, 0.5f);
        LeanTween.moveY(_listPosition, 69f, 0.5f);
        LeanTween.scale(_listPosition, new Vector3(1f, 1f, 1f), 0.5f);
    }

    public void MoveOut() {
        if(LeanTween.isTweening(_listPosition)) return;
        _audio.PlayOneShot(_listAudio);
        
        LeanTween.moveX(_listPosition, 890f, 0.5f);
        LeanTween.moveY(_listPosition, 430f, 0.5f);
        LeanTween.scale(_listPosition, new Vector3(0.15f, 0.15f, 0.15f), 0.5f);
    }

    public void UpdateList(int index) {
        _audio.PlayOneShot(_collectAudio);
        _collectibleCount[index]++;
        UIManager.Instance.UpdateText(index, _collectibleCount[index]);

        if(_collectibles.childCount == 1) {
            GameManager.Instance.GamesComplete();
        }
    }
}
