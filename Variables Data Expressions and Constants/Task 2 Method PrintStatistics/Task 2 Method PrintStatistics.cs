public void PrintStatistics(double[] array, int count)
{
    double max=array[0];

    for (int i = 0; i < count; i++)
    {
        if (array[i] > max)
        {
            max = array[i];
        }
    }

    PrintMax(max);

    double mjin=array[0];

    for (int i = 0; i < count; i++)
    {
        if (array[i] < min)
        {
            min = array[i];
        }
    }

    PrintMin(min);

    double sum=0;

    for (int i = 0; i < count; i++)
    {
        sum += array[i];
    }

    PrintAvg(sum/count);
}