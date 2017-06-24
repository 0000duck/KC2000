using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkContracts;

namespace Menu
{
    public class EpisodeSelection : MenuPage
    {
        public EpisodeSelection(IRectangle mouse, ITextFactory textFactory, IGameStartInitializer gameStartInitializer, Action jumpBackToParentPage)
            : base(mouse, jumpBackToParentPage)
        {
            SubPages.Add(new SkillSelection(mouse, textFactory, gameStartInitializer, () => { SubPageIsFinished(); jumpBackToParentPage(); }, SubPageIsFinished));

            MenuElements.Add(new MenuElement(textFactory.CreateText(0, 0.7, "AMERICA")), () => 
            {
                gameStartInitializer.SetLevelId(12);
                ClickedSubPage(0); 
            });
            MenuElements.Add(new MenuElement(textFactory.CreateText(0, 0.55, "AFRICA")), () =>
            {
                gameStartInitializer.SetLevelId(1);
                ClickedSubPage(0);
            });
            MenuElements.Add(new MenuElement(textFactory.CreateText(0, 0.4, "EUROPE")), () =>
            {
                gameStartInitializer.SetLevelId(22);
                ClickedSubPage(0);
            });
            MenuElements.Add(new MenuElement(textFactory.CreateText(0, 0.25, "ASIA")), () =>
            {
                gameStartInitializer.SetLevelId(4);
                ClickedSubPage(0);
            });
        }
    }
}
