﻿// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview.Exam.Mahjong.Internal
{
    using System.Diagnostics;
    using Models.Cards;

    internal static class Helper
    {
        #region Methods

        public static void Debugger(this Card c, int id)
        {
            Debug.WriteLine($"[{id.ToString().PadLeft(2)}]: {c}");
        }

        #endregion Methods
    }
}