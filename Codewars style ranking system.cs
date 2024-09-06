using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;

public class User
{
    public int rank;
    public int progress;

    public User()
    {
        rank = 8;
        progress = 0;
    }

    public void incProgress(int actRank)
    {
        if (actRank < -8 || actRank == 0 || actRank > 8)
        {
            throw new ArgumentException();
        }
        else if (actRank > rank)
        {
            var valueProgress = 10 * Math.Pow(differenceInRanks(actRank, rank), 2);

            increaseProgress((int)valueProgress);
        }
        else if (actRank == rank)
        {
            var valueProgress = 3;

            increaseProgress(valueProgress);
        }
        else if (actRank == subtractFromRank(1))
        {
            var valueProgress = 1;
            increaseProgress(valueProgress);
        }

        if (rank == 8)
        {
            progress = 0;
        }
    }

    private int differenceInRanks(int fRank, int sRank)
    {
        var result = Math.Abs(fRank - sRank);

        if ((fRank < 0 && sRank > 0) || (fRank > 0 && sRank < 0))
        {
            return result - 1;
        }
        else
        {
            return result;
        }
    }

    private void increaseProgress(int n)
    {
        var newProgress = progress + n;
        if (newProgress > 100)
        {
            rank = addToRank(newProgress / 100);
            progress = newProgress % 100;
        }
        else
        {
            progress = newProgress;
        }
    }

    private int subtractFromRank(int n)
    {
        var newRank = rank - n;

        if (newRank == 0)
        {
            return -1;
        }
        else if (newRank < -8)
        {
            return -8;
        }
        else
        {
            return newRank;
        }
    }

    private int addToRank(int n)
    {
        var newRank = rank + n;

        if (newRank == 0)
        {
            return 1;
        }
        else if (newRank > 8)
        {
            progress = 0;
            return 8;
        }
        else
        {
            return newRank;
        }
    }
}