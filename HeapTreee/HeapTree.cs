using System;
using System.Collections.Generic;
using System.Text;

namespace HeapTreee
{
    public class HeapTree<T> where T : IComparable<T>
    {
        public List<T> HeapList;
        int TailIndex;

        public HeapTree()
        {
            HeapList = new List<T>();
            TailIndex = 0;
        }

        private void HeapifyUp(int targetIndex)
        {
            int parentIndex = (targetIndex - 1) / 2;

            T targetValue = HeapList[targetIndex];
            T parentValue = HeapList[parentIndex];

            T tempHolder;

            if(targetValue.CompareTo(parentValue) < 0)
            {
                tempHolder = parentValue;
                HeapList[parentIndex] = targetValue;
                HeapList[targetIndex] = tempHolder;
                HeapifyUp(parentIndex);
            }

        }

        private void HeapifyDown(int targetIndex)
        {
            int leftIndex = targetIndex * 2 + 1;
            int rightIndex = targetIndex * 2 + 2;

            T tempHolder;

            if(HeapList[leftIndex].CompareTo(HeapList[rightIndex]) < 0)
            {
                if(HeapList[leftIndex].CompareTo(HeapList[targetIndex]) < 0)
                {
                    tempHolder = HeapList[targetIndex];
                    HeapList[targetIndex] = HeapList[leftIndex];
                    HeapList[leftIndex] = tempHolder;
                    HeapifyDown(leftIndex);
                }
            }
            else
            {
                if(HeapList[rightIndex].CompareTo(HeapList[targetIndex]) < 0)
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
            HeapList[TailIndex] = targetValue;

            HeapifyUp(TailIndex);

            TailIndex++;
        }

        public T Pop()
        {
            tempHolder
            return 
        }
    }
}
