using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace Menu
{
    public class SkillSelection : MenuPage
    {
        public SkillSelection(IRectangle mouse, ITextFactory textFactory, IGameStartInitializer gameStartInitializer, Action jumpBackToFrontPage, Action jumpBackToParentPage)
            : base(mouse, jumpBackToParentPage)
        {
            MenuElements.Add(new MenuElement(textFactory.CreateText(0, 0.4, "EASY")), () => 
            {
                gameStartInitializer.SetSkillLevel(SkillLevel.Easy);
                gameStartInitializer.Start();
                jumpBackToFrontPage();
            });
        }
    }
}
