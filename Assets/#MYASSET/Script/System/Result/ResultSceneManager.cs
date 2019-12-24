using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultSceneManager : MonoBehaviour
{
    public void ChangeTitleSceoe()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ChangeScene(SceneType.Title);
    }
}
