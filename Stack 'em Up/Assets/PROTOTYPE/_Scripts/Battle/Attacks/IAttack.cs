﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack : IMove{

    string GetName();
    int GetDamage();
}
