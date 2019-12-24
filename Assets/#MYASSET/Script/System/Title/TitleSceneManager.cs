using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{

    public void ChangeCharacterSelectScene()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ChangeScene(SceneType.CharacterSelect);
    }
}
