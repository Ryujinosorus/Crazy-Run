using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChefDeProjet : MonoBehaviour
{
    [SerializeField] GameObject go;
    [SerializeField] Text scoreTXT;
    [SerializeField] AudioClip game, death, GETOFFTHESTAGE;
    int middleOfScreen;
    Queue<GameObject> map = new Queue<GameObject>();
    int nbPlatSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        middleOfScreen = Screen.width / 2;
        GetComponent<AudioSource>().clip = game;
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < 5; i++)
        {
            generatePlatform();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            bool left = false;
            if (Input.GetTouch(0).position.x < middleOfScreen)
                left = true;
            GameObject tmp = map.Dequeue();
            if ((tmp.transform.position.z < 0 && left) ||( tmp.transform.position.z > 0 && !left))
            {
                loose();
                return;
            }
            tmp.transform.position = new Vector3(tmp.transform.position.x,0,0);
            generatePlatform();
        }

    }
    void generatePlatform()
    {
        scoreTXT.text = (nbPlatSpawn - 4).ToString();
        int z = Random.Range(0, 2) <= 0.5f ? 5 : -5;
        map.Enqueue(Instantiate(go, new Vector3(nbPlatSpawn * go.transform.localScale.x, 0, z), Quaternion.identity));
        nbPlatSpawn++;
    }
    public void loose()
    {
        GetComponent<AudioSource>().clip = death;
        GetComponent<AudioSource>().Play();
        AudioSource tmp = gameObject.AddComponent<AudioSource>();
        tmp.volume = PlayerPrefs.GetFloat("crazy_vol", 1);
        tmp.clip = (GETOFFTHESTAGE);
        tmp.Play();
        Camera.main.GetComponent<MooveCamera>().enabled = false;
        Camera.main.transform.Find("Player").GetComponent<Animator>().SetTrigger("tackle");
        this.enabled = false;
        GetComponent<Main>().canvas.transform.Find("deathMenu").gameObject.SetActive(true) ;
        if (int.Parse(PlayerPrefs.GetString("hs_crazyrunner", "0")) < nbPlatSpawn - 4)
            PlayerPrefs.SetString("hs_crazyrunner",(nbPlatSpawn -5).ToString());
    }
}
