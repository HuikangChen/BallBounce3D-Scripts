using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BB3D.SO
{
    [CreateAssetMenu(menuName = "Variables/StringList")]
    public class StringListVariable : ScriptableObject
    {
        public List<string> list = new List<string>();
    }
}