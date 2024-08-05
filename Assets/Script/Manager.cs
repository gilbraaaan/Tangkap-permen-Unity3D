using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    bool Active = true, gotIt = true;
    public bool ActiveTouch = true;
    float waktu = 0f;
    public GameObject RacunUI, contentScore, getScoreText;
    public TMP_Text scoreText;
    int score = 0;
    public float waktuTetap = 1f;
    public List<GameObject> Objeknya = new List<GameObject>();
    void Update()
    {
        scoreText.text = score.ToString();
        #region Cek Clone
        if (Active)
        {
            if(waktu <= 1)
            {
                waktu += 1 / waktuTetap * Time.deltaTime;
                if (waktu > 1)
                {
                    int PilihanAcak = Random.Range(0, Objeknya.Count - 1);
                    float PosisiAcak = Random.Range(-2.26f, 2.26f);
                    GameObject cloneObject = Instantiate(Objeknya[PilihanAcak], 
                        Objeknya[PilihanAcak].transform.position, Objeknya[PilihanAcak].transform.rotation);
                    cloneObject.transform.position = new Vector3(PosisiAcak, 6.23f, 0f);
                    waktu = 0f;
                }
            }
        }
        #endregion
        #region Cek Sentuh
        if (ActiveTouch)
        {
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100))
                {
                    rayDetect(hit);
                }
            }else if(Input.touchCount > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if(Physics.Raycast(ray, out hit, 100))
                {
                    rayDetect(hit);
                }
            }
        }
        #endregion
    }

    void rayDetect(RaycastHit Hit)
    {
        if (Hit.transform.tag == "NETRAL")
        {
            gotIt = true;
            Destroy(Hit.transform.gameObject);
            getScoreTextInformasi(true);
        }
        else if (Hit.transform.tag == "RACUN")
        {
            gotIt = false;
            Destroy(Hit.transform.gameObject);
            getScoreTextInformasi(false);
        }
    }
    void getScoreTextInformasi(bool gotIt)
    {
        GameObject clone = Instantiate(getScoreText, getScoreText.transform.position, getScoreText.transform.rotation);
        clone.transform.SetParent(contentScore.transform);
        clone.SetActive(transform);
        clone.GetComponent<TMP_Text>().enabled = true;
        if (gotIt)
        {
            clone.GetComponent<TMP_Text>().color = new Color32(0, 195, 15, 255);
            clone.GetComponent<TMP_Text>().text = "+1";
            score += 1;
        }
        else
        {
            clone.GetComponent<TMP_Text>().color = new Color32(195, 0, 23, 255);
            clone.GetComponent<TMP_Text>().text = "-1";
            if (score > 0)
            {
                score -= 1;
            }
            ActiveTouch = false;
            RacunUI.SetActive(true);
        }
        Destroy(clone, 1f);
    }
}
