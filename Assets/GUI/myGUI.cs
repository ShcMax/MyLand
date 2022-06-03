using UnityEditor;
using UnityEngine;

public class myGUI : EditorWindow
{    
    private string _message;
    private Rect _buttonRect;
    private Rect _boxRect;
    private Rect _menuBoxRect;
    
    public GUISkin test;    
    
    private float _menuBoxWidth = 200f;
    private float _menuBoxHeight = 140f;

    private int _healthP = 100;

    public int GUIHealth { get => _healthP; }


    [MenuItem("Инструменты/Окна/HealthBar")]    
    public static void ShowMyWindow()
    {       
        GetWindow(typeof(myGUI), false, "HealthBar");
    }
    
    public void DamageGui(int _damage)
    {
        _healthP -= _damage;
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
