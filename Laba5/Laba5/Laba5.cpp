#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <vector>
#include <math.h>
using namespace std;
int main()
{
    char str[200] = {}, counts[200] = {};
    char stre[] = "0123456789";
    int n, i, k, z, m, h;
    cin.getline(str, 200);
    string x = (string)str;
    k = 0;
    string count = "";
    z = x.length();
    i = strcspn(str, stre);
    do
    {
        if (str[i] >= '0' and str[i] <= '9')
        {
            count[k] = str[i];
            k++;
            i++;
        }
        else
        {
            if (k > 0)
            {
                k = -1;
            }
            else
            {
                k = 0;
                i++;
            }
        }

    }

    while ((k != -1) and (i < z));
    if (k == -1)
    {
        cout << endl;
        n = atoi(count.c_str());
        cout << pow(n, 3);

    }
    else { cout << "Нет числа"; }
    cout << ' ' << endl;
    n = 0; h = 0;
    for (k = 0; k < z; k++)
    {
        for (m = 0; m < n; m++)
        {
            if (str[k] == counts[m])
            {
                h = 1;
            }
        }
        if (h == 0)
        {
            counts[n] = str[k];
            n++;
        }
        else
            h = 0;

    }
    string y = (string)counts;
    n = y.length();
    for (h = 0; h < n; h++)
    {
        if ((h + 1) % 6 == 0)
            cout << ",";
        else
        {
            cout << counts[h];
        }

    }





}
