﻿using System;

namespace BB3D.SO
{
    [Serializable]
    public class BoolReference
    {
        public bool UseConstant = true;
        public bool ConstantValue;
        public BoolVariable Variable;

        public BoolReference()
        { }

        public BoolReference(bool value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public bool Value
        {
            get { return UseConstant ? ConstantValue : Variable.GetValue(); }
        }

        public static implicit operator bool(BoolReference reference)
        {
            return reference.Value;
        }
    }
}