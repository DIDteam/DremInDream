// This code automatically generated by TableCodeGen
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class ItemsTable
{
    [System.Serializable]
	public class Row
	{
		public string ID;
		public string Name;
		public string MeshPath;
		public string ImagePath;

	}

	List<Row> rowList = new List<Row>();
	bool isLoaded = false;

	public bool IsLoaded()
	{
		return isLoaded;
	}

	public List<Row> GetRowList()
	{
		return rowList;
	}

	public void Load(TextAsset csv)
	{
		rowList.Clear();
		string[][] grid = CsvParser2.Parse(csv.text);
		for(int i = 1 ; i < grid.Length ; i++)
		{
			Row row = new Row();
			row.ID = grid[i][0];
			row.Name = grid[i][1];
			row.MeshPath = grid[i][2];
			row.ImagePath = grid[i][3];

			rowList.Add(row);
		}
		isLoaded = true;
	}

	public int NumRows()
	{
		return rowList.Count;
	}

	public Row GetAt(int i)
	{
		if(rowList.Count <= i)
			return null;
		return rowList[i];
	}

	public Row Find_ID(string find)
	{
		return rowList.Find(x => x.ID == find);
	}
	public List<Row> FindAll_ID(string find)
	{
		return rowList.FindAll(x => x.ID == find);
	}
	public Row Find_Name(string find)
	{
		return rowList.Find(x => x.Name == find);
	}
	public List<Row> FindAll_Name(string find)
	{
		return rowList.FindAll(x => x.Name == find);
	}
	public Row Find_MeshPath(string find)
	{
		return rowList.Find(x => x.MeshPath == find);
	}
	public List<Row> FindAll_MeshPath(string find)
	{
		return rowList.FindAll(x => x.MeshPath == find);
	}
	public Row Find_ImagePath(string find)
	{
		return rowList.Find(x => x.ImagePath == find);
	}
	public List<Row> FindAll_ImagePath(string find)
	{
		return rowList.FindAll(x => x.ImagePath == find);
	}

}