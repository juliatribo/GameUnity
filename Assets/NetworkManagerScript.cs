using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http; 
using System.Net; 
using System.Text; 
using System.Threading.Tasks; 
using System; 
using Newtonsoft.Json;
using UnityEngine.UI; 
public class NetworkManager : MonoBehaviour
{

[Serializable]
public class InitGame{
    public string userId; 

}
[Serializable]
public class Game {
    
    public string id;
    public string date;
    public string idPlayer;
    public int levelsPassed;
    public float duration;

}

public class PotionResponse{
    public int amount; 
    public string idProduct; 
}
private string baseURL = "http://localhost:8080/myapp/game/newgame";  
private HttpClient client = new HttpClient(); 

private Game game;

private Potion health,speed,resistance; 
private PlayerScript player; 
public GameObject resistanceImg; 
public GameObject healthImg; 
public GameObject speedImg; 
//la referencia de esta variable ha de venir de la app de android 
private string username = "lau"; 
    
    public Game GetGame(){
        return this.game; 
    }

     async void Awake() {
        await PostData_Async();

        this.player = GameObject.Find("Player(Clone)").GetComponent<PlayerScript>(); 
        await GetPotions_Async(); 

        player.setPotion(this.speed); 
        player.setPotion(this.health); 
        player.setPotion(this.resistance); 

        this.resistanceImg.GetComponent<Click>().setPotionSprite(); 
        this.healthImg.GetComponent<Click>().setPotionSprite(); 
        this.speedImg.GetComponent<Click>().setPotionSprite(); 

    }


    private async Task GetPotions_Async (){
        string url = "http://localhost:8080/myapp/shop/productsUser/" + this.username; 
        var response = await client.GetStringAsync(url); 
        List<PotionResponse> potions = JsonConvert.DeserializeObject<List<PotionResponse>>(response); 
        foreach(PotionResponse p in potions){
            switch(p.idProduct){
                case "velocidad": 
                    this.speed = new Potion(Potion.potionType.SPEED, p.amount); 
                break; 
                case "vida": 
                    this.health = new Potion(Potion.potionType.HEALTH, p.amount); 
                break; 
                case "resistencia": 
                    this.resistance = new Potion(Potion.potionType.RESISTANCE, p.amount); 
                break; 
            }
        }
    }

    
    private async Task PostData_Async(){
        InitGame init = new InitGame(){
            userId = "lau"
        }; 

        var data = JsonUtility.ToJson(init); 
        HttpContent content = new StringContent(data,System.Text.Encoding.UTF8,"application/json");
        
        var response = await client.PostAsync(baseURL,content); 
        if(response.IsSuccessStatusCode){
            var result = await response.Content.ReadAsStringAsync(); 
            this.game = JsonUtility.FromJson<Game>(result); 
            
        }
      
    }


    private void Update() {
        this.game.duration += Time.time; 
    }









  
  






}
