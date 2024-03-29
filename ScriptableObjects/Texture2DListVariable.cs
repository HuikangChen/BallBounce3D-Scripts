﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BB3D.SO
{
    [CreateAssetMenu(menuName = "Variables/Texture2DList")]
    public class Texture2DListVariable : ScriptableObject
    {
        public List<Texture2D> list = new List<Texture2D>();
    }
}