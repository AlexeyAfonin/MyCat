using MyCat.Configs;
using MyCat.Core.Util;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyCat.Controllers
{
    public class CatActionsController : MonobehSingleton<CatActionsController>
    {
        [SerializeField] private CatActionsConfig config;

        public CatActionsConfig Config => config;
    }
}