public class Solution {
    public int HammingWeight(uint n) {
        int result = 0;
        while(n > 0)
        {
            if(n % 2 == 1)
                result++;

            n = n / 2;
            
        }

        return result;
    }
}
