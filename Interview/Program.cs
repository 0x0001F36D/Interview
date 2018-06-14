// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Interview.IGS.Exam.Mahjong.Interpreter.Impl;
    using Interview.IGS.Exam.Mahjong.Models.Cards;

    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            var factory = Card.Factory;
            var evaluator = new Sequence();

            GENERATE:

            var cards = factory.Cards.Take_16().OrderBy(x => x.Weight);
            evaluator.Evalute(cards);

            if (evaluator.IsMatch && evaluator.Matches.Count >= 2)
            {
                Debug.WriteLine("[所有牌組]");
                foreach (var c in cards)
                {
                    Debug.WriteLine(c.DebugString);
                }
                Debug.WriteLine("-------------------------");

                Debug.WriteLine($"[{evaluator.MatchName}]");
                foreach (var match in evaluator.Matches)
                {
                    foreach (var c in match)
                        Debug.WriteLine(c.DebugString);
                    Debug.WriteLine("----------------------------");
                }
            }
            else
            {
                factory.Init();
                evaluator.Revoke();
                goto GENERATE;
            }

            Console.ReadKey();
            return;
        }

        #endregion Methods
    }
}