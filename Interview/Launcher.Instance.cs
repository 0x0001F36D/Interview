// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    internal partial class Launcher
    {
        #region Constructors

        private Launcher()
        {
            var entries = from type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                          where type.IsSubclassOf(typeof(EntryPoint))
                          let e = type.GetConstructor(Type.EmptyTypes)
                          where e is ConstructorInfo
                          select e.Invoke(null) as EntryPoint;

            this._entryPoints = new List<EntryPoint>(entries);
        }

        #endregion Constructors

        #region Fields

        private static volatile Launcher s_instance;

        private static object s_locker = new object();

        private readonly List<EntryPoint> _entryPoints;

        #endregion Fields

        #region Properties

        internal static Launcher Instance
        {
            get
            {
                if (s_instance == null)
                    lock (s_locker)
                        if (s_instance == null)
                            s_instance = new Launcher();
                return s_instance;
            }
        }

        #endregion Properties

        #region Methods

        internal void RunAll()
        {
            foreach (var ep in this._entryPoints)
            {
                Debug.WriteLine($"#[Start '{ep.Name}' block]");
                ep.Run();
                Debug.WriteLine($"#[End of '{ep.Name}' block]");
            }
        }

        #endregion Methods
    }
}