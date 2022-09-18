using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    private void Awake() => Instance = this;

    public void Replay() => SceneManager.LoadScene("GameScene");

    public void GamesComplete() => StartCoroutine(GamesCompleteDelay());

    private IEnumerator GamesCompleteDelay() {
        UIManager.Instance.FadeOut();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("EndScene");
    }
}
