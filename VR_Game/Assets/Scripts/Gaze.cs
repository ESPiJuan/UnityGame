using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gaze : MonoBehaviour
{
    public Image imgGaze;
     float totalTime = 1;
    bool gvrStatus;
    float gvrTimer;

    public GameObject win;
    public GameObject lose;
    public GameObject Lvl1;
    public GameObject Lvl2;

    int distanceOfRay;
    private RaycastHit _hit;
    private string ballTag;
    private GameObject ballThrow;
    public GameObject powerSelected;
     string powerTag;
    int points;
    int tirado;
    int wincondition;
    float power;
    private bool grabed;
    private bool throwed;
    private bool loaded2;
    Scene m_Scene;
    string sceneName;

    void Start()
    {
        incrementPoints(0);
        incrementWin(0);
        powerTag = "LVL1";
        power = 100f;
        distanceOfRay = 10000;
        loaded2 = false;
        grabed = false;
        throwed = false;
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
    }


    // Update is called once per frame
    void Update()
    {
        

        if (points >= 100 && !loaded2)
        {
            StartCoroutine(ActivateLvl2());
            loaded2 = true;
        }
        if(sceneName == "02" && loaded2 && points >= 100)
        {
           
            StartCoroutine(ActivateWin());
            

        }
        if (points < 100 && wincondition ==3)
        {
            StartCoroutine(ActivateLose());
        }

        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray,out _hit, distanceOfRay))
        {
            if(imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Ball")&& !grabed)
            {
                throwed = false;
                ballTag = _hit.transform.tag;
                grabed = true;
                _hit.transform.gameObject.GetComponent<grabBall>().grab();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Ball2") && !grabed)
            {
                throwed = false;
                ballTag = _hit.transform.tag;
                grabed = true;
                _hit.transform.gameObject.GetComponent<grabBall>().grab();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Ball3") && !grabed)
            {
                throwed = false;
                ballTag = _hit.transform.tag;
                grabed = true;
                _hit.transform.gameObject.GetComponent<grabBall>().grab();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Teleport"))
            {
                throwed = false;
                _hit.transform.gameObject.GetComponent<Teleport>().teleport();
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Start"))
            {

                StartCoroutine(ActivateLVL1());
               
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("Finish"))
            { 
                Application.Quit();
            }
            if (imgGaze.fillAmount == 1 && (_hit.transform.CompareTag("Boat") || _hit.transform.CompareTag("Boat2")|| _hit.transform.CompareTag("Boat3")) && grabed && !throwed)
            {
                tirado++;
                grabed = false;
                throwed = true;
                ballThrow = GameObject.FindWithTag(ballTag);
                ballThrow.transform.gameObject.GetComponent<grabBall>().throwBall(power);
                
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LVL1"))
            {
                power = 300f;
                GVROff();
                setActiveLvl();
                powerTag = _hit.transform.tag;
                powerSelected = GameObject.FindWithTag(powerTag );
                powerSelected.transform.gameObject.SetActive(false);
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LVL2"))
            {
                power = 900;
                GVROff();

                setActiveLvl();
                
                powerTag = _hit.transform.tag;
                powerSelected = GameObject.FindWithTag(powerTag);
                powerSelected.transform.gameObject.SetActive(false);
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LVL3"))
            {
                power = 1500f;
                GVROff();

                setActiveLvl();

                powerTag = _hit.transform.tag;
                powerSelected = GameObject.FindWithTag(powerTag);
                powerSelected.transform.gameObject.SetActive(false);
            }
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("LVL4"))
            {
                power = 3000f;
                GVROff();

                setActiveLvl();

                powerTag = _hit.transform.tag;
                powerSelected = GameObject.FindWithTag(powerTag);
                powerSelected.transform.gameObject.SetActive(false);
            }

        }
    }
     IEnumerator ActivateLVL1()
    {

        Lvl1.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("01");
    }
    IEnumerator ActivateLvl2()
    {

        Lvl2.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("02");
    }
    IEnumerator ActivateLose()
    {
        lose.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
    IEnumerator ActivateWin()
    {
        win.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
    public void incrementPoints(int puntuacion)
    {
        points += puntuacion;
        Text cameraLabel = GameObject.Find("Load/Puntuation").GetComponent<Text>();
        cameraLabel.text = "Puntuacion: "+points;
    }
    public void incrementWin(int colission)
    {
        if(wincondition < tirado)
        {
            wincondition += colission;
            Debug.Log(wincondition);
        }
        

        
    }
    private void setActiveLvl()
    {
       
        powerSelected.transform.gameObject.SetActive(true);
    }
    
    public void GVROn()
    {
        gvrStatus = true;

    }
    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
