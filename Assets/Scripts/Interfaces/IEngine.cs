using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NiFTY
{
    public interface IEngine
    {
        void InitEngine();

        void UpdateEngine(Rigidbody rb, InputReader input);
    }
}