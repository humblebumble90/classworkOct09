using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
public class ApplePicker : MonoBehaviour
{
    // UI related

    //
    //  ======
    //  ======
    //  ======
    //
    public GameObject basketPrefab;
    public int numBaskets=3;
    public float basketMinY = -14f;
    public float basketSpacingY = 2f;

    //New on Oct.06
    public List<GameObject> basketList;
    //New on Oct.09
    public int seoncdsToWaitBeforeRestart = 3;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(List2());
        //New on Oct.06
        basketList = new List<GameObject>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject basketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketMinY + i * basketSpacingY;
            basketGO.transform.position = pos;
            //New on Oct.06
            basketList.Add(basketGO);
        }
        
    }
    //New on Oct.06
    public void AppleDestroyed()
    {
        //Destroy remaining apples in the scene
        GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject go in apples)
        {
            Destroy(go);
        }

        //Destroy 1 basket
        //If no more baskests, you LOST
        int basketToGoIndex = basketList.Count - 1;
        GameObject basketToGo = basketList[basketToGoIndex];
        basketList.RemoveAt(basketToGoIndex); //remove from list
        Destroy(basketToGo);
        if (basketList.Count == 0)
        {
            StartCoroutine("Lost");
        }

    }
    IEnumerator List2()
    {
        print("One");
        yield return null;
        print("Two");
        yield return null;
        print("Three");
        yield return null;
    }
    IEnumerator Lost()
    {
        yield return new WaitForSeconds(seoncdsToWaitBeforeRestart);
        if(basketList.Count == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scene0");

        }

    }
        // Update is called once per frame
        void Update()
    {
        IEnumerator en = (IEnumerator)(new List<int> { 1, 2, 3, 4 });
        while(en.MoveNext())
        {
            //do sth with en.current
        }

        //SOlution of waiting 3 sec before coroutine
        float time2wait = 2f;
        float elapsedtime = 0;
        while(elapsedtime < time2wait)
            {
            elapsedtime += Time.deltaTime;
        }//Do the thing
    }
}
