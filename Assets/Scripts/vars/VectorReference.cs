using UnityEngine;
using System;
using System.Linq;
using UnityEditor;


namespace Navecitas.Variables{
    [Serializable]
    public class VectorReference
    {
        public bool UseConstant;
        public Vector3 ConstantValue;
        public VectorVariable Variable;
        public Vector3 Value{
            get { return UseConstant ? ConstantValue : Variable.Value; }
            set { 
                if(UseConstant) ConstantValue = value;
                    else Variable.Value = value;
            }
        }
    }
}
