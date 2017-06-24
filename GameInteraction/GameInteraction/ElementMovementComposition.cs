using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameInteractionContracts;
using BaseContracts;
using BaseTypes;
using CollisionDetection;

namespace GameInteraction
{
    public class ElementMovementComposition : IExecuteble
    {
        private IListProvider<IWorldElement> _allElementsProvider;
        private List<IMovableByImpulse> elementsWithImpulseFromLeftToRight = new List<IMovableByImpulse>();
        private List<IMovableByImpulse> elementsWithImpulseFromRightToLeft = new List<IMovableByImpulse>();
        private List<IMovableByImpulse> elementsWithImpulseFromBottomToTop = new List<IMovableByImpulse>();
        private List<IMovableByImpulse> elementsWithImpulseFromTopToBottom = new List<IMovableByImpulse>();
        private List<IMovableByImpulse> elementsWithImpulseFromFloorToCeiling = new List<IMovableByImpulse>();
        private List<IMovableByImpulse> elementsWithImpulseFromCeilingToFloor = new List<IMovableByImpulse>();


        public ElementMovementComposition(IListProvider<IWorldElement> allElementsProvider)
        {
            _allElementsProvider = allElementsProvider;
        }

        void IExecuteble.ExecuteLogic()
        {
            AddElementsIntoCorrespondingLists();

            SortEachElementList();

            LetElementsInteractGroupedByDirection();

            ClearLists();
        }

        #region private methods
        private void ClearLists()
        {
            elementsWithImpulseFromLeftToRight.Clear();

            elementsWithImpulseFromRightToLeft.Clear();

            elementsWithImpulseFromBottomToTop.Clear();

            elementsWithImpulseFromTopToBottom.Clear();

            elementsWithImpulseFromFloorToCeiling.Clear();

            elementsWithImpulseFromCeilingToFloor.Clear();
        }

        private void AddElementsIntoCorrespondingLists()
        {
            foreach (IWorldElement animatableElement in _allElementsProvider.GetList())
            {
                if (!(animatableElement is IMovableByImpulse))
                    continue;

                IMovableByImpulse movableElement = (IMovableByImpulse)animatableElement;

                movableElement.CollisionProtocol.Reset();

                if (movableElement.ImpulseCollection.HasImpulseFromLeftToRight)
                {
                    elementsWithImpulseFromLeftToRight.Add(movableElement);
                }
                if (movableElement.ImpulseCollection.HasImpulseFromRightToLeft)
                {
                    elementsWithImpulseFromRightToLeft.Add(movableElement);
                }
                if (movableElement.ImpulseCollection.HasImpulseFromBottomToTop)
                {
                    elementsWithImpulseFromBottomToTop.Add(movableElement);
                }
                if (movableElement.ImpulseCollection.HasImpulseFromTopToBottom)
                {
                    elementsWithImpulseFromTopToBottom.Add(movableElement);
                }
                if (movableElement.ImpulseCollection.HasImpulseFromCeilingToFloor)
                {
                    elementsWithImpulseFromCeilingToFloor.Add(movableElement);
                }
                if (movableElement.ImpulseCollection.HasImpulseFromFloorToCeiling)
                {
                    elementsWithImpulseFromFloorToCeiling.Add(movableElement);
                }
            }
        }

        private void LetSelectedElementsInteract(List<IMovableByImpulse> elementList, Direction direction)
        {
            foreach (IMovableByImpulse movableElement in elementList)
            {
                movableElement.ProcessImpulseAndMove(direction);
            }
        }

        private void LetElementsInteractGroupedByDirection()
        {
            LetSelectedElementsInteract(elementsWithImpulseFromLeftToRight, Direction.FromLeftToRight);
            LetSelectedElementsInteract(elementsWithImpulseFromRightToLeft, Direction.FromRightToLeft);
            LetSelectedElementsInteract(elementsWithImpulseFromBottomToTop, Direction.FromBottomToTop);
            LetSelectedElementsInteract(elementsWithImpulseFromTopToBottom, Direction.FromTopToBottom);
            LetSelectedElementsInteract(elementsWithImpulseFromFloorToCeiling, Direction.FromFloorToCeiling);
            LetSelectedElementsInteract(elementsWithImpulseFromCeilingToFloor, Direction.FromCeilingToFloor);
        }

        private void SortEachElementList()
        {
            ImpulseSortDirection.Direction = Direction.FromLeftToRight;
            elementsWithImpulseFromLeftToRight.Sort();

            ImpulseSortDirection.Direction = Direction.FromRightToLeft;
            elementsWithImpulseFromRightToLeft.Sort();

            ImpulseSortDirection.Direction = Direction.FromBottomToTop;
            elementsWithImpulseFromBottomToTop.Sort();

            ImpulseSortDirection.Direction = Direction.FromTopToBottom;
            elementsWithImpulseFromTopToBottom.Sort();
        }
        #endregion
    }
}
