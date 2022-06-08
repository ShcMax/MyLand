using UnityEditor;
using UnityEngine;

public class myGUI : MonoBehaviour
{
    [SerializeField] Move _player;
    private string _message;
    private Rect _buttonRect;
    private Rect _boxRect;
    private Rect _menuBoxRect;
    
    public GUISkin test;    
    
    private float _menuBoxWidth = 200f;
    private float _menuBoxHeight = 140f;
    
    private int _healthP;
    public int GUIHealth { get => _healthP; }

    private void Start()
    {
        _healthP = _player.PlayerMaxHealth;
        _player.changeHealth += HealthChange;
    }

    public void DamageGui(int _damage)
    {
        _healthP -= _damage;
    }
    void HealthChange (int health)
    {
        _healthP = health;
    }

#if UNITY_EDITOR
    void OnGUI()
    {  
        var halfWithScreen = Screen.width / 2;
        var halfHeightScreen = Screen.height / 2;
        
        GUI.skin = test;
        _menuBoxRect =
            new Rect(
                halfWithScreen - (_menuBoxWidth / 2),
                halfHeightScreen - (_menuBoxHeight / 2),
                _menuBoxWidth,
                _menuBoxHeight);

        GUI.Box(new Rect(Screen.width - 120, 0, _healthP, 30), _message);
    }
#endif
}
