using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTree
{
    public class HeapTree<T>
    {
        public List<T> HeapList;
        int TailIndex => HeapList.Count - 1;

        public bool IsEmpty => HeapList.Count == 0;

        IComparer<T> comparer;

        public HeapTree(IComparer<T> comparer)
        {
            this.comparer = comparer;


            HeapList = new List<T>();
        }

        private void HeapifyUp(int targetIndex)
        {
            if (targetIndex <= 0)
            {
                return;
            }

            int parentIndex = (targetIndex - 1) / 2;

            T targetValue = HeapList[targetIndex];
            T parentValue = HeapList[parentIndex];


            if (comparer.Compare(targetValue, parentValue) < 0)
            {
                T tempHolder = parentValue;
                HeapList[parentIndex] = targetValue;
                HeapList[targetIndex] = tempHolder;
                HeapifyUp(parentIndex);
            }

        }

        private void HeapifyDown(int targetIndex)
        {
            int leftIndex = targetIndex * 2 + 1;
            if (leftIndex >= HeapList.Count)
            {
                return;
            }

            int rightIndex = targetIndex * 2 + 2;

            T tempHolder;

            if(rightIndex >= HeapList.Count || comparer.Compare(HeapList[leftIndex], HeapList[rightIndex]) < 0)
            {
                if(comparer.Compare(HeapList[leftIndex], HeapList[targetIndex]) < 0)
                {
                    tempHolder = HeapList[targetIndex];
                    HeapList[targetIndex] = HeapList[leftIndex];
                    HeapList[leftIndex] = tempHolder;
                    HeapifyDown(leftIndex);
                }
            }
            else
            {
                if(comparer.Compare(HeapList[rightIndex], HeapList[targetIndex]) < 0)
                {
                    tempHolder = HeapList[targetIndex];
                    HeapList[targetIndex] = HeapList[rightIndex];
                    HeapList[rightIndex] = tempHolder;
                    HeapifyDown(rightIndex);
                }
            }
        }

        public void Add(T targetValue)
        {
            HeapList.Add(targetValue);

            HeapifyUp(TailIndex);
        }

        public List<T> HeapSort()
        {
            List<T> returnList = new List<T>();

            var heap = new List<T>();
            

            T tempHolder;
            while (HeapList.Count > 0)
            {
                tempHolder = Pop();
                returnList.Add(tempHolder);
                heap.Add(tempHolder);
            }
            HeapList = heap;
            return returnList;
        }

        public T Pop()
        {
            if(HeapList.Count == 0)
            {
                throw new HeapEmptyException("Heap is empty");
            }

            T tempHolder = HeapList[0];

            HeapList[0] = HeapList[TailIndex];
            HeapList.RemoveAt(TailIndex);

            HeapifyDown(0);

            return tempHolder;
        }
    }
}
