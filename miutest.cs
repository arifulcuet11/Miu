using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GeneralCSharp
{
    public class MIUTest
    {
        public bool isFencyNumber(int number)
        {
            if (number == 1) return true;
            int prev_previous = 1;
            int previous = 1;
            int current = 0;
            while (current <= number)
            {
                current = prev_previous * 2 + previous * 3;
                if (current == number) return true;
                prev_previous = previous;
                previous = current;
            }
            return false;
        }

        public bool isMeeraArray(int[] arr)
        {
            bool isOne = false;
            bool isNine = false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 1)
                {
                    isOne = true;
                }
                else if (arr[i] == 9)
                {
                    isNine = true;
                }

                if (isOne && isNine)
                {
                    return true;
                }
            }
            if (!isOne && !isNine)
                return true;

            return false;
        }

        public bool IsBeanArray(int[] arr)
        {
            var set = new HashSet<int>(arr);
            foreach (int i in arr)
            {
                if (!set.Contains(i / 2) && !set.Contains(2 * i) && !set.Contains((2 * i) + 1)) return false;

            }
            return true;
        }

        public int answerTwo(int[] a)
        {
            int number = 0;
            int maxCount = 0;
            //for (int i = 0; i < a.Length; i++)
            //{
            //    int count = 0;
            //    for (int j = 0; j < a.Length; j++)
            //    {
            //        if (a[i] == a[j]) { count++; }
            //    }
            //    if (maxCount < count) { number = a[i]; maxCount = count; }
            //}

            var dict = new Dictionary<int, int>();
            foreach (int i in a)
            {
                if (dict.ContainsKey(i))
                {
                    dict[i]++;
                }
                else
                {
                    dict.Add(i, 1);
                }
            }

            foreach (KeyValuePair<int, int> i in dict)
            {
                if (maxCount < i.Value) { number = i.Key; maxCount = i.Value; }
            }
            return number;
        }

        public int isMadhavArray(int[] arr)
        {
            int n = arr.Length;
            int k = 2;
            int index = 1;

            while (index < n)
            {
                int sum = 0;
                for (int i = index; i < index + k; i++)
                {
                    sum += arr[i];
                }

                if (sum != arr[0])
                {
                    return 0;
                }

                index += k;
                k++;
            }

            return (index == n) ? 1 : 0;
        }

        public int nextPerfectSquare(int n)
        {
            int nextNumber = (int)Math.Ceiling(Math.Sqrt(26));

            return nextNumber * nextNumber;
        }

        public int nUpCount(int[] arr, int n)
        {
            int nUpCount = 0;
            int partialSum = 0;
            int flag = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                partialSum += arr[i];
                if (partialSum < n) flag = 1;
                if (flag == 1 && partialSum > n)
                {
                    nUpCount++;
                    flag = 0;
                }
            }
            return nUpCount;
        }

        public bool IsPrime(int number)
        {
            if (number == 0) return false;
            if (number == 1) return false;
            if (number == 2) return true;

            if (number % 2 == 0) return false;

            int ln = (int)Math.Sqrt(number);
            for (int i = 3; i <= ln; i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        public int primeCount(int start, int end)
        {
            int pCount = 0;
            if (start < 2 && end < 2) return pCount;
            start = Math.Max(2, start);
            for (int i = start; i <= end; i++)
            {
                if (isPrime(i)) pCount++;
            }
            return pCount;
        }

        public int stantonMeasure(int[] a)
        {
            int oneCount = 0;
            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == 1) oneCount++;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == oneCount) result++;
            }
            return result;
        }

        public int sumFactor(int[] a)
        {
            int sum = 0;
            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == sum) result++;
            }

            return result;
        }

        public int guthrieIndex(int n)
        {
            if (n < 1) return 0;

            int count = 0;
            while (n != 1)
            {
                if (n % 2 == 0) n = n / 2;
                else if (n % 2 == 1) n = (n * 3) + 1;
                count++;
            }

            return count;
        }

        private int factorial(int n)
        {
            if (n <= 1) return 1;

            return n * factorial(n - 1);
        }

        public int[] solve10()
        {
            int targetFactorial = factorial(10); // Calculate the factorial of 10

            // Iterate through possible values of x and y
            for (int x = 0; x <= 10; x++)
            {
                for (int y = 0; y <= 10; y++)
                {
                    if (factorial(x) + factorial(y) == targetFactorial)
                    {
                        Console.WriteLine($"x = {x}, y = {y} satisfy the equation.");
                    }
                }
            }
            return new int[] { 0, 0 };
        }

        public int reqsEqual(int[] a, int n)
        {
            if (n == 0)
            {
                if (a.Length == 1 && a[0] == 0) return 1;
                return 0;
            }
            int i = a.Length - 1;
            while (n > 0)
            {
                if (i < 0) return 0;

                int digit = n % 10;
                n = n / 10;

                if (a[i] != digit) return 0;

                i--;
            }

            if (i > 0)
            {
                while (i < 0)
                {
                    if (a[i] != 0) { return 0; }
                    i--;
                }
            }

            return 1;
        }

        public int answerOne(int n)
        {
            int count = 0;
            int sqrRootvalue = (int)Math.Sqrt(n);
            Console.WriteLine(sqrRootvalue);
            for (int i = 1; i <= sqrRootvalue; i++)
            {
                for (int j = 1; j <= sqrRootvalue; j++)
                {
                    if ((i * i) + (j * j) == n)
                    {
                        Console.WriteLine(i + "," + j);

                        count++;
                    };
                }

            }
            return (int)Math.Ceiling(count / 2.0);
        }

        public int Centered15(int[] n)
        {
            int start = 0;
            int end = n.Length - 1;
            while (start <= end)
            {
                int sum = 0;
                for (int i = start; i <= end; i++)
                {
                    sum += n[i];
                }
                if (sum == 15) return 1;

                start++;
                end--;
            }
            return 0;
        }

        public int henry(int i, int j)
        {
            int sum = 0;
            int count = 0;
            int num = 6;
            int mxCount = Math.Max(i, j);
            bool takenI = false;
            bool takenJ = false;
            while (count < mxCount)
            {
                int numSum = 0;
                int ln = (int)Math.Ceiling(num / 2.0);
                for (int k = 1; k <= ln; k++)
                {
                    if (num % k == 0) numSum += k;
                }
                if (numSum == num) count++;
                if (count == i && !takenI)
                {
                    sum += num;
                    takenI = true;
                }
                else if (count == j && !takenJ)
                {
                    sum += num;
                    takenJ = true;
                }

                num++;
            }
            return sum;
        }

        public int isLigalNumber(int[] a, int baseNum)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > baseNum) return 0;
            }
            return 1;
        }

        public int convertToBase10(int[] a, int baseNum)
        {
            if (isLigalNumber(a, baseNum) == 0) return 0;

            int sum = 0;
            for (int i = a.Length - 1, p = 0; i >= 0; i--, p++)
            {
                sum += (a[i] * (int)Math.Pow(baseNum, p));
            }
            return sum;
        }

        public int computeDepth(int n)
        {
            int depth = 0;
            bool[] taken = new bool[10];
            int num = 1;
            bool flag = false;
            for (int i = 0; i < taken.Length; i++)
            {
                taken[i] = false;
            }

            while (true)
            {
                depth++;
                int value = n * num;
                while (value > 0)
                {
                    taken[value % 10] = true;
                    value /= 10;
                }
                flag = true;
                for (int i = 0; i < taken.Length; i++)
                {
                    if (!taken[i]) flag = false;
                }
                if (flag) return depth;
                num++;
            }

        }

        public int isTrivalent(int[] a)
        {
            int count = 0;
            int[] uniqueValues = new int[3];

            for (int i = 0; i < a.Length; i++)
            {
                if (count == 0)
                {
                    uniqueValues[count] = a[i];
                    count++;
                }
                else
                {
                    int flag = 1;
                    for (int j = 0; j < count; j++)
                    {
                        if (uniqueValues[j] == a[i])
                        {
                            flag = 0;
                        }
                    }
                    if (flag == 1)
                    {
                        if (count >= 3) return 0;
                        uniqueValues[count] = a[i];
                        count++;
                    }

                }
            }
            return count == 3 ? 1 : 0;
        }

        public int isSequentiallyBounded(int[] a)
        {
            if (a.Length == 0) return 1;
            int mx = a[0];

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int temp = a[j];
                        a[j] = a[i];
                        a[i] = temp;
                    }
                }
            }

            int currentValue = a[0];
            int count = 1;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == currentValue) count++;
                else
                {
                    if (count >= a[i - 1]) return 0;
                    currentValue = a[i];
                    count = 0;
                }
                if (count >= a[i]) return 0;

            }

            return 1;
        }

        public int[] clusterCompression(int[] a)
        {
            if (a.Length == 0) return new int[0];
            int numCluster = 1;
            int currentVaslue = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == currentVaslue) continue;

                currentVaslue = a[i];
                numCluster++;
            }
            int[] result = new int[numCluster];
            result[0] = a[0];
            currentVaslue = a[0];
            int k = 1;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == currentVaslue) continue;

                currentVaslue = a[i];
                result[k++] = a[i];
            }
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
            return result;
        }

        public int isRailroadTie(int[] a)
        {
            if (a.Length == 0) return 0;
            if (a[0] == 0 || a[a.Length - 1] == 0) { return 0; }
            bool haveNonZero = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != 0)
                {
                    if (i == 0 && a[i + 1] == 0) return 0;
                    else if (i == a.Length - 1 && a[i - 1] == 0) return 0;
                    else if (i > 0 && i < (a.Length - 1) && a[i - 1] == 0 && a[i + 1] == 0) return 0;
                    else if (i > 0 && i < (a.Length - 1) && a[i - 1] != 0 && a[i + 1] != 0) return 0;
                    haveNonZero = true;
                }
                else
                {
                    if (a[i - 1] == 0 || a[i + 1] == 0) return 0;
                }
            }
            return haveNonZero ? 1 : 0;
        }

        public int fullnessQuootient(int n)
        {
            if (n < 0) return -1;
            if (n == 0) return 0;
            int baseNumber = 2;
            int result = 0;
            while (baseNumber <= 9)
            {
                bool zeroFound = false;
                int p = n;
                while (p > 0)
                {
                    if (p % baseNumber == 0)
                    {
                        zeroFound = true;
                        break;
                    }
                    p /= baseNumber;
                }
                if (!zeroFound) { result++; }
                baseNumber++;
            }

            return result;
        }

        public int isPicked(int[] a)
        {

            var taken = new int[a.Length];
            int j = 0;
            for (int i = 0; i < a.Length;)
            {
                int temp = a[i];
                int count = 1;
                if (i == a.Length - 1)
                {
                    if (a[i] != 1) return 0;
                    break;
                };

                while (temp == a[++i])
                {
                    count++;
                    if (i == a.Length - 1)
                    {
                        i++;
                        break;
                    };
                }

                if (count != temp) return 0;

                for (int k = 0; k < j; k++)
                {
                    if (taken[k] == temp) return 0;
                }

                taken[j++] = temp;
            }

            return 1;
        }

        public int is121Array(int[] a)
        {

            bool twoCheck = false;
            if (a.Length == 0) return 0;
            if (a[0] != 1 || a[a.Length - 1] != 1) return 0;

            int start = 0;
            int end = a.Length - 1;
            while (start <= end)
            {
                if (a[start] < 1 || a[start] > 2) return 0;
                if (a[end] < 1 || a[end] > 2) return 0;

                if (a[start] == 1)
                {
                    if (a[end] != 1) return 0;
                    if (twoCheck) return 0;
                }
                else if (a[start] == 2)
                {
                    if (a[end] != 2) return 0;
                    twoCheck = true;
                }
                start++;
                end--;
            }
            return 1;
        }

        public int isSequenceArray(int[] a, int m, int n)
        {

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == m)
                {
                    continue;
                }
                else if (a[i] == (m + 1))
                {
                    m++;
                }
                else return 0;
            }

            return m == n ? 1 : 0;
        }

        public int largestPrimeFactor(int n)
        {
            if (n <= 1) return 0;
            int largerestValue = 0;
            while (n % 2 == 0)
            {
                n /= 2;
                largerestValue = 2;
            };

            for (int i = 3; i <= Math.Sqrt(n); i = i + 2)
            {
                while (n % i == 0)
                {
                    n /= i;
                    largerestValue = i;
                }
            }
            if (n > 2) largerestValue = n;
            return largerestValue;
        }

        public int[] encodeNumber(int n)
        {
            List<int> factors = new List<int>();

            while (n % 2 == 0)
            {
                factors.Add(2);
                n /= 2;
            }

            for (int i = 3; i <= Math.Sqrt(n); i = i + 2)
            {
                while (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
            }
            if (n > 2)
            {
                factors.Add(n);
            }
            for (int i = 0; i < factors.Count; i++)
            {
                Console.WriteLine(factors[i]);
            }
            return factors.ToArray();
        }

        public int matchPattern(int[] a, int[] pattern)
        {
            // len is the number of elements in the array a, patternLen is the number of elements in the pattern.
            int i = 0; // index into a
            int k = 0; // index into pattern
            int matches = 0; // how many times current pattern character has been matched so far
            for (i = 0; i < a.Length; i++)
            {
                if (a[i] == pattern[k])
                    matches++; // current pattern character was matched
                else if (matches == 0 || k == pattern.Length - 1)
                    return 0; // if pattern[k] was never matched (matches==0) or at end of pattern (k==patternLen-1)
                else
                {
                    k++;
                    i--;
                    matches = 0;
                }
            } // end of else
              // return 1 if at end of array a (i==len) and also at end of pattern (k==patternLen-1)
            if (i == a.Length && k == pattern.Length - 1) return 1; else return 0;
        }

        public void doIntegerBasedRounding(int[] a, int n)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > 0)
                {
                    int multiple = (a[i] / n) * n; // Calculate the nearest multiple of n
                    Console.WriteLine(multiple);
                    if (a[i] - multiple >= multiple + n - a[i])
                        a[i] = multiple + n;
                    else
                        a[i] = multiple;
                }
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        public int decodeArray(int[] a)
        {
            int zeroCount = 0;
            int[] result = new int[a.Length];
            int k = 0;
            int sign = a[0] < 0 ? -1 : 1;
            for (int i = 0; i < a.Length;)
            {
                if (a[i] < 0)
                {
                    i++;
                    continue;
                }
                while (a[i++] == 0) zeroCount++;

                result[k++] = zeroCount;
                zeroCount = 0;

            }
            int res = 0;
            int d = 1;
            for (int i = k - 1; i >= 0; i--)
            {
                res += result[i] * d;
                d = d * 10;
            }
            return sign * res;
        }

        public int isSystematicallyIncreasing(int[] a)
        {
            if (a[0] != 1) return 0;
            int k = 0;
            int s = 2;
            for (int i = 0; i < a.Length; i++)
            {
                if (a.Length < k) return 0;

                int num = 1;
                while (i <= k)
                {
                    if (a[i] == num)
                    {
                        i++;
                        num++;
                    }
                    else return 0;
                }
                k = k + s;
                s++;
                i--;
            }
            return 1;
        }

        public int areAnagrams(char[] a1, char[] a2)
        {
            if (a1.Length != a2.Length) return 0;

            int[] taken = new int[26];
            for (int i = 0; i < a1.Length; i++)
            {
                taken[a1[i] - 'a']++;
            }
            for (int i = 0; i < a2.Length; i++)
            {
                taken[a2[i] - 'a']--;
            }

            for (int i = 0; i < taken.Length; i++)
            {
                if (taken[i] != 0) return 0;
            }

            return 1;
        }

        public int isVesuvian(int n)
        {
            int sqrt = (int)Math.Ceiling(Math.Sqrt(n));
            int count = 0;
            for (int i = 1; i <= sqrt; i++)
            {
                for (int j = i; j <= sqrt; j++)
                {
                    if ((i * i) + (j * j) == n)
                    {
                        count++;
                    };
                }
            }
            return count >= 2 ? 1 : 0;
        }

        public int[] computeHMS(int n)
        {
            int[] result = new int[3];

            result[0] = n / 3600;
            result[1] = (n % 3600) / 60;
            result[2] = (n % 3600) % 60;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(result[i]);
            }
            return result;
        }

        public int isMartian(int[] a)
        {
            int oneCount = 0;
            int twoCount = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (i != a.Length - 1 && a[i] == a[i + 1]) return 0;

                if (a[i] == 1) oneCount++;
                else if (a[i] == 2) twoCount++;
            }

            return oneCount > twoCount ? 1 : 0;
        }

        public int isNpaired(int[] a, int n)
        {
            if (n < 0 || a.Length == 0) return 0;
            int minLen = (n / 2) + 1;
            if (minLen > a.Length - 1) return 0;

            int start = 0;
            int end = n;
            if (n > a.Length - 1)
            {
                end = a.Length - 1;
                start = n - end;
            }

            while (start < end)
            {
                if (a[start] + a[end] == n) return 1;
                ++start;
                --end;

            }
            return 0;
        }

        public bool isPrime(int n)
        {
            if (n < 2) return false;

            if (n == 2 || n == 3) return true;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public bool isSquare(int n)
        {
            int num = 2;
            while (true)
            {
                if ((num * num) == n) return true;

                if ((num * num) > n) return false;

                ++num;
            }
        }

        public int isComplete(int[] a)
        {
            bool evenFound = false;
            bool squareFound = false;
            bool sum8Found = false;

            for (int i = 0; i < a.Length; i++)
            {
                if (!evenFound && a[i] % 2 == 0) evenFound = true;

                if (!squareFound && isSquare(a[i]))
                {
                    squareFound = true;
                }

                for (int j = 0; j < a.Length; j++)
                {
                    if (a[i] != a[j] && (a[i] + a[j]) == 8)
                    {
                        sum8Found = true;
                    }

                    if (squareFound && evenFound && sum8Found) return 1;
                }
            }

            return (squareFound && evenFound && sum8Found) ? 1 : 0;
        }

        public int loopSum(int[] a, int n)
        {
            int sum = 0;
            int[] dSum = new int[a.Length];

            dSum[0] = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                dSum[i] = dSum[i - 1] + a[i];
            }

            while (n >= a.Length)
            {
                sum += dSum[a.Length - 1];
                n = n - a.Length;
            }
            if (n > 0)
            {
                sum += dSum[n - 1];
            }
            return sum;
        }

        public int loopSumV2(int[] a, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += a[i % a.Length];
            }
            return sum;
        }

        public int hasNValues(int[] a, int n)
        {
            int[] result = new int[n];
            int k = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int flag = 0;
                for (int j = 0; j < k; j++)
                {
                    if (result[j] == a[i])
                    {
                        flag = 1;
                        break;
                    }
                }

                if (flag == 0)
                {
                    k++;
                    if (k > n) return 0;
                    result[k - 1] = a[i];
                }
            }

            return k == n ? 1 : 0;
        }

        public int numberOffactors(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            int count = 2;

            int ln = (n / 2) + 1;

            for (int i = 2; i <= ln; i++)
            {
                if (n % i == 0) count++;
            }
            return count;

        }

        public int sameNumberOfFactors(int n1, int n2)
        {
            if (n1 < 0 || n2 < 0) return -1;
            int nCount1 = numberOffactors(n1);
            int nCount2 = numberOffactors(n2);
            return nCount1 == nCount2 ? 1 : 0;
        }

        public int isLayered(int[] a)
        {
            if (a.Length < 2) return 0;

            int nCount = 1;
            int currentN = a[0];

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1]) return 0;
                if (currentN == a[i + 1]) nCount++;
                else
                {
                    if (nCount < 2) return 0;
                    nCount = 1;
                    currentN = a[i + 1];
                }
            }

            return nCount >= 2 ? 1 : 0;
        }

        public void updateMileageCounter(int[] a, int miles)
        {
            for (int i = 0; i < miles; i++)
            {
                updateCounterByAddOne(a);
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        private void updateCounterByAddOne(int[] a)
        {
            int index = 0;

            while (index < a.Length)
            {
                a[index]++;
                if (a[index] == 10)
                {
                    a[index] = 0;
                }
                else return;

                index++;
            }
        }

        public int isFineArray(int[] a)
        {
            bool hasPrime = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (isPrime(a[i]))
                {
                    hasPrime = true;
                    bool twinPrime = false;
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (isPrime(a[j]) && Math.Abs(a[i] - a[j]) == 2)
                        {
                            twinPrime = true;
                            break;
                        }
                    }
                    if (!twinPrime) return 0;
                }
            }

            if (!hasPrime) return 1;

            return 1;
        }

        public bool hasKSmallFactors(int k, int n)
        {
            int max = (n / 2) + 1;

            for (int i = 2; i <= max; i++)
            {
                for (int j = 2; j <= max; j++)
                {
                    if ((i * j) == n && i < k && j < k) return true;
                }
            }
            return false;
        }

        public int[]? fill(int[] a, int k, int n)
        {
            if (k <= 0 || n <= 0 || k > a.Length) return null;

            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = a[i % k];
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(result[i]);
            }
            return result;
        }

        public int isHollow(int[] a)
        {
            if (a.Length < 3) return 0;

            int start = 0;
            int end = a.Length - 1;

            while (start < end)
            {
                if (a[start] != 0 && a[end] != 0)
                {
                    start++;
                    end--;
                }
                else break;
            }
            int zeroCount = 0;

            if (start >= end || (end - start + 1) < 3) return 0;
            for (int i = start; i <= end; i++)
            {
                if (a[i] == 0) zeroCount++;
                else return 0;
            }

            return zeroCount > 2 ? 1 : 0;
        }

        public int isMeera(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[j] == (2 * a[i])) return 0;
                    if ((a[i] % 2) == 0 && a[j] == (a[i] / 2)) return 0;
                }
            }
            return 1;
        }

        public int isContinuousFactored(int n)
        {
            int[] factors = new int[(n / 2) + 1];
            int f = 0;
            for (int i = 2; i <= (n / 2) + 1; i++)
            {
                if (n % i == 0) factors[f++] = i;
            }

            if (f < 2) return 0;

            for (int i = 0; i < f - 1; i++)
            {
                int sum = factors[i];
                int j = i;
                while (sum < n)
                {
                    if (j == f - 1) break;

                    if ((factors[j + 1] - factors[j]) == 1) sum *= factors[j + 1];
                    else break;
                    j++;
                }
                if (sum == n) return 1;
            }
            return 0;
        }

        public int isFabi(int n)
        {
            if (n <= 0) return 0;
            int a = 1;
            int fb = 1;
            while (fb < n)
            {
                int temp = fb;
                fb = fb + a;
                a = temp;
                Console.WriteLine(fb);
            }
            if (fb == n) return 1;
            return 0;
        }

        public int isBeean(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int num = a[i];
                bool hasBeanNum = false;
                for (int j = 0; j < a.Length; j++)
                {
                    if (i != j && ((num + 1) == a[j] || (num - 1) == a[j]))
                    {
                        hasBeanNum = true;
                    }
                }
                if (!hasBeanNum) return 0;
            }
            return 1;
        }

        public int isFancy(int n)
        {
            int fNum1 = 1;
            int fNum2 = 1;
            while (fNum2 < n)
            {
                int temp = fNum2;
                fNum2 = 3 * temp + 2 * fNum1;
                fNum1 = temp;
                Console.WriteLine(fNum2);
            }

            if (fNum2 == n) return 1;

            return 0;
        }

        public int isOddHeavy(int[] a)
        {
            int evenMax = 0;
            bool hasEven = false;
            int oddMin = 0;
            bool hasOdd = false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    evenMax = a[i];
                    hasEven = true;
                }
                else
                {
                    oddMin = a[i];
                    hasOdd = true;
                }
                if (hasOdd && hasEven)
                {
                    break;

                }
            }

            if (!hasOdd) return 0;
            if (hasOdd && !hasEven) return 1;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0 && evenMax < a[i]) evenMax = a[i];
                else if (a[i] % 2 != 0 && oddMin > a[i]) oddMin = a[i];
            }

            if (oddMin < evenMax) return 0;

            return 1;
        }
    }
}
