using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{

    public void ChangeBattleScene()
    {
        GameObject.FindWithTag("GameManager").GetComponent<GameManager>().ChangeScene(SceneType.Battle);
    }
}
