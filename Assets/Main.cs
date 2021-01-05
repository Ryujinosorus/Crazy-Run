using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    bool isPlaying = false;
    [SerializeField]public GameObject canvas;
    void Update()
    {
        if (Input.touchCount != 0 && !isPlaying && EventSystem.current.currentSelectedGameObject == null)
        {
            GetComponent<ChefDeProjet>().enabled = true;
            Camera.main.GetComponent<MooveCamera>().enabled = true;
            Camera.main.transform.Find("Player").GetComponent<Animator>().SetTrigger("StartRun");
            canvas.transform.Find("mainMenu").gameObject.SetActive(false);
            isPlaying = true;
        }
    }

    public void reStart()
    {
        GetComponent<AdManager>().showAds();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
