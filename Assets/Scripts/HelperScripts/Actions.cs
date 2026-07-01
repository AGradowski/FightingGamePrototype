using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class Actions
{
    public static Action<Player> HealthChanged;
    public static Action<Player> PlayerDied;
    public static Action<Player> PlayerRecoveredAfterHits;
    public static Action<Player> ComboChanged;
    public static Action RoundStart;
}