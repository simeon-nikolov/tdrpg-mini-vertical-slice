using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject[] enemies;
    private GameObject[] heroes;
    private GameStates gameState = GameStates.InProgress;
    private Color winColor = new Color(0f, 0.75f, 0f);
    private Color loseColor = new Color(1f, 0.75f, 0f);

    public Canvas endScreen;
    public Text outcomeText;

    public bool IsGameOver { get; private set; }


    void Start()
    {
        this.enemies = GameObject.FindGameObjectsWithTag(UnitTags.Enemy.ToString());
        this.heroes = GameObject.FindGameObjectsWithTag(UnitTags.Hero.ToString());
    }


    void Update()
    {
        if (this.AreAllEnemiesDead())
        {
            this.gameState = GameStates.Won;
            this.GameOver();
            Debug.Log("Victory!");
        }
        else if (this.AreAllHeroesDead())
        {
            this.gameState = GameStates.Lost;
            this.GameOver();
            Debug.Log("You lost!");
        }
    }

    private void GameOver()
    {
        this.IsGameOver = true;
        bool isVictorious = this.gameState == GameStates.Won;
        DelayUtils.Invoke(this, () => this.endScreen.gameObject.SetActive(true), 0.5f);
        this.outcomeText.text = isVictorious ? "Victory!" : "Game Over!";
        this.outcomeText.color = isVictorious ? winColor : loseColor;

    }

    private bool AreAllHeroesDead()
    {
        return this.heroes.All(hero => hero == null);
    }

    private bool AreAllEnemiesDead()
    {
        return this.enemies.All(enemy => enemy == null);
    }
}
