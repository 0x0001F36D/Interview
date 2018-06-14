// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview
{
    public abstract class EntryPoint
    {
        #region Constructors

        public EntryPoint()
        {
        }

        #endregion Constructors

        #region Properties

        public abstract string Name { get; }

        #endregion Properties

        #region Methods

        public abstract void Run();

        #endregion Methods
    }
}