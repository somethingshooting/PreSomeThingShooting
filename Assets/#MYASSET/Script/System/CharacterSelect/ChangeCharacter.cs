using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField] GameObject CharacterRoot = null;
    [SerializeField] TextMeshProUGUI NameText = null;

    [SerializeField] private float RotateTime = 0.7f;

    private bool Rotating = false, Akane = true;

    public void RotateCharacters(bool right)
    {
        if (!Rotating)
        {
            StartCoroutine(Rotate(RotateTime, right));
        }
    }

    private IEnumerator Rotate(float rotateTime, bool right)
    {
        Rotating = true;
        float timer = 0;
        while (timer < RotateTime)
        {
            if (right)
            {
                CharacterRoot.transform.Rotate(Vector3.up, -180 * Time.deltaTime / rotateTime);
            }
            else
            {
                CharacterRoot.transform.Rotate(Vector3.up, 180 * Time.deltaTime / rotateTime);
            }
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
        if (Akane)
        {
            CharacterRoot.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            Akane = false;
            NameText.text = "My";
        }
        else
        {
            CharacterRoot.transform.rotation = Quaternion.Euler(Vector3.zero);
            Akane = true;
            NameText.text = "Akane";
        }
        Rotating = false;
    }
}
