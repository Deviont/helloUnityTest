using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour
{
    public GameObject myPrefab;
    public string _WebsiteURL = "http://dbro514denz.azurewebsites.net/tables/TreeSurvey?zumo-api-version=2.0.0";
    public GameObject newCube;

    void Start()
    {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        TreeSurvey[] treeSurveys = JsonReader.Deserialize<TreeSurvey[]>(jsonResponse);

        //----------------------
        //YOU WILL NEED TO DECLARE SOME VARIABLES HERE SIMILAR TO THE CREATIVE CODING TUTORIAL

        int totalCubes = treeSurveys.Length;
       // float totalDistance = 3.0f;
       // int i = 0;
        //----------------------
        //We can now loop through the array of objects and access each object individually
        foreach (TreeSurvey treesurvey in treeSurveys)
        {

            //Example of how to use the object
            Debug.Log("This is in: " + treesurvey.Location);

            /* float perc = i / (float)totalCubes;
             i++;

             float factor = 2+(perc * totalDistance);
             float x = 0.0f;
             float z = 0.0f;



             //---------------------- */
            if (treesurvey.EcologicalValue == "Very High")
            {

                newCube = (GameObject)Instantiate(myPrefab, new Vector3(float.Parse(treesurvey.X), float.Parse(treesurvey.Y), float.Parse(treesurvey.Z)), Quaternion.identity);
                newCube.GetComponent<myCubeScript>().setSize((0.25f));
                newCube.name = "Very High Ecological Value";
                //   newCube.GetComponent<myCubeScript>().rotateSpeed = 0.8f;
                newCube.GetComponentInChildren<TextMesh>().text = treesurvey.Location;

            }
            if (treesurvey.EcologicalValue == "High")
            {

                 newCube = (GameObject)Instantiate(myPrefab, new Vector3(float.Parse(treesurvey.X), float.Parse(treesurvey.Y), float.Parse(treesurvey.Z)), Quaternion.identity);
                 newCube.GetComponent<myCubeScript>().setSize((0.2f));
                newCube.name = "High Ecological Value";
              //   newCube.GetComponent<myCubeScript>().rotateSpeed = 0.8f;
                newCube.GetComponentInChildren<TextMesh>().text = treesurvey.Location;

             }
            if (treesurvey.EcologicalValue == "Medium")
            {

                 newCube = (GameObject)Instantiate(myPrefab, new Vector3(float.Parse(treesurvey.X), float.Parse(treesurvey.Y), float.Parse(treesurvey.Z)), Quaternion.identity);
                 newCube.GetComponent<myCubeScript>().setSize((0.15f));
                newCube.name = "Medium Ecological Value";
                //   newCube.GetComponent<myCubeScript>().rotateSpeed = -0.7f;
                 newCube.GetComponentInChildren<TextMesh>().text = treesurvey.Location;

            }
            if (treesurvey.EcologicalValue == "Low")
            {

                 newCube = (GameObject)Instantiate(myPrefab, new Vector3(float.Parse(treesurvey.X), float.Parse(treesurvey.Y), float.Parse(treesurvey.Z)), Quaternion.identity);
                 newCube.GetComponent<myCubeScript>().setSize((0.1f));
                newCube.name = "Low Ecological Value";
                // newCube.GetComponent<myCubeScript>().rotateSpeed = -0.6f;
                 newCube.GetComponentInChildren<TextMesh>().text = treesurvey.Location;

            }
          

        }

    }


    // Update is called once per frame
    void Update()
    {

    }

}









































/*  if (location3 == cenotaph.locationD)
            {

                newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, 2.0f, z + factor), Quaternion.identity);
                newCube.GetComponent<myCubeScript>().setSize((0.3f));
                newCube.GetComponent<myCubeScript>().rotateSpeed = 0.5f;
                newCube.GetComponentInChildren<TextMesh>().text = cenotaph.dateofdeath;

            } */

/* if (location == cenotaph.locationA)
 {
     if (location == cenotaph.locationA) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, 8.0f, z + factor), Quaternion.identity); }
     else if (location == cenotaph.locationB) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x + factor, 8.0f, z), Quaternion.identity); }
     else if (location == cenotaph.locationC) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, 8.0f, z - factor), Quaternion.identity); }
     else if (location == cenotaph.locationD) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x - factor, 8.0f, z), Quaternion.identity); }
     else { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x + factor, 8.0f, z + factor), Quaternion.identity); }
     newCube.GetComponent<myCubeScript>().setSize((1.0f));
     newCube.GetComponent<myCubeScript>().rotateSpeed = 0.8f;
     newCube.GetComponentInChildren<TextMesh>().text = cenotaph.dateofdeath;
 }

   if (valueCat == "Medium")
   {
       if (location == cenotaph.locationA) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, 5.0f, z + factor), Quaternion.identity); }
       else if (location == cenotaph.locationB) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x + factor, 5.0f, z), Quaternion.identity); }
       else if (location == cenotaph.locationC) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, 5.0f, z - factor), Quaternion.identity); }
       else if (location == cenotaph.locationD) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x - factor, 5.0f, z), Quaternion.identity); }
       else { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x + factor, 5.0f, z + factor), Quaternion.identity); }
       newCube.GetComponent<myCubeScript>().setSize((0.65f));
       newCube.GetComponent<myCubeScript>().rotateSpeed = 0.8f;
       newCube.GetComponentInChildren<TextMesh>().text = cenotaph.dateofdeath;
   }
   if (valueCat == "Low")
   {
       if (ExportYear == 2014) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, 2.0f, z + factor), Quaternion.identity); }
       else if (ExportYear == 2013) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x + factor, 2.0f, z), Quaternion.identity); }
       else if (ExportYear == 2012) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, 2.0f, z - factor), Quaternion.identity); }
       else if (ExportYear == 2011) { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x - factor, 2.0f, z), Quaternion.identity); }
       else { newCube = (GameObject)Instantiate(myPrefab, new Vector3(x + factor, 2.0f, z + factor), Quaternion.identity); }
       newCube.GetComponent<myCubeScript>().setSize((0.4f));
       newCube.GetComponent<myCubeScript>().rotateSpeed = 0.8f;
       newCube.GetComponentInChildren<TextMesh>().text = ("" + (ExportYear));
   }
   */


