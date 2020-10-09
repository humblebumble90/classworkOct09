using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//New on Oct.06
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    //New on Oct.06
    public Text scoreTxt;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Debug.Log("mp=" + mousePos);
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
    //New on Oct.06
    private void Start()
    {
        GameObject scoreGO = GameObject.Find("Score");
        scoreTxt = scoreGO.GetComponent<Text>();
        scoreTxt.text = "Score: 0";
    }
    void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.tag == "Apple")
        {
            Destroy(go);
        }
        //New on Oct.06
        int score = int.Parse(scoreTxt.text.Substring(6));
        score += 1;
        scoreTxt.text = "Score: " + score.ToString();     
        if(score > HighScore.score)
        {
            HighScore.score = score;
        }
    }
}
