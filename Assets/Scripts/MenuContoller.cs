using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContoller : MonoBehaviour
{

    public void OnBonusGame()
    {
        SceneManager.LoadScene("BonusGame");
    }

    public void OnBackToMenu()
    {
        SceneManager.LoadScene("StartGame");
    }
    
    public void OnDailyBonus()
    {
        SceneManager.LoadScene("DailyBonus");
    }
    public void OnBonusGame2()
    {
        SceneManager.LoadScene("BonusGame2");
    }
    public void OnCasinoGame()
    {
        SceneManager.LoadScene("CasinoGame");
    }
}
