using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ExePatch
{
  partial class ProcessForm : Form
  {
    public ProcessForm()
    {
      InitializeComponent();
    }

    public int ProcessId
    {
      get { return ((Item)list.SelectedItem).ID; }
    }

    public string ProcessName
    {
      get { return ((Item)list.SelectedItem).Name; }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      Refresh();
    }

    #region Item
    sealed class Item : IComparable<Item>
    {
      public Item(int id, string name)
      {
        Name = name;
        ID   = id;
      }

      public int CompareTo(Item other)
      {
        return string.Compare(Name, other.Name, true);
      }

      public override string ToString()
      {
        return Name;
      }

      public string Name;
      public int ID;
    }
    #endregion

    new void Refresh()
    {
      List<Item> items = new List<Item>();
      foreach(Process process in Process.GetProcesses())
      {
        try { items.Add(new Item(process.Id, Path.GetFileName(process.MainModule.FileName) + " (" + process.Id.ToString() + ")")); }
        catch { }
      }

      items.Sort();
      list.Items.Clear();
      list.Items.AddRange(items.ToArray());
      btnSelect.Enabled = false; // for whatever reason, list.Items.Clear() doesn't (properly) raise the SelectedIndexChanged event
    }

    void btnCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    void btnRefresh_Click(object sender, EventArgs e)
    {
      Refresh();
    }

    void btnSelect_Click(object sender, EventArgs e)
    {
      Close();
    }

    void list_DoubleClick(object sender, EventArgs e)
    {
      if(list.SelectedIndex != -1) btnSelect.PerformClick();
    }

    void list_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnSelect.Enabled = list.SelectedIndex != -1;
    }
  }
}
