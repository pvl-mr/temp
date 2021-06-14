﻿using BusinessLogic.BusinessLogics;
using BusinessLogic.Interfaces;
using Implement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace View
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IPlayerStorage, PlayerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGameStorage, GameStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<GameLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<GameLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
