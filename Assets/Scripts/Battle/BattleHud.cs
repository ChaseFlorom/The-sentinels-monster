using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpbar;
    Monster _monster;

    public void SetData(Monster monster)
    {
        _monster = monster;
        nameText.text = monster.Base.Name;
        levelText.text = "Lvl " + monster.Level;
        hpbar.SetHP((float)monster.HP / monster.MaxHP);
    }

    public IEnumerator UpdateHP()
    {
      yield return StartCoroutine(hpbar.SetHPSmooth((float)_monster.HP / _monster.MaxHP));
    }


}
