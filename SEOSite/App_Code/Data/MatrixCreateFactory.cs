using ANewWebOrder;
using ANWO.Biz.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TwoColumnCategory
/// </summary>
public class MatrixCreateFactory<T> where T : class
{
    public static List<MultiColumn<T>> table { get; set; }

    public static List<MultiColumn<T>> GenerateMultiColumn(List<T> flatList, int numOfColumns)
    {
        table = new List<MultiColumn<T>>();

        int totalItems = flatList.Count;
        if (flatList != null && totalItems > 0)
        {
            for (int i = 0; i < totalItems; i++)
            {
                MultiColumn<T> row = new MultiColumn<T>();
                for (int a = 0; a < numOfColumns; a++)
                {
                    if (a < totalItems - i)
                    {
                        row.Columns.Add((T)flatList.ElementAt(i));
                        i++;
                    }
                }
                i--;
                table.Add(row);
            }
        }
        return table;
    }
}