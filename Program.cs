// See https://aka.ms/new-console-template for more information
using System.Collections.Concurrent;

namespace Assignment3
{

    public class Merger
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] temp = new int[nums1.Length];
            int lCount = 0;
            int rCount = 0;
            int steps = 0;

            while (lCount < m && rCount < n)
            {
                temp[steps++] = (nums1[lCount] < nums2[rCount]) ? nums1[lCount++] : nums2[rCount++];
            }

            if (lCount < m)
            {
                Array.Copy(nums1, lCount, temp, steps, m - lCount);
            }
            else if (rCount < n)
            {
                Array.Copy(nums2, rCount, temp, steps, n - rCount);
            }
            Array.Copy(temp, 0, nums1, 0, temp.Length);
        }
    }

    public class Sorter
    {
        public int Partition(int[] sortingArr, int left, int right)
        {
            int check = sortingArr[left];
            while (true)
            {
                while (sortingArr[left] < check)
                {
                    left++;
                }

                while (sortingArr[right] > check)
                {
                    right--;
                }

                if (left < right)
                {
                    if (sortingArr[left] == sortingArr[right])
                    {                        
                        return right;
                    }

                    int temp = sortingArr[left];
                    sortingArr[left] = sortingArr[right];
                    sortingArr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        public void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }
        }

        public int[] SortArray(int[] nums)
        {
            QuickSort(nums, 0, nums.Length - 1);
            return nums;
        }
    }


    public class OtherSorter
    {
        public bool CheckSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                    return false;
            }
            return true;
        }

        public int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];

            int i = left - 1;

            for (int j = left; j <= right; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    if (arr[i] == arr[j]) continue;
                    int firstSwapTemp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = firstSwapTemp;
                }
            }
            int secondSwapTemp = arr[i + 1];
            arr[i + 1] = arr[right];
            arr[right] = secondSwapTemp;
            return (i + 1);
        }

        public void QuickSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int pivot = Partition(arr, left, right);

                if(pivot > 1)
                    QuickSort(arr, left, pivot - 1);
                if (pivot + 1 < right)
                    QuickSort(arr, pivot + 1, right);
            }
        }

        public int[] SortArray(int[] nums)
        {

            if (!CheckSorted(nums))
            {
                QuickSort(nums, 0, nums.Length - 1);                
            }            

            return nums;
        }
    }

    public class Program
    {

        public static void Main(string[] args)
        {
            Merger m = new Merger();
            Sorter s = new Sorter();
            OtherSorter os = new OtherSorter();

            int[] arr1 = { 1, 2, 3, 0, 0, 0 }, arr2 = { 2, 5, 6 };

            m.Merge(arr1, 3, arr2, 3);

            Console.WriteLine(String.Join(" ", arr1));


            int[] scrambledArr = { 5, 1, 1, 2, 0, 0 };

            int[] scrambledArr2 = { 5, 5, 2, 2, 9, 0, 0, 1, 1, 9, 9 };

            //Console.WriteLine(String.Join(" ", s.SortArray(scrambledArr)));
            //Console.WriteLine(String.Join(" ", s.SortArray(scrambledArr2)));

            Console.WriteLine(String.Join(" ", os.SortArray(scrambledArr)));
            Console.WriteLine(String.Join(" ", os.SortArray(scrambledArr2)));

        }
    }
}