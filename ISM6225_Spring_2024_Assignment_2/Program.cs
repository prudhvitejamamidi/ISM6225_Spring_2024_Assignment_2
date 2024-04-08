/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINIDTION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1);
            Console.WriteLine(numberOfUniqueNumbers);

            //Question 2:
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            //Question 3:
            Console.WriteLine("Question 3:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            //Question 4:
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            //Question 5:
            Console.WriteLine("Question 5:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            //Question 6:
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3,6,9,1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            //Question 7:
            Console.WriteLine("Question 7:");
            int[] nums6 = { 2,1,2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            //Question 8:
            Console.WriteLine("Question 8:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);
        }

        /*
        
        Question 1:
        Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same. Then return the number of unique elements in nums.

        Consider the number of unique elements of nums to be k, to get accepted, you need to do the following things:

        Change the array nums such that the first k elements of nums contain the unique elements in the order they were present in nums initially. The remaining elements of nums are not important as well as the size of nums.
        Return k.

        Example 1:

        Input: nums = [1,1,2]
        Output: 2, nums = [1,2,_]
        Explanation: Your function should return k = 2, with the first two elements of nums being 1 and 2 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
        Example 2:

        Input: nums = [0,0,1,1,1,2,2,3,3,4]
        Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
        Explanation: Your function should return k = 5, with the first five elements of nums being 0, 1, 2, 3, and 4 respectively.
        It does not matter what you leave beyond the returned k (hence they are underscores).
 

        Constraints:

        1 <= nums.length <= 3 * 104
        -100 <= nums[i] <= 100
        nums is sorted in non-decreasing order.
        */

        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check if the input array meets the constraints
                if (nums == null || nums.Length < 1 || nums.Length > 312)
                    throw new ArgumentException("The length of the input array must be between 1 and 313.");

                foreach (int num in nums)
                {
                    if (num < -100 || num > 100)
                        throw new ArgumentException("Each element in the input array must be between -100 and 100.");
                }

                // If the array has less than 2 elements, there are no duplicates to remove
                if (nums.Length < 2)
                    return nums.Length;

                // Initialize the index to keep track of the unique elements
                int uniqueIndex = 1;

                // Iterate through the array starting from the second element
                for (int i = 1; i < nums.Length; i++)
                {
                    // If the current element is different from the previous element
                    if (nums[i] != nums[i - 1])
                    {
                        // Place the current element at the uniqueIndex position
                        nums[uniqueIndex] = nums[i];
                        // Increment the uniqueIndex to prepare for the next unique element
                        uniqueIndex++;
                    }
                }

                // The uniqueIndex now represents the number of unique elements in the array
                return uniqueIndex;
            }
            catch (ArgumentException ex)
            {
                // If the input array does not meet the constraints, throw the exception
                throw new ArgumentException(ex.Message);
            }
            catch (Exception)
            {
                // If any other exception occurs, throw it
                throw;
            }
        }

        /*
        
        Question 2:
        Given an integer array nums, move all 0's to the end of it while maintaining the relative order of the non-zero elements.

        Note that you must do this in-place without making a copy of the array.

        Example 1:

        Input: nums = [0,1,0,3,12]
        Output: [1,3,12,0,0]
        Example 2:

        Input: nums = [0]
        Output: [0]
 
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1
        */

        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                // Check if the length of the input array is within the constraints
                if (nums.Length < 1 || nums.Length > 104)
                {
                    throw new ArgumentException("The length of the input array must be between 1 and 104(inclusive).");
                }

                // Initialize a variable to keep track of the next non-zero element position
                int nextNonZeroPos = 0;

                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // Check if the current element is within the constraints
                    if (nums[i] < -231 || nums[i] > 230)
                    {
                        throw new ArgumentException("The values of the elements in the array must be between -231 and 230(inclusive).");
                    }

                    // If the current element is non-zero
                    if (nums[i] != 0)
                    {
                        // Swap the current element with the element at the next non-zero position
                        (nums[nextNonZeroPos], nums[i]) = (nums[i], nums[nextNonZeroPos]);

                        // Increment the next non-zero position
                        nextNonZeroPos++;
                    }
                }

                // Return the modified array as a list
                return nums.ToList();
            }
            catch (ArgumentException ex)
            {
                // Throw the exception with the appropriate error message
                throw new Exception(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

        Notice that the solution set must not contain duplicate triplets.

 

        Example 1:

        Input: nums = [-1,0,1,2,-1,-4]
        Output: [[-1,-1,2],[-1,0,1]]
        Explanation: 
        nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
        nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
        nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
        The distinct triplets are [-1,0,1] and [-1,-1,2].
        Notice that the order of the output and the order of the triplets does not matter.
        Example 2:

        Input: nums = [0,1,1]
        Output: []
        Explanation: The only possible triplet does not sum up to 0.
        Example 3:

        Input: nums = [0,0,0]
        Output: [[0,0,0]]
        Explanation: The only possible triplet sums up to 0.
 

        Constraints:

        3 <= nums.length <= 3000
        -105 <= nums[i] <= 105

        */

        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            try
            {
                // Check if the input array has at least 3 and less tan 3000 elements
                if (nums.Length < 3 || nums.Length > 3000)
                {
                    throw new ArgumentException("The length of the input array must be between 3 and 3000(inclusive).");
                }

                // Sort the input array in ascending order
                Array.Sort(nums);

                // Initialize the result list to store the triplets
                List<IList<int>> result = new List<IList<int>>();

                // Iterate through the array, fixing the first element
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // Skip duplicates for the first element
                    if (i > 0 && nums[i] == nums[i - 1])
                    {
                        continue;
                    }

                    // Initialize the left and right pointers
                    int left = i + 1;
                    int right = nums.Length - 1;

                    // Iterate until the left pointer is less than the right pointer
                    while (left < right)
                    {
                        // Calculate the sum of the current triplet
                        int sum = nums[i] + nums[left] + nums[right];

                        // If the sum is 0, add the triplet to the result list and move the pointers
                        if (sum == 0)
                        {
                            result.Add(new List<int> { nums[i], nums[left], nums[right] });

                            // Skip duplicates for the second and third elements
                            while (left < right && nums[left] == nums[left + 1])
                            {
                                left++;
                            }
                            while (left < right && nums[right] == nums[right - 1])
                            {
                                right--;
                            }

                            left++;
                            right--;
                        }
                        // If the sum is less than 0, move the left pointer to the right
                        else if (sum < 0)
                        {
                            left++;
                        }
                        // If the sum is greater than 0, move the right pointer to the left
                        else
                        {
                            right--;
                        }
                    }
                }

                return result;
            }
            catch (ArgumentException ex)
            {
                // Handle the case where the input array has less than 3 elements
                Console.WriteLine(ex.Message);
                return new List<IList<int>>();
            }
            catch (Exception)
            {
                // Handle any other exceptions that may occur
                throw;
            }
        }

        /*

        Question 4:
        Given a binary array nums, return the maximum number of consecutive 1's in the array.

        Example 1:

        Input: nums = [1,1,0,1,1,1]
        Output: 3
        Explanation: The first two digits or the last three digits are consecutive 1s. The maximum number of consecutive 1s is 3.
        Example 2:

        Input: nums = [1,0,1,1,0,1]
        Output: 2
 
        Constraints:

        1 <= nums.length <= 105
        nums[i] is either 0 or 1.

        */

        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                // Check if the input array is valid (within the constraints)
                if (nums == null || nums.Length < 1 || nums.Length > 106)
                {
                    throw new ArgumentException("Invalid input array size. The array length must be between 1 and 106.");
                }

                // Check if all elements in the array are either 0 or 1
                foreach (int num in nums)
                {
                    if (num != 0 && num != 1)
                    {
                        throw new ArgumentException("The array elements must be either 0 or 1.");
                    }
                }

                // Initialize the maximum count of consecutive 1's to 0
                int maxConsecutiveOnes = 0;

                // Initialize the current count of consecutive 1's to 0
                int currentConsecutiveOnes = 0;

                // Iterate through the input array
                foreach (int num in nums)
                {
                    // If the current element is 1, increment the current count of consecutive 1's
                    if (num == 1)
                    {
                        currentConsecutiveOnes++;
                    }
                    // If the current element is 0, reset the current count of consecutive 1's
                    else
                    {
                        // Update the maximum count of consecutive 1's if the current count is greater
                        maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, currentConsecutiveOnes);
                        currentConsecutiveOnes = 0;
                    }
                }

                // Update the maximum count of consecutive 1's for the last sequence (if any)
                maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, currentConsecutiveOnes);

                // Return the maximum count of consecutive 1's
                return maxConsecutiveOnes;
            }
            catch (ArgumentException ex)
            {
                // Handle the case where the input array has less than 3 elements
                Console.WriteLine(ex.Message);
                return 0;
            }
            catch (Exception)
            {
                // Throw an exception if any unexpected error occurs
                throw;
            }
        }

        /*

        Question 5:
        You are tasked with writing a program that converts a binary number to its equivalent decimal representation without using bitwise operators or the `Math.Pow` function. You will implement a function called `BinaryToDecimal` which takes an integer representing a binary number as input and returns its decimal equivalent. 

        Requirements:
        1. Your program should prompt the user to input a binary number as an integer. 
        2. Implement the `BinaryToDecimal` function, which takes the binary number as input and returns its decimal equivalent. 
        3. Avoid using bitwise operators (`<<`, `>>`, `&`, `|`, `^`) and the `Math.Pow` function for any calculations. 
        4. Use only basic arithmetic operations such as addition, subtraction, multiplication, and division. 
        5. Ensure the program displays the input binary number and its corresponding decimal value.

        Example 1:
        Input: num = 101010
        Output: 42


        Constraints:

        1 <= num <= 10^9

        */

        public static int BinaryToDecimal(int binary)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Check if the input binary number is within the given constraints
                if (binary < 1 || binary > 1000000000)
                {
                    throw new ArgumentException("Binary number must be between 1 and 1,000,000,000 (inclusive).");
                }

                int decimaldigit = 0;

                // Iterate through the binary number, starting from the least significant bit
                while (binary > 0)
                {
                    // Get the last digit of the binary number
                    int digit = binary % 10;
                    // Check if the digit is either 0 or 1
                    if (digit != 0 && digit != 1)
                    {
                        throw new ArgumentException("Binary number must contain only 0s and 1s.");
                    }

                    // Add the contribution of the current digit to the decimal value
                    decimaldigit = decimaldigit * 2 + digit;

                    // Move to the next digit in the binary number
                    binary /= 10;
                }

                return decimaldigit;
            }
            catch(ArgumentException ex)
            {
                // Handle the case where the input array has less than 3 elements
                Console.WriteLine(ex.Message);
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:6
        Given an integer array nums, return the maximum difference between two successive elements in its sorted form. If the array contains less than two elements, return 0.
        You must write an algorithm that runs in linear time and uses linear extra space.

        Example 1:

        Input: nums = [3,6,9,1]
        Output: 3
        Explanation: The sorted form of the array is [1,3,6,9], either (3,6) or (6,9) has the maximum difference 3.
        Example 2:

        Input: nums = [10]
        Output: 0
        Explanation: The array contains less than 2 elements, therefore return 0.
 

        Constraints:

        1 <= nums.length <= 105
        0 <= nums[i] <= 109

        */

        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums.Length < 2)
                {
                    return 0;
                }

                // Check if the input array contains elements outside the given range
                foreach (int num in nums)
                {
                    if (num < 0 || num > 109)
                    {
                        throw new ArgumentException("Array elements must be between 0 and 109 (inclusive).");
                    }
                }

                // Check if the input array has more than 105 elements
                if (nums.Length > 105)
                {
                    throw new ArgumentException("Array length must be between 1 and 105 (inclusive).");
                }

                // Find the minimum and maximum values in the array
                int min = nums.Min();
                int max = nums.Max();

                // Create buckets to store the minimum and maximum values in each bucket
                int bucketSize = Math.Max(1, (max - min) / (nums.Length - 1));
                int bucketCount = (max - min) / bucketSize + 1;
                int[] bucketMin = new int[bucketCount];
                int[] bucketMax = new int[bucketCount];

                // Initialize the bucket values
                for (int i = 0; i < bucketCount; i++)
                {
                    bucketMin[i] = int.MaxValue;
                    bucketMax[i] = int.MinValue;
                }

                // Distribute the array elements into the buckets
                foreach (int num in nums)
                {
                    int bucketIndex = (num - min) / bucketSize;
                    bucketMin[bucketIndex] = Math.Min(bucketMin[bucketIndex], num);
                    bucketMax[bucketIndex] = Math.Max(bucketMax[bucketIndex], num);
                }

                // Find the maximum gap between the buckets
                int maxGap = 0;
                int prevMax = min;
                for (int i = 0; i < bucketCount; i++)
                {
                    if (bucketMin[i] == int.MaxValue && bucketMax[i] == int.MinValue)
                    {
                        continue; // Skip empty buckets
                    }

                    maxGap = Math.Max(maxGap, bucketMin[i] - prevMax);
                    prevMax = bucketMax[i];
                }

                return maxGap;
            }
            catch (ArgumentException ex)
            {
                // Handle the case where if the input array contains elements outside the given range
                Console.WriteLine(ex.Message);
                return 0;
            }
            catch (Exception)
            {
                throw;
            }

        }  
        // Check if the input array has less than 2 elements

        /*

        Question:7
        Given an integer array nums, return the largest perimeter of a triangle with a non-zero area, formed from three of these lengths. If it is impossible to form any triangle of a non-zero area, return 0.

        Example 1:

        Input: nums = [2,1,2]
        Output: 5
        Explanation: You can form a triangle with three side lengths: 1, 2, and 2.
        Example 2:

        Input: nums = [1,2,1,10]
        Output: 0
        Explanation: 
        You cannot use the side lengths 1, 1, and 2 to form a triangle.
        You cannot use the side lengths 1, 1, and 10 to form a triangle.
        You cannot use the side lengths 1, 2, and 10 to form a triangle.
        As we cannot use any three side lengths to form a triangle of non-zero area, we return 0.

        Constraints:

        3 <= nums.length <= 104
        1 <= nums[i] <= 106

        */

        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 1 || nums.Length > 105)
                {
                    throw new ArgumentException("Invalid input array size. The array length must be between 1 and 105.");
                }
                foreach (int num in nums)
                {
                    if (num < 1 || num > 106)
                        throw new ArgumentException("Each element in the input array must be between 1 and 106.");
                }
                // Sort the input array in descending order
                Array.Sort(nums);
                Array.Reverse(nums);

                // Iterate through the sorted array and check if the current three elements can form a valid triangle
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    // The sum of the lengths of any two sides of a triangle must be greater than the length of the third side
                    if (nums[i] < nums[i + 1] + nums[i + 2])
                    {
                        // If the condition is met, return the perimeter of the triangle
                        return nums[i] + nums[i + 1] + nums[i + 2];
                    }
                }

                // If no valid triangle can be formed, return 0
                return 0;
            }
            catch (ArgumentException ex)
            {
                // Handle the case where the input array has less than 3 elements
                Console.WriteLine(ex.Message);
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question:8

        Given two strings s and part, perform the following operation on s until all occurrences of the substring part are removed:

        Find the leftmost occurrence of the substring part and remove it from s.
        Return s after removing all occurrences of part.

        A substring is a contiguous sequence of characters in a string.

 

        Example 1:

        Input: s = "daabcbaabcbc", part = "abc"
        Output: "dab"
        Explanation: The following operations are done:
        - s = "daabcbaabcbc", remove "abc" starting at index 2, so s = "dabaabcbc".
        - s = "dabaabcbc", remove "abc" starting at index 4, so s = "dababc".
        - s = "dababc", remove "abc" starting at index 3, so s = "dab".
        Now s has no occurrences of "abc".
        Example 2:

        Input: s = "axxxxyyyyb", part = "xy"
        Output: "ab"
        Explanation: The following operations are done:
        - s = "axxxxyyyyb", remove "xy" starting at index 4 so s = "axxxyyyb".
        - s = "axxxyyyb", remove "xy" starting at index 3 so s = "axxyyb".
        - s = "axxyyb", remove "xy" starting at index 2 so s = "axyb".
        - s = "axyb", remove "xy" starting at index 1 so s = "ab".
        Now s has no occurrences of "xy".

        Constraints:

        1 <= s.length <= 1000
        1 <= part.length <= 1000
        s​​​​​​ and part consists of lowercase English letters.

        */

        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                // Check if the input strings are within the constraints
                if (s.Length < 1 || s.Length > 1000 || part.Length < 1 || part.Length > 1000)
                {
                    throw new ArgumentException("Input strings must be between 1 and 1000 characters long.");
                }
                // Check if the input strings contain only lowercase English letters
                foreach (char c in s)
                {
                    if (c < 'a' || c > 'z')
                    {
                        throw new ArgumentException("Input strings must contain only lowercase English letters.");
                    }
                }
                foreach (char c in part)
                {
                    if (c < 'a' || c > 'z')
                    {
                        throw new ArgumentException("Input strings must contain only lowercase English letters.");
                    }
                }
                // Initialize a string to store the modified string
                string result = s;

                // Keep removing the leftmost occurrence of the part string until no more occurrences are found
                while (true)
                {
                    int index = result.IndexOf(part);
                    if (index == -1)
                    {
                        // No more occurrences of the part string found, return the modified string
                        return result;
                    }
                    result = result.Substring(0, index) + result.Substring(index + part.Length);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
