using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeExsEasy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SingleNumber(4, 1, 2, 1, 2, 4, 2, 2, 13));
        }

        static void Exercise1()
        {
            //int[] nums = { 2, 7, 11, 15 };
            //int[] nums = { 3, 2, 4, 6 };
            int[] nums = { 3, 3 };


            //int target = 9;
            //int target = 6;
            int target = 6;


            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        Console.WriteLine($"Because {nums[i]} + {nums[j]} == {target}, we return [{i}, {j}]");
                    }                    
                    
                }
            }
        }
        //Two nums
        //Another way using HashMap (faster in terms of speed), made throw creating class
        //int[] answ = TwoSum({3, 2, 4, 6}, 6);

        static int[] TwoSum (int[] nums,int target)
        {

            Hashtable htable = new Hashtable();

            for (int i = 0; i < nums.Length; i++)
            {
                htable.Add(nums[i], i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (htable.ContainsKey(complement) && (int)htable[complement] != i)
                {
                    return new int[] { i, (int)htable[complement] }; 
                }
            }

            throw new ArgumentException("Nothing found");

        }

        static int Reverse (int x)
        {
            int answ = 0;

            //An option to avoid overflow 
            //checked { }

            while (x != 0)
            {
                answ = answ * 10 + x % 10;
                x = x / 10;

                if (answ > int.MaxValue / 10 || (answ == int.MaxValue / 10 && x % 10 > 7))
                    return 0;

                if (answ < int.MinValue / 10 || (answ == int.MinValue / 10 && x % 10 < -8))
                    return 0;
                
            }

            return answ;

        }
        //Reverse int number

        static bool isPalindrome (int x)
        {
            char[] num = x.ToString().ToCharArray();

            for (int i = 0; i < num.Length/2; i++)
            {
                if (num[i] != num[num.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
        //Palindrome

        static string CommonPrefix (params string [] words)
        {
            if (words == null || words.Length == 0)
            {
                return "";
            }
            

            for (int i = 0; i < words[0].Length; i++)
            {
               
                for (int j = 1; j < words.Length; j++)
                {
                    if (words[0].Substring(i, 1) != words[j].Substring(i, 1) || i == words[j].Length)
                    {
                        return words[0].Substring(0, i);
                    }

                }

            }

            return words[0];
            
        }
        //Longest common prefix

        static bool isValid (string str)
        {

            var dict = new Dictionary<char, char>()
            {
                { '}', '{' },
                { ')', '(' },
                { ']', '[' },
            };

            var stck = new Stack<char>();

            if (str.Length == 0)
                return true;

            if (str.Length == 1 || str.Length % 2 != 0)
                return false;

            for (int i = 0; i < str.Length; i++)
            {
                if (dict.ContainsValue(str[i]))
                {
                    stck.Push(str[i]);
                }
                else if (dict[str[i]] != stck.Pop())
                {
                    return false;
                }

            }

            return true;

        }
        //Valid Parentheses


        static List<int> MergeSortedLists (List<int> a, List<int> b)
        {
            List<int> c = new List<int>();

            foreach (var item in a)
            {
                c.Add(item);
            }

            foreach (var item in b)
            {
                c.Add(item);
            }

            c.Sort();

            return c;

        }
        //Merge Two Sorted Lists (using List)

        static int[] MergeSortedLists2(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];

            a.CopyTo(c, 0);
            b.CopyTo(c, a.Length);

            for (int i = 0; i < c.Length - 1; i++)
            {
                for (int j = i + 1; j < c.Length; j++)
                {
                    if (c[i] > c[j])
                    {
                        int temp = c[i];
                        c[i] = c[j];
                        c[j] = temp;
                    }
                }
            }

            return c;
        }
        //Merge Two Sorted Lists (using Cycle)

        static int IndexOf(string haystack, string needle)
        {
            if (needle == "")
                return 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                                
                if (haystack[i] == needle[0])
                {
                    for(int j = 1; j < needle.Length; j++)
                    {
                        if (haystack[i + j] != needle[j])
                        {
                            break;
                        }
                        else if (j == needle.Length - 1)
                        {
                            return i;
                        }    
                    }                    
                } 

            }

            return -1;

        }
        //IndexOf

        static int IndexOf1(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;
            if (string.IsNullOrEmpty(haystack))
                return -1;

            int i = 0;
            int j = 0;

            while (i < haystack.Length && j < needle.Length)
            {

                if (haystack[i] == needle[j])
                    j++;
                else
                {
                    i = i - j;
                    j = 0;
                }

                i++;
            }

            if (j == needle.Length)
                return i - j;

            return -1;

        }
        //IndexOf (solution using while)

        static int SearchInsert(int target, params int[] nums)
        {
            
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
                else if (nums[i] > target)
                    return i;
            }

            return nums.Length;
        }
        //Search Insert Position

        static int SearchInsertBinary(int target, params int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            var start = 0;
            var end = nums.Length - 1;
            var mid = 0;

            while (start <= end)
            {
                mid = start + (end - start) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    end = mid - 1;
                else start = mid + 1;
            }

            if (target > nums[mid])
                return mid + 1;

            return mid;
        }
        //Binary Search Insert Position

        static int MaxSubArray (params int [] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            int maxSum = nums[0];
            int sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];

                if (sum < nums[i])
                {
                    sum = nums[i];
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                }

                if (nums[i] > maxSum)
                {
                    sum = nums[i];
                    maxSum = nums[i];
                }
            }

            return maxSum;
        }
        //Maximum Subarray

        //Climbing Stairs
        //Find literature on question//

        //Remove Duplicates from Sorted List
        //Find information on using Linked Lists and TreeNodes//

        static int MaxProfit (params int [] prices)
        {
            int minPrice = prices[0];

            int minPriceIndex = 0;

            int maxPrice = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                
                    if (minPrice > prices[i])
                    {
                        minPrice = prices[i];

                        minPriceIndex = i;

                    }             

            }

            if (minPriceIndex != prices.Length - 1)
            {
                maxPrice = minPrice;

                for (int i = minPriceIndex + 1; i < prices.Length; i++)
                {
                    
                    if (maxPrice < prices[i])
                    {
                        maxPrice = prices[i];
                    }

                }

                return maxPrice - minPrice;
            }

            return 0;

        }

        static int MaxProfit1(params int [] prices)
        {
            int minPrice = int.MaxValue;

            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
                else if (maxProfit < prices[i] - minPrice)
                {
                    maxProfit = prices[i] - minPrice;
                }

            }

            return maxProfit;

        }
        //Best Time to Buy and Sell Stock

        static int SingleNumber(params int[] nums)
        {
            List<int> chkList = new List<int>();

            foreach (var item in nums)
            {
                if (!chkList.Contains(item))
                {
                    chkList.Add(item);
                }
                else
                {
                    chkList.Remove(item);
                }
            }

            return chkList[0];

        }
        //Single Number in Array
    }

}
