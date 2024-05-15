using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public int characterIndex;
    public bool isSTD;
    public static MenuManager singleTon;
    private void Awake()
    {
        singleTon = this;
    }

    public void SetCharacterIndex(int index)
    {
        characterIndex = index;
        
    }
    public void SetQuestiontype(bool typeSTD)
    {
        isSTD = typeSTD;
        SceneManager.LoadScene("Main");
    }
}
