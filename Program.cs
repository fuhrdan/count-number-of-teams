//*****************************************************************************
//** 1395. Count Number of Teams  leetcode                                   **
//** O(n^2) time, beats 100% of cases in C.                        -Dan      **
//*****************************************************************************

int numTeams(int* rating, int ratingSize) {
    int teams = 0;

    // Use dynamic programming to count the number of increasing and decreasing subsequences
    for (int j = 1; j < ratingSize - 1; ++j) {
        int lessLeft = 0, greaterLeft = 0;
        int lessRight = 0, greaterRight = 0;

        // Count elements less and greater than rating[j] to the left
        for (int i = 0; i < j; ++i) {
            if (rating[i] < rating[j]) {
                lessLeft++;
            } else if (rating[i] > rating[j]) {
                greaterLeft++;
            }
        }

        // Count elements less and greater than rating[j] to the right
        for (int k = j + 1; k < ratingSize; ++k) {
            if (rating[k] < rating[j]) {
                lessRight++;
            } else if (rating[k] > rating[j]) {
                greaterRight++;
            }
        }

        // Calculate the number of valid teams
        teams += lessLeft * greaterRight + greaterLeft * lessRight;
    }

    return teams;
}