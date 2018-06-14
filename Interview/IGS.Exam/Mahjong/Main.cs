// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Interview.IGS.Exam.Mahjong
{
    using System.Diagnostics;
    using System.Linq;
    using Interview.IGS.Exam.Mahjong.Interpreter.Impl;
    using Interview.IGS.Exam.Mahjong.Models.Cards;

    public sealed class Main : EntryPoint
    {
        #region Properties

        public override string Name => "IGS";

        #endregion Properties

        #region Methods

        public override void Run()
        {
            //建立工廠
            var factory = Card.Factory;

            //建立評估器，評估對象: 順子
            var evaluator = new Sequence();

            //生產標籤
            GENERATE:

            //隨機取出 16 張卡(用內建的Linq排序)
            var cards = factory.Cards.Take_16().OrderBy(x => x.Weight);

            //評估器進行評估
            evaluator.Evalute(cards);

            // 如果: 評估器評估後結果吻合 以及 結果的數量大於等於 1
            if (evaluator.IsMatch && evaluator.Matches.Count >= 2)
            {
                // 顯示牌組資料
                Debug.WriteLine("[所有牌組]");
                foreach (var c in cards)
                {
                    Debug.WriteLine(c.DebugString);
                }
                Debug.WriteLine("-------------------------");

                //顯示順子的資料
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
                //初始化牌組(144張)
                factory.Init();

                //撤銷結果以重新評估
                evaluator.Revoke();

                //回到生產標籤
                goto GENERATE;
            }
        }

        #endregion Methods
    }
}