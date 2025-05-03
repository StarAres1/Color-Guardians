using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text comboText;
    public Text lifeText;

    void Start()
    {
        // Сообщаем GameManager, где брать UI-элементы
        GameManager.getInstance().scoreText = scoreText;
        GameManager.getInstance().comboText = comboText;
        GameManager.getInstance().lifeText = lifeText;
    }
}
