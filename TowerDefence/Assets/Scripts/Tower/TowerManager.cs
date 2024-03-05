using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    private Coroutine berfReEnableCR;
    private Coroutine billitaryReEnableCR;
    private Coroutine buploReEnableCR;
    
    
    private List<Tower> berfTowers = new();
    private List<Tower> billitaryTowers = new();
    private List<Tower> buploTowers = new();

    public float secondsForEnablingTowers;

    public void AddTower(Tower _tower)
    {
        switch (_tower.damageType)
        {
            case eVulType.Berf:
                berfTowers.Add(_tower);
                foreach (Tower tower in berfTowers)
                {
                    tower.SetShooting(false);
                }
                berfReEnableCR = StartCoroutine(EnableBerfTowers_CR());
            break;
        }
    }

    public IEnumerator EnableBerfTowers_CR()
    {
        yield return new WaitForSeconds(secondsForEnablingTowers);
        foreach (Tower tower in berfTowers)
        {
            tower.SetShooting(true);
        }
    }
}
