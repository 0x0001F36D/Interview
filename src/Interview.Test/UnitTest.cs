
namespace Interview.Test
{
    using System;

    using NUnit.Framework;
    using Interview.Exam.Mahjong;
    using Interview.Exam.Mahjong.Models.Cards;
    using Interview.Exam.Mahjong.Interpreter.Impl;
    using System.Linq;
    using System.Diagnostics;

    [TestFixture(
        Author = "Viyrex(aka Yuyu)", 
        Description = "隨機將16張麻將棋牌發送至玩家手上，且必須有兩組順子"
    )]
    public class UnitTest
    {

        [Test]
        public void TestEvaluator()
        {
            // 建立卡牌
            var card_1 = new NCard(0, CardType.筒, 1); //一筒
            var card_2 = new NCard(0, CardType.筒, 2); //二筒
            var card_3 = new NCard(0, CardType.筒, 3); //三筒
            var card_4 = new NCard(0, CardType.筒, 4); //四筒
            var card_x1 = new SCard(0, 2);             //南風
            var card_x2 = new SCard(0, 3);             //西風
            var card_x3 = new SCard(0, 4);             //北風

            // 建立經排序的卡牌序列
            var cards = new Card[]
            {
               card_3, card_4, card_1, card_x1, card_2, card_x3, card_x2
            }
            .OrderBy(x=>x.Weight);

            // 建立評估器
            var evaluator = new Sequence();

            // 評估卡牌序列
            evaluator.Evalute(cards);

            // 評估是否包含順子
            Assert.IsTrue(evaluator.IsMatch);

            // 評估順子的數量是否剛好為 2
            Assert.AreEqual(evaluator.Matches.Count, 2);
            
            #region 驗證卡牌內容是否一致

            // 轉換成具有 indexer 的物件
            var list = cards.ToArray();

            // 一二三 筒 + 二三四 筒
            for (int i = 0; i < 2; i++)
            {
                for (uint j = 0; j <3;  j++)
                {
                    Assert.IsInstanceOf<NCard>(evaluator.Matches[i][j]);
                    Assert.AreEqual(list[i + j], evaluator.Matches[i][j]);                    
                }
            }

            #endregion
        }

        [Test]
        public void TestFactory()
        {
            // 建立工廠
            var factory = Card.Factory;
            factory.Init();
            
            Assert.AreEqual(factory.Cards.Count, 144);
        }

        [Test]
        public void TestCore()
        {

            //建立工廠 (Design Pattern: SigletonFactory)
            var factory = Card.Factory;
            factory.Init();

            //建立評估器，評估對象: 順子 (Design Pattern: Interpreter)
            var evaluator = new Sequence();

            //生產標籤
            GENERATE:

            //從工廠內取出 16 張隨機的卡牌並用內建的Linq排序(Quick Sort)
            var cards = factory.Cards.Take_16().OrderBy(x => x.Weight);

            //使用評估器進行評估
            evaluator.Evalute(cards);

            // 如果: 評估器評估後結果吻合 以及 結果的數量大於等於 2
            var result = evaluator.IsMatch && evaluator.Matches.Count >= 2;
            
            if(!result)
            {
                //初始化牌組(144張)
                factory.Init();

                //撤銷結果以重新評估
                evaluator.Revoke();

                //回到生產標籤
                goto GENERATE;
            }

            Assert.IsTrue(result);

        }
    }
    
}
