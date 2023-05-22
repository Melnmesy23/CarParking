using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VehicleSelect : MonoBehaviour
{

    // vehicle prefabs array
    public GameObject[] vehicles;

    // SpawnPoint
    public Transform point;

    // Ech vehicle value
    public int[] Values;

    // Lock Icon,Shop window,Buy button
    public GameObject Lock, Shop, Buy;

    // Selected vehicle ID
    public int ID;

    //TotalScore text, vehicle value text
    public Text vehiclePriceText;

    // SetActive(true) loading window before start loading level
    public GameObject Loading;

    // MainLevel name
    public string levelName = "Game";

    T_Money tMoney;

    void Start()
    {


        tMoney = GameObject.FindObjectOfType<T_Money>();


        if (PlayerPrefs.GetInt("FirstRun") != 3)
        {
            // If game s first run, make vehicle opened
            PlayerPrefs.SetInt("Car0", 3);
            PlayerPrefs.SetInt("FirstRun", 3);
        }

        // Read lastest vehicle selected ID before    
        ID = PlayerPrefs.GetInt("CarID");

        // Instantiate last selected vehicle by saved ID
        Instantiate(vehicles[ID], point.position, point.rotation);

        // Update total score text
        tMoney.UpdateDisplay();

        // Update current vehicle value text
        vehiclePriceText.text = Values[ID].ToString() + " $";


        // Update current vehicle is locked or not
        if (PlayerPrefs.GetInt("Car" + ID.ToString()) == 3)
        {
            Lock.SetActive(false);
            Buy.SetActive(false);
        }
        else
        {
            Lock.SetActive(true);
            Buy.SetActive(true);
        }
    }

    // Public function for NextCar select button in menu
    public void NextCar()
    {
        if (ID < vehicles.Length - 1)
            ID++;

        PlayerPrefs.SetInt("CarID", ID);

        Destroy(GameObject.FindGameObjectWithTag("Player"));

        ID = PlayerPrefs.GetInt("CarID");

        // Instantiate last selected car by saved ID
        Instantiate(vehicles[ID], point.position, point.rotation);

        if (PlayerPrefs.GetInt("Car" + ID.ToString()) == 3)
        {
            Lock.SetActive(false);
            Buy.SetActive(false);
        }
        else
        {
            Lock.SetActive(true);
            Buy.SetActive(true);

        }

        vehiclePriceText.text = Values[ID].ToString() + " $";

    }
    // Public function for PrevCar select button in menu
    public void PrevCar()
    {

        if (ID > 0)
            ID--;

        PlayerPrefs.SetInt("CarID", ID);

        Destroy(GameObject.FindGameObjectWithTag("Player"));


        ID = PlayerPrefs.GetInt("CarID");

        // Instantiate last selected car by saved ID
        Instantiate(vehicles[ID], point.position, point.rotation);

        if (PlayerPrefs.GetInt("Car" + ID.ToString()) == 3)
        {

            Lock.SetActive(false);
            Buy.SetActive(false);
        }
        else
        {
            Lock.SetActive(true);
            Buy.SetActive(true);
        }

        vehiclePriceText.text = Values[ID].ToString() + " $";

    }
    // Select current car
    public void SelectCar()
    {
        if (PlayerPrefs.GetInt("Car" + ID.ToString()) == 3)
        {

            // Set current selected vehicle ID for instantiate in main level    
            PlayerPrefs.SetInt("CarID", ID);

            // Activate loading screen
            Loading.SetActive(true);

            SceneManager.LoadSceneAsync(levelName);
        }
    }

    // Buy current selected vehicle
    public void BuyCar()
    {

        // Check player have enough money
        if (Values[ID] <= tMoney.GetMoney())
        {

            PlayerPrefs.SetInt("Car" + ID.ToString(), 3);

            // Reduce item current vehicle value from total money
            tMoney.SetMoney(-Values[ID]);

            Lock.SetActive(false);


            Buy.SetActive(false);

            tMoney.UpdateDisplay();

        }
        else// If player did't have enough money, Show shop offer window   
            Shop.SetActive(true);

    }

    public void buyFromShop()
    {

        Loading.SetActive(true);
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Shop");

    }

    public GameObject mainMenu, customizeMenu, selectButtons;

    public void OpenCustomizeMenu()
    {
        if (PlayerPrefs.GetInt("Car" + ID.ToString()) == 3)
        {

            mainMenu.SetActive(false);
            customizeMenu.SetActive(true);
            selectButtons.SetActive(false);
        }

    }

    public void GoToCustomize(GameObject target)
    {

        if (PlayerPrefs.GetInt("Car" + ID.ToString()) == 3)
            target.SetActive(false);
    }
}
