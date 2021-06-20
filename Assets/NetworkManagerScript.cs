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
public class NetworkManagerScript : MonoBehaviour
{

[Serializable]
public class InitGame{
    public string userId; 

}

[Serializable]
public class Level{
    public string level; 
}

[Serializable]
public class PlayerUpdate{
    public string userId; 
    public int money; 
}

[Serializable]
public class Game {
    
    public string id;
    public string date;
    public string idPlayer;
    public int levelsPassed = 0;
    public float duration = 0f ;

}

public class PotionResponse{
    public int amount; 
    public string idProduct; 
}
private string baseURL = "http://localhost:8080/myapp/game/";  
private HttpClient client = new HttpClient(); 

private Game game;

private Potion health,speed,resistance; 
private PlayerScript player; 
public GameObject resistanceImg; 
public GameObject healthImg; 
public GameObject speedImg; 

public List<Level> levels; 

public float elapsed_time; 
//la referencia de esta variable ha de venir de la app de android 
private string username = "lau"; 
    
    public Game GetGame(){
        return this.game; 
    }

     async void Awake() {
        this.levels = new List<Level>(); 
        await PostData_Async();
        await GetMapsAsync(); 
       
        GameManager.instance.lpaths = paths(); 

        this.player = GameObject.Find("Player(Clone)").GetComponent<PlayerScript>(); 
        await GetPotions_Async(); 

        player.setPotion(this.speed); 
        player.setPotion(this.health); 
        player.setPotion(this.resistance); 

        this.resistanceImg.GetComponent<Click>().setPotionSprite(); 
        this.healthImg.GetComponent<Click>().setPotionSprite(); 
        this.speedImg.GetComponent<Click>().setPotionSprite(); 

    }

    public List<String> paths(){
        List<String> p = new List<string>(); 
        foreach(Level l in this.levels){
            p.Add(l.level); 

        }
        return p; 
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
        
        var response = await client.PostAsync(baseURL+"newgame",content); 
        if(response.IsSuccessStatusCode){
            var result = await response.Content.ReadAsStringAsync(); 
            this.game = JsonUtility.FromJson<Game>(result); 
            
        }
      
    }


    public async Task PostGame_Async(){
        var data = JsonUtility.ToJson(this.game); 
        HttpContent content = new StringContent(data,System.Text.Encoding.UTF8,"application/json");
        var response = await client.PostAsync(baseURL+"endgame",content);
        if(response.IsSuccessStatusCode){
            var result = await response.Content.ReadAsStringAsync(); 
            Debug.Log(result.ToString());
            
        }

    }


    public async Task PostUser_Async(){
        PlayerUpdate playerUpdate = new PlayerUpdate(){
            userId = this.username,
            money = GameManager.instance.playerPoints

        }; 
        var data = JsonUtility.ToJson(playerUpdate); 
        HttpContent content = new StringContent(data,System.Text.Encoding.UTF8,"application/json");
        var response = await client.PostAsync(baseURL+"updateplayer",content);
        if(response.IsSuccessStatusCode){
            var result = await response.Content.ReadAsStringAsync(); 
            Debug.Log(result.ToString());
            
        }
    }


        public async Task GetMapsAsync(){
        string url = "http://localhost:8080/myapp/game/levelprefabs"; 
        var response = await client.GetStringAsync(url); 
        levels = JsonConvert.DeserializeObject<List<Level>>(response); 
     
    }


    private void Update() {
        this.elapsed_time+=Time.time; 
    }









  
  






}
