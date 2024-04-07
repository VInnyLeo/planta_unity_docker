using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Linq.Expressions;

public class Database : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField usernameInputField;
    [SerializeField]
    public TMP_InputField passwordInputField;
    [SerializeField]
    public TextMeshProUGUI errorText;

    MongoClient client = new MongoClient("mongodb://localhost:27023/");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    

    // Start is called before the first frame update
    void Start()
    {
        
        database = client.GetDatabase("Planta");
        collection = database.GetCollection<BsonDocument>("Usuario");

    }

    void Update()
    {
        
    }

    // LOGIN is called once per frame
    public void login()
    {
        
        var filter = Builders<BsonDocument>.Filter.Eq("user", "Vinny");
        var filter2 = Builders<BsonDocument>.Filter.Eq("clave", "12345");

        var condicion = Builders<BsonDocument>.Projection.Include("user").Exclude("_id");
        var condicion2 = Builders<BsonDocument>.Projection.Include("clave").Exclude("_id");

        var doc = collection.Find(filter).Project(condicion).ToList();//.FirstOrDefault();
        var doc2 = collection.Find(filter2).Project(condicion2).ToList();//.FirstOrDefault();

        var concatenar = doc.Concat(doc2).ToList();
            
    
        string username = usernameInputField.text;
        string password = passwordInputField.text;
     

        string loginCheckMessage = CheckLogin(username, password);
        
        foreach (var docu in concatenar)
        {
            //Debug.Log("Conectado");
            Debug.Log("user mongo"+docu.ToString());
            JObject jOb = JObject.Parse(docu.ToString());
            string userFin = (string)jOb["user"];
            string claveFin = (string)jOb["clave"];
            //Debug.Log("usuario final " + userFin.ToString());
            try
            {
                if ((username.Equals(userFin)))// && (password.Equals(claveFin)))
                {
                    SceneManager.LoadScene(1); //0 la principal o puedo pasar el nombre "Planta"
                }
                else
                {
                    //Debug.LogError("Error " + loginCheckMessage);
                    errorText.text = "Error " + loginCheckMessage;
                }
            }
            catch(Exception ex)
            {
                Debug.LogError("Error durante el proceso de autenticación: " + ex.Message);
                errorText.text = "Error durante el proceso de autenticación.";
            }

        }
        


    }

    private string CheckLogin(string username, string password)
    {
        string returnString = "";

        if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
        {
            returnString = "Usuario y contraseña vacias";
        }
        else if (string.IsNullOrEmpty(username))
        {
            returnString = "Error ingreso";
        }
        else if (string.IsNullOrEmpty(password))
        {
            returnString = "Error ingreso";
        }
        else
        {
            returnString = "";
        }
        Debug.Log("Return " + returnString);
        return returnString;
    }

    public void RemoveErrorText()
    {
        errorText.text = "";
    }
}
