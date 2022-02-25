using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdvanceScene : MonoBehaviour
{

    [SerializeField] public string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void NextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            NextScene();
        }
    }
}
