//--------------------------------------------------------------
//
//                    Car Parking Template 3.0
//        
//           Contact me : aliyeredon@gmail.com
//
//--------------------------------------------------------------

// This script used for game settings menu

using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Settings : MonoBehaviour
{

    public Toggle AmbientSound, Shaft, colorGrading, bloom, ShowFPS, vSync;

    public Dropdown resolutionDrop, qualityDrop, antiAliasing, textureSampler;

    public int[] resolutionListWidth;
    public int[] resolutionListHeight;

    void Start()
    {

        // Read starting setting values
        if (PlayerPrefs.GetInt("AmbientSound") == 3)
            AmbientSound.isOn = true;
        else
            AmbientSound.isOn = false;

        if (PlayerPrefs.GetInt("Shaft") == 3)
            Shaft.isOn = true;
        else
            Shaft.isOn = false;

        if (PlayerPrefs.GetInt("colorGrading") == 3)
            colorGrading.isOn = true;
        else
            colorGrading.isOn = false;

        if (PlayerPrefs.GetInt("ShowFPS") == 3)
            ShowFPS.isOn = true;
        else
            ShowFPS.isOn = false;

        if (PlayerPrefs.GetInt("Bloom") == 3)
            bloom.isOn = true;
        else
            bloom.isOn = false;

        if (PlayerPrefs.GetInt("vSync") == 3)
            vSync.isOn = true;
        else
            vSync.isOn = false;

        qualityDrop.value = PlayerPrefs.GetInt("Quality");

        resolutionDrop.value = PlayerPrefs.GetInt("Resolution");

        antiAliasing.value = PlayerPrefs.GetInt("AntiAliasing");

        textureSampler.value = PlayerPrefs.GetInt("TextureSampler");

        UpdateSettings("Resolution");
        UpdateSettings("AntiAliasing");
        UpdateSettings("TextureSampler");
        UpdateSettings("ColorGrading");
        UpdateSettings("ShowFPS");
        UpdateSettings("Bloom");
        UpdateSettings("vSync");
        UpdateSettings("Shaft");

    }

    // Public function for ambient sound toggle
    public void Set_AmbientSound()
    {
        StartCoroutine(AmbiantSound_Save());
    }

    public void Set_Shaft()
    {
        StartCoroutine(Shaft_Save());
    }

    public void Set_colorGrading()
    {
        StartCoroutine(colorGrading_Save());
    }

    public void Set_ShowFPS()
    {
        StartCoroutine(ShowFPS_Save());
    }

    public void Set_bloom()
    {
        StartCoroutine(Bloom_Save());
    }

    public void Set_vSync()
    {
        StartCoroutine(vSync_Save());
    }

    public void SetQualityLevel()
    {
        PlayerPrefs.SetInt("Quality", qualityDrop.value);
        QualitySettings.SetQualityLevel(qualityDrop.value, false);
    }

    public void SetResolution()
    {
        PlayerPrefs.SetInt("Resolution", resolutionDrop.value);
        UpdateSettings("Resolution");
    }

    public void SetAntiAliasing()
    {
        PlayerPrefs.SetInt("AntiAliasing", antiAliasing.value);
        UpdateSettings("AntiAliasing");

    }

    public void SetTextureSampler()
    {
        PlayerPrefs.SetInt("TextureSampler", textureSampler.value);
        UpdateSettings("TextureSampler");
    }

    IEnumerator AmbiantSound_Save()
    {
        yield return new WaitForEndOfFrame();
        if (AmbientSound.isOn)
        {
            PlayerPrefs.SetInt("AmbientSound", 3);  //3 = true;
            GameObject.FindObjectOfType<SettingsLoader>().AmbiantSound.Play();
        }
        else
        {
            PlayerPrefs.SetInt("AmbientSound", 0);//0 = false;

            GameObject.FindObjectOfType<SettingsLoader>().AmbiantSound.Stop();
        }
    }

    IEnumerator colorGrading_Save()
    {
        yield return new WaitForEndOfFrame();
        if (colorGrading.isOn)
            PlayerPrefs.SetInt("colorGrading", 3);  //3 = true;
        else
            PlayerPrefs.SetInt("colorGrading", 0);//0 = false;

        UpdateSettings("ColorGrading");
    }

    IEnumerator ShowFPS_Save()
    {
        yield return new WaitForEndOfFrame();
        if (ShowFPS.isOn)
            PlayerPrefs.SetInt("ShowFPS", 3);  //3 = true;
        else
            PlayerPrefs.SetInt("ShowFPS", 0);//0 = false;

        UpdateSettings("ShowFPS");
    }

    IEnumerator Bloom_Save()
    {
        yield return new WaitForEndOfFrame();
        if (bloom.isOn)
            PlayerPrefs.SetInt("Bloom", 3);  //3 = true;
        else
            PlayerPrefs.SetInt("Bloom", 0);//0 = false;

        UpdateSettings("Bloom");
    }

    IEnumerator vSync_Save()
    {
        yield return new WaitForEndOfFrame();
        if (vSync.isOn)
            PlayerPrefs.SetInt("vSync", 3);  //3 = true;
        else
            PlayerPrefs.SetInt("vSync", 0);//0 = false;

        UpdateSettings("vSync");

    }

    IEnumerator Shaft_Save()
    {
        yield return new WaitForEndOfFrame();
        if (Shaft.isOn)
            PlayerPrefs.SetInt("Shaft", 3);  //3 = true;
        else
            PlayerPrefs.SetInt("Shaft", 0);//0 = false;

        UpdateSettings("Shaft");
    }


    void UpdateSettings(string name)
    {
        if (GameObject.FindObjectOfType<SettingsLoader>()
            .mainCamera.GetComponent<LightingBox.ImageEffects.SunShafts>())
        {
            if (name == "Shaft")
            {
                if (PlayerPrefs.GetInt("Shaft") != 3)
                    GameObject.FindObjectOfType<SettingsLoader>()
                        .mainCamera.GetComponent<LightingBox.ImageEffects.SunShafts>().enabled = false;
                else
                    GameObject.FindObjectOfType<SettingsLoader>()
                        .mainCamera.GetComponent<LightingBox.ImageEffects.SunShafts>().enabled = true;
            }
        }

        if (GameObject.FindObjectOfType<SettingsLoader>()
            .mainCamera.GetComponent<MobileColorGrading>())
        {
            if (name == "ColorGrading")
            {
                if (PlayerPrefs.GetInt("colorGrading") != 3)
                    GameObject.FindObjectOfType<SettingsLoader>()
                .mainCamera.GetComponent<MobileColorGrading>().enabled = false;
                else
                    GameObject.FindObjectOfType<SettingsLoader>()
                .mainCamera.GetComponent<MobileColorGrading>().enabled = true;
            }
        }

        if (name == "ShowFPS")
        {
            if (PlayerPrefs.GetInt("ShowFPS") != 3)
            {
                if (GameObject.FindObjectOfType<SettingsLoader>()
                    .mainCamera.gameObject.AddComponent<FPS>())
                {
                    Destroy(GameObject.FindObjectOfType<SettingsLoader>()
                .mainCamera.GetComponent<FPS>());
                }
            }
            else
                GameObject.FindObjectOfType<SettingsLoader>()
                .mainCamera.gameObject.AddComponent<FPS>();
        }

        if (GameObject.FindObjectOfType<SettingsLoader>()
            .mainCamera.GetComponent<LightingBox.ImageEffects.BloomOptimized>())
        {
            if (name == "Bloom")
            {
                if (PlayerPrefs.GetInt("Bloom") != 3)
                    GameObject.FindObjectOfType<SettingsLoader>()
                        .mainCamera.GetComponent<LightingBox.ImageEffects.BloomOptimized>().enabled = false;
                else
                    GameObject.FindObjectOfType<SettingsLoader>()
                        .mainCamera.GetComponent<LightingBox.ImageEffects.BloomOptimized>().enabled = true;
            }
        }

        if (name == "Resolution")
        {
            Screen.SetResolution(resolutionListWidth[PlayerPrefs.GetInt("Resolution")], resolutionListHeight[PlayerPrefs.GetInt("Resolution")], true);

            Camera[] c = GameObject.FindObjectsOfType<Camera>();

            for (int a = 0; a < c.Length; a++)
                c[a].aspect = 16f / 9f;

            if (GameObject.FindObjectOfType<SteeringWheel>())
                GameObject.FindObjectOfType<SteeringWheel>().onStart();

        }

        if (name == "AntiAliasing")
        {
            if (PlayerPrefs.GetInt("AntiAliasing") == 0)
                QualitySettings.antiAliasing = 0;
            if (PlayerPrefs.GetInt("AntiAliasing") == 1)
                QualitySettings.antiAliasing = 2;
            if (PlayerPrefs.GetInt("AntiAliasing") == 2)
                QualitySettings.antiAliasing = 4;
            if (PlayerPrefs.GetInt("AntiAliasing") == 3)
                QualitySettings.antiAliasing = 8;
        }

        if (name == "TextureSampler")
            QualitySettings.masterTextureLimit = PlayerPrefs.GetInt("TextureSampler");

        if (name == "vSync")
        {
            if (PlayerPrefs.GetInt("vSync") == 0)
                QualitySettings.vSyncCount = 0;
            if (PlayerPrefs.GetInt("vSync") == 3)
                QualitySettings.vSyncCount = 1;
        }
    }

}
