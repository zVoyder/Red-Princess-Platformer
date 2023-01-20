using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockPlayerNextSceneFadeOut : MonoBehaviour
{
    public enum Direction
    {
        LEFT = -1,
        RIGHT = 1
    }

    public float timeWaitLoadScene;
    public GameObject cameraObject;
    public Direction direction;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cameraObject.SetActive(true);
        player.inputsController.DisableAllInputs();
        player.Move((float)direction);
        StartCoroutine(WaitAndLoadScene());
    }

    IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(timeWaitLoadScene);
        SceneManager.LoadScene("BaseLevel");
    }
}
